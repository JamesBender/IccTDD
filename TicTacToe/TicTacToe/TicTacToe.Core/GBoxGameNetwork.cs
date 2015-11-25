using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameNetworkInterfaces;

namespace TicTacToe.Core
{
    public class GBoxGameNetwork : ICommonGameNetworkControl
    {
        public Guid Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Logout(Guid sessionToken)
        {
            throw new NotImplementedException();
        }

        public int PostScoreToLeaderboard(Guid sessionToken, Guid gameToken, int score)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LeaderBoardEntry> GetLeaderBoard(Guid sessionToken, Guid gameToken, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetFriends(Guid sessionToken)
        {
            throw new NotImplementedException();
        }

        public bool AddFriends(Guid sessionToken, Guid playerId)
        {
            throw new NotImplementedException();
        }

        public Guid InviteFriendToMatch(Guid sessionToken, Guid invitedPlayerId, Guid gameToken)
        {
            throw new NotImplementedException();
        }

        public Guid InviteFriendToMatch(Guid sessionToken, Guid invitedPlayerId, Guid gameToken, Guid matchToken)
        {
            throw new NotImplementedException();
        }

        public Guid StartMatch(Guid sessionToken, Guid matchToken)
        {
            throw new NotImplementedException();
        }
    }
}
