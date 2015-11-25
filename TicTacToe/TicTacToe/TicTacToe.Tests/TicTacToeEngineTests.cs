using System;
using System.Collections.Generic;
using GameNetworkInterfaces;
using Moq;
using NUnit.Framework;
using TicTacToe.Core;

namespace TicTacToe.Tests
{
    [TestFixture]
    public class TicTacToeEngineTests
    {
        private GameEngine _gameEngine;
        private Mock<ICommonGameNetworkControl> _commonGameNetworkControl;

        [SetUp]
        public void SetupTests()
        {
            _commonGameNetworkControl = new Mock<ICommonGameNetworkControl>();
            _gameEngine = new GameEngine(_commonGameNetworkControl.Object);            
        }

        [Test]
        public void WhenTheBoardIsEmptyThenThereIsNoWinner()
        {
            //Arrange
            var expectedResult = " ";
            var board = new[,] { { " ", " ", " " }, { " ", " ", " " }, { " ", " ", " " } };

            //Act
            var result = _gameEngine.GetWinner(board);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenTheUserLogsInWithAGoodUsernameAndPasswordTheyShouldGetASessionId()
        {
            //Arrange
            var username = "ScottP";
            var password = "IronMan";
            var expectedResult = Guid.NewGuid();
          
            _commonGameNetworkControl.Setup(x => x.Login(username, password)).Returns(expectedResult);

            //Act
            var result = _gameEngine.Login(username, password);

            //Assert
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ShouldBeAbleToAddThreeFriendsToAGameOfTicTacToeWhenAlreadyLoggedIn()
        {
            //Arrange
            var friendOneId = Guid.NewGuid();
            var friendTwoId = Guid.NewGuid();
            var friendThreeId = Guid.NewGuid();
            var expectedResult = Guid.NewGuid();

            _commonGameNetworkControl.Setup(x => x.InviteFriendToMatch(It.IsAny<Guid>(), friendOneId, It.IsAny<Guid>()))
                .Returns(expectedResult);

            _commonGameNetworkControl.Setup(x => x.InviteFriendToMatch(It.IsAny<Guid>(), friendTwoId, It.IsAny<Guid>(), It.IsAny<Guid>()))
                .Returns(expectedResult);

            _commonGameNetworkControl.Setup(x => x.InviteFriendToMatch(It.IsAny<Guid>(), friendThreeId, It.IsAny<Guid>(), It.IsAny<Guid>()))
                .Returns(expectedResult);

            //Act
            var resultOne = _gameEngine.InviteFriend(friendOneId);
            var resultTwo = _gameEngine.InviteFriend(friendTwoId);
            var resultThree = _gameEngine.InviteFriend(friendThreeId);

            //Assert
            Assert.AreEqual(expectedResult, resultOne);
            Assert.AreEqual(expectedResult, resultTwo);
            Assert.AreEqual(expectedResult, resultThree);

            _commonGameNetworkControl.Verify(
                x => x.InviteFriendToMatch(It.IsAny<Guid>(), friendOneId, It.IsAny<Guid>()), Times.Once());
            _commonGameNetworkControl.Verify(
                x => x.InviteFriendToMatch(It.IsAny<Guid>(), friendTwoId, It.IsAny<Guid>(), It.IsAny<Guid>()),
                Times.Once());
            _commonGameNetworkControl.Verify(
                x => x.InviteFriendToMatch(It.IsAny<Guid>(), friendThreeId, It.IsAny<Guid>(), It.IsAny<Guid>()),
                Times.Once());
        }
    }
}
