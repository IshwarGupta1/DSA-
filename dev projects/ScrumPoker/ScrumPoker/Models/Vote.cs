﻿using System.ComponentModel.DataAnnotations;

namespace ScrumPoker.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int playerId { get; set; }
        public int storyPoints { get; set; }
        public Role role { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
