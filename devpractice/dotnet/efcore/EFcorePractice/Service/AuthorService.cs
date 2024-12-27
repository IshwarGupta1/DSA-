namespace EFcorePractice.Service
{
    public class AuthorService:IAuthorService
    {
        private readonly DataContext _context;
        public AuthorService(DataContext context)
        {
            _context = context;
        }

        public void addAuthor(Author author)
        {
           _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void deleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            _context.SaveChanges();
        }

        public void findAuthor(Author author)
        {
            var newauthor = _context.Authors.FirstOrDefault(x=>x.Id==author.Id);
        }

        public void updateAuthor(string authorname, int id)
        {
            var newauthor = _context.Authors.FirstOrDefault(x => x.Id == id);
            newauthor.Name = authorname;
            _context.SaveChanges();
        }
    }
}
