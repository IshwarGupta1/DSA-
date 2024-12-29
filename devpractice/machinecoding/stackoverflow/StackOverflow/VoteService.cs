namespace StackOverflow
{
    public class VoteService : IVoteService
    {
        public void VoteAnswer(Answer answer)
        {
            answer.voteCount++;
            Console.WriteLine("answer voted");
        }

        public void VoteComment(Comment comment)
        {
            comment.voteCount++;
            Console.WriteLine("comment voted");
        }

        public void VoteQuestion(Question question)
        {
            question.voteCount++;
            Console.WriteLine("question voted");
        }
    }
}
