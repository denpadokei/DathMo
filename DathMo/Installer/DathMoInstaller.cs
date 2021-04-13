using DathMo.Views;
using SiraUtil;
using Zenject;

namespace DathMo.Installer
{
    public class DathMoInstaller : Zenject.Installer
    {
        public override void InstallBindings() => this.Container.BindInterfacesAndSelfTo<StaffView>().FromNewComponentAsViewController().AsCached().NonLazy();
    }
}
