namespace EFcorePractice.Service
{
    public interface IAuthorService
    {
        public void addAuthor(Author author);
        public void updateAuthor(string authorname, int id);
        public void deleteAuthor(Author author);
        public void findAuthor(Author author);
    }
}
