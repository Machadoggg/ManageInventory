using AutoMapper;
using ManageInventory.Models;

namespace ManageInventory.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookDetailDTO, Book>().ReverseMap();
            CreateMap<Book, BookDetailDTO>()
                //.ForMember(dest => dest.Isbn, opts => opts.MapFrom(src => src.Isbn))
                .ForMember(dest => dest.IdEditorial, opts => opts.MapFrom(src => src.IdEditorial))
                .ForMember(dest => dest.EditorialName, opts => opts.MapFrom(src => src.Editorial.Name))
                .ForMember(dest => dest.Title, opts => opts.MapFrom(src => src.Title))
                .ForMember(dest => dest.Sinopsis, opts => opts.MapFrom(src => src.Sinopsis))
                .ForMember(dest => dest.NumberPages, opts => opts.MapFrom(src => src.NumberPages))
                .ForMember(dest => dest.AuthorName, opts => opts.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.IdAuthor, opts => opts.MapFrom(src => src.Author.IdAuthor));

        }
    }
}
