using AutoMapper;
using BookCrud.DTOs;
using BookCrud.Models;

namespace BookCrud.Mapper
{
    public static class CategoryMapper
    {
        public static CategoryDTO MapToDTO(Category category)
        {
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Books = category.Books
            };
        }
    }
}
