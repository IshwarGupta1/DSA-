using System.ComponentModel.DataAnnotations;

namespace ScrumPoker.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string gameCode { get; set; } = string.Empty;
        public bool isVotingOpen { get; set; }
        public IList<Vote> votes { get; set; } = new List<Vote>();

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
