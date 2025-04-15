using AutoMapper;
using BookCrud.DTOs;
using BookCrud.Models;

namespace BookCrud.Mapper
{
    public static class BookMapper
    {
        public static BookDTO MapToDTO(Book book)
        {
            return new BookDTO
            {
                Id = book.Id,
                Author = book.Author,
                Category = book.Category,
                categoryId = book.categoryId,
                Price = book.Price,
                Title = book.Title
            };
        }
    }
}
