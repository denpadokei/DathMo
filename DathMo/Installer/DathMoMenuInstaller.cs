using DathMo.Views;
using Zenject;

namespace DathMo.Installer
{
    public class DathMoMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.BindInterfacesAndSelfTo<SettingView>().FromNewComponentAsViewController().AsCached().NonLazy();
        }
    }
}
