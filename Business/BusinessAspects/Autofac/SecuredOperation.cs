using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Ultilities.Interceptors;
using Core.Ultilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//her istek için http contexti oluşturur

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//attributeye parametre olarak verilecek rolleri arraya atmaya yarar
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//her jwtlik istek icin. Bu aslında apide yaptıgımız autofac destegini masaüstü platformada aktarıyor
        }

        protected override void OnBefore(IInvocation invocation)//Metodun önünde calistir
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); //O anki kullanıcının rollerini getir
            //_httpContextAccessor.HttpContext.User.
            //Rolleri gezerken ilgili rol varsa return et
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            //İlgili rol yoksa uyarı mesajını ver
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}