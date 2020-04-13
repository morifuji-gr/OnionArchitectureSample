using onion.Application;
using onion.Domain;
using onion.Infrastructure;
using Zenject;

namespace onion.Installer
{
    public class DefaultInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
            .Bind <ISaveDataRepository>()
            .To <JsonSaveDataRepsitory>()
            .AsCached();

            Container.Bind <SaveDataService>().AsCached();
        }
    }
}
