using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetworkInterfaces;

namespace TicTacToe.Core
{
    public class GameEngine
    {
        private ICommonGameNetworkControl _commonGameNetworkControl;
        private Guid _matchId;

        public GameEngine(ICommonGameNetworkControl commonGameNetworkControl)
        {
            _commonGameNetworkControl = commonGameNetworkControl;
        }
       
        public string GetWinner(string[,] board)
        {
            return " ";
        }

        public Guid Login(string username, string password)
        {
            var sessionId = _commonGameNetworkControl.Login(username, password);
            return sessionId;
        }

        public Guid InviteFriend(Guid friendId)
        {
            if (_matchId != Guid.Empty)
            {
                _matchId = _commonGameNetworkControl.InviteFriendToMatch(Guid.NewGuid(), friendId, Guid.NewGuid(), Guid.NewGuid());
            }
            else
            {
                _matchId = _commonGameNetworkControl.InviteFriendToMatch(Guid.NewGuid(), friendId, Guid.NewGuid());
            }

            return _matchId;            
        }
    }
}
