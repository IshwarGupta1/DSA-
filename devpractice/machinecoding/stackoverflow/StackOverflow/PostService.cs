namespace StackOverflow
{
    public class PostService
    {
        private readonly IList<Question> _questions;
        public PostService(IList<Question> questions)
        {
            _questions = questions;
        }
        public void postAnswer(Question question, string answer)
        {
            var ansCount = question.answers.Count;
            var ansId = $"{question.questionId}_{ansCount+1}";
            var ans = new Answer(ansId, answer,0);
            question.answers.Add(ans);
            Console.WriteLine("answer submitted");
        }

        public void postQuestion(string ques) { 
            var quesCount = _questions.Count;
            var quesId = $"{quesCount + 1}";
            var question = new Question(quesId, ques,0);
            _questions.Add(question);
            Console.WriteLine("question has been posted");
        }

        public void postComment(string ansId, string comment)
        {
            foreach (var question in _questions)
            {
                foreach (var answer in question.answers)
                {
                    if (answer.answerId == ansId)
                    {
                        var commentId = $"{answer.answerId}_{answer.comments.Count + 1}";
                        var cmnt = new Comment(commentId, comment, 0);
                        answer.comments.Add(cmnt);
                        Console.WriteLine("Comment has been added");
                        return;
                    }
                }
            }
            Console.WriteLine("answer not found");
            return;
        }
        public void addTag(string quesId, string tag)
        {
            foreach (var question in _questions)
            {
                if (question.questionId == quesId)
                {
                    question.tags.Add(tag);
                    Console.WriteLine("tag added");
                    return;
                }
                    
            }
        }
        public void addKeyword(string quesId, string keyword)
        {
            foreach (var question in _questions)
            {
                if (question.questionId == quesId)
                {
                    question.keywords.Add(keyword);
                    Console.WriteLine("keyword added");
                    return;
                }

            }
        }
    }
}
