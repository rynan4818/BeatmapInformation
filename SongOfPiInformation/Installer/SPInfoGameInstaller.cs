using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using SiraUtil;
using SongOfPiInformation.Views;

namespace SongOfPiInformation.Installer
{
    public class SPInfoGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.BindInterfacesAndSelfTo<SongOfPiInformationViewController>().FromNewComponentAsViewController().AsSingle().NonLazy();
        }
    }
}
