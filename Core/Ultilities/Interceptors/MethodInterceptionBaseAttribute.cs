using Castle.DynamicProxy;
using System;

namespace Core.Ultilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } //Hangi attribute önce calissin

        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}