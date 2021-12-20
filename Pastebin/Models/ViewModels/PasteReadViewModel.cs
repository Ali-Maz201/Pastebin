using System.ComponentModel.DataAnnotations;

namespace Pastebin.Models.ViewModels
{
    public class PasteReadViewModel
    {
        
        public string Message { get; set; }

        public string Title { get; set; }

        public string? PasswordPaste { get; set; }

        public string PasteCode { get; set; }

        public DateTime ExpirationTime { get; set; }

        public DateTime CreationTimeOfPaste { get; set; }
    }
}
