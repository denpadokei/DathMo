using DathMo.Views;
using SiraUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
