using Microsoft.Extensions.DependencyInjection;

namespace Core.Ultilities.IoC
{
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}