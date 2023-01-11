using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Phonebook.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Phone number")]
        [Required]
        [RegularExpression("(\\+?420)?(2[0-9]{2}|3[0-9]{2}|4[0-9]{2}|5[0-9]{2}|72[0-9]|73[0-9]|77[0-9]|60[1-8]|56[0-9]|70[2-5]|79[0-9])[0-9]{3}[0-9]{3}", ErrorMessage = "Enter Czech phone number")]
        public string PhoneNumber { get; set; }
    }
}
