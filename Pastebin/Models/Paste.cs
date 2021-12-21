using System.ComponentModel.DataAnnotations;

namespace Pastebin.Models
{
    public class Paste
    {
        [Key]
        public int PasteID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Message { get; set; }

        [Required]
        [MinLength(5)]
        public string Title { get; set; }

        public string? PasswordPaste { get; set; }

        public string OptionExpirationPaste { get; set; }

        public DateTime CreationTimeOfPaste { get; set; } = DateTime.Now;

        public DateTime? ExpirationTime { get; set; }

        public string PasteCode { get; set; }

        public string Exists { get; set; } = "true";


    }
}
