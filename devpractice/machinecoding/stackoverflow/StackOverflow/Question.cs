using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow
{
    public class Question : Sentence
    {
        public string questionId { get; set; }
        public IList<string> tags { get; set; } = new List<string>();
        public IList<string> keywords { get; set; } = new List<string>();
        public IList<Answer> answers { get; set; } = new List<Answer>();
        public Question(string questionId, string sentence, int voteCount) : base(questionId, sentence, voteCount)
        {
            this.questionId = questionId;
        }


    }
}
