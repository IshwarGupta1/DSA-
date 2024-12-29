using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow
{
    public class Answer : Sentence
    {
        public string answerId { get; set; }
        public IList<Comment> comments { get; set; } = new List<Comment>();
        public Answer(string answerId, string sentence, int voteCount) : base(answerId, sentence, voteCount)
        {
            this.answerId = answerId;
        }
    }
}
