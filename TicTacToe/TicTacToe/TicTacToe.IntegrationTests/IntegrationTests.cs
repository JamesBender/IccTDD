using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using NUnit.Framework;
using TicTacToe.Core;

namespace TicTacToe.IntegrationTests
{
    [TestFixture]
    public class IntegrationTests
    {
        [Test]
        public void ShouldBeAbleToBuildStack()
        {
            var kernel = new StandardKernel(new IntegrationTestModule());
            var gameEngine = kernel.Get<GameEngine>();
        }
    }
}
