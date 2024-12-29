namespace StackOverflow
{
    public interface ISearchService
    {
        public void searchbyKeywords(string keywords);
        public void searchbyTags(string tags);
    }
}
