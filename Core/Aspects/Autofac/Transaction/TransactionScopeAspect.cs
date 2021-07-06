using Castle.DynamicProxy;
using Core.Ultilities.Interceptors;
using System.Transactions;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)//Intercept, bu metodu calistir demektir. IInvocation invocation aspecte parametre olarak yolladigimiz metod
        {
            //burasi bir sablon
            using (TransactionScope transactionScope = new TransactionScope())
            {
                try
                {
                    invocation.Proceed();//Parametre olarak gelen metodu calistir
                    transactionScope.Complete();
                }
                catch (System.Exception e)
                {
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}