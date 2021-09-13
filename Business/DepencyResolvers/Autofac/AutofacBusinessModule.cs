using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrate;
using Castle.DynamicProxy;
using Core.Ultilities.Helpers.FileHelper;
using Core.Ultilities.Interceptors;
using Core.Ultilities.Secuirty.JWT;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;

namespace Business.DepencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        //Apinin istediği managerlar ve servisler
        //instance isteyen siniflarin karsiligini aldiği metod
        //bazilarinin singlelerini sonra kaldir
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            builder.RegisterType<FileHelper>().As<IFileHelper>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<CreditCardManager>().As<ICreditCardService>();
            builder.RegisterType<EfCreditCardDal>().As<ICreditCardDal>();

            builder.RegisterType<PaymentManager>().As<IPaymentService>();
            builder.RegisterType<EfPaymentDal>().As<IPaymentDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<FindeksScoreManager>().As<IFindeksScoreService>();
            builder.RegisterType<EfFindeksScoreDal>().As<IFindeksScoreDal>();

            builder.RegisterType<FuelManager>().As<IFuelService>().SingleInstance();
            builder.RegisterType<EfFuelDal>().As<IFuelDal>().SingleInstance();

            builder.RegisterType<GearManager>().As<IGearService>().SingleInstance();
            builder.RegisterType<EfGearDal>().As<IGearDal>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}