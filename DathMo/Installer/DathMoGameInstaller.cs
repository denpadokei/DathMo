using DathMo.Views;
using Zenject;

namespace DathMo.Installer
{
    public class DathMoGameInstaller : Zenject.Installer
    {
        public override void InstallBindings() => this.Container.BindInterfacesAndSelfTo<StaffView>().FromNewComponentAsViewController().AsCached().NonLazy();
    }
}
