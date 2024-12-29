using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow
{
    public interface IVoteService
    {
        public void VoteQuestion(Question question);
        public void VoteAnswer(Answer answer);
        public void VoteComment(Comment comment);
    }
}
