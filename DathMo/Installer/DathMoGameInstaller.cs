using DathMo.Views;
using SiraUtil;

namespace DathMo.Installer
{
    public class DathMoGameInstaller : Zenject.Installer
    {
        public override void InstallBindings() => this.Container.BindInterfacesAndSelfTo<StaffView>().FromNewComponentAsViewController().AsCached().NonLazy();
    }
}
