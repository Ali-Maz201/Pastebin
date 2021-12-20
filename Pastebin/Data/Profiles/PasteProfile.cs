using AutoMapper;
using Pastebin.Models;
using Pastebin.Models.ViewModels;

namespace Pastebin.Data.Profiles
{
    public class PasteProfile : Profile
    {
        public PasteProfile()
        {

            CreateMap<PasteCreateViewModel, Paste>();

            CreateMap<Paste, PasteReadViewModel>();


            CreateMap<PasteReadViewModel, Paste>();
              
        }
    }
}
