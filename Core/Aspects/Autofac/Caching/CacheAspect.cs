using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Caching;
using Core.Ultilities.Interceptors;
using Core.Ultilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");//metodun ismini namespaceden itibaren al
            var arguments = invocation.Arguments.ToList();//parametre var mı
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";//parametre oldugunda calisan metod
            if (_cacheManager.IsAdd(key)) //cachede böyle bir key var mı
            {
                invocation.ReturnValue = _cacheManager.Get(key);//cacheden o metodu getir
                return;
            }
            invocation.Proceed();//metod devam etsin
            _cacheManager.Add(key, invocation.ReturnValue, _duration); //o keyi bellege ekle
        }
    }
}