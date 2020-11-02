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
    public class DathMoInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.BindViewController<StaffView>();
            this.Container.BindInterfacesAndSelfTo<DathMoController>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}
