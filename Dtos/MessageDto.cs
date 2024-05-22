using System.ComponentModel.DataAnnotations;

namespace Chat_App.Dtos
{
    public class MessageDto
    {
        [Required]
        public string From {  get; set; }

        public string To { get; set; }

        [Required]
        public string Content { get; set; }

    }
}
