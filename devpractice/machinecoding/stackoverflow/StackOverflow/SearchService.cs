namespace StackOverflow
{
    public class SearchService : ISearchService
    {
        private readonly IList<Question> _questions;
        public SearchService(IList<Question> questions)
        {
            _questions = questions;
        }
    
        public void searchbyKeywords(string keywords)
        {
            foreach(var question in _questions)
            {
                if(question.keywords.Contains(keywords))
                {
                    Console.WriteLine($"question found : {question.questionId}");
                    return;
                }
            }
            Console.WriteLine("question not found");
        }

        public void searchbyTags(string tags)
        {
            foreach (var question in _questions)
            {
                if (question.tags.Contains(tags))
                {
                    Console.WriteLine($"question found : {question.questionId}");
                    return;
                }
            }
            Console.WriteLine("question not found");
        }
    }
}
