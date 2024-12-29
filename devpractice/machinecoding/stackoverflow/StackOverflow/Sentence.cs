using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow
{
    public class Sentence
    {
        public string sentenceId { get; set; }
        public string sentence { get; set; }
        public int voteCount { get; set; }
        public Sentence(string sentenceId, string sentence, int voteCount)
        {
            this.sentenceId = sentenceId;
            this.sentence = sentence;
            this.voteCount = voteCount;
        }
    }
}
