using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetworkInterfaces;
using Ninject.Modules;
using TicTacToe.Core;

namespace TicTacToe.IntegrationTests
{
    class IntegrationTestModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICommonGameNetworkControl>().To<GBoxGameNetwork>();
            Bind<GameEngine>().ToSelf();
        }
    }
}
