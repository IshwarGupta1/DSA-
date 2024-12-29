using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow
{
    public class Comment : Sentence
    {
        public string commentId { get; set; }
        public Comment(string commentId, string sentence, int voteCount) : base(commentId, sentence, voteCount)
        {
            this.commentId = commentId;
        }
    }
}
