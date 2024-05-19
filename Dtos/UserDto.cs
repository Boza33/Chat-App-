using System.ComponentModel.DataAnnotations;

namespace Chat_App.Dtos
{
    public class UserDto
    {
        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Ime mora imati minimum {2} i maksimum {1} karaktera.")]
        public string Name { get; set; }
    }
}
