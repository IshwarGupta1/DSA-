namespace EFcorePractice.Service
{
    public interface IBookService
    {
        public void addBook(Book book);
        public void updateBook(string bookName, int id);
        public void deleteBook(Book book);
        public void findBook(int id);
    }
}
