using System.ComponentModel.DataAnnotations;

namespace Pastebin.Models.ViewModels
{
    public class PasteCreateViewModel
    {
        [Required]
        [MaxLength(250)]
        public string Message { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string OptionExpirationPaste { get; set; }

        public string OptionExposurePaste { get; set; } 

        public string? PasswordPaste { get; set; }
    }
}
