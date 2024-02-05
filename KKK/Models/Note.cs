using System;
using System.ComponentModel.DataAnnotations;

namespace KKK.Models
{
    public class Note
    {
        [Key]
        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tytuł powinien mieć od 3 do 20 znaków.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Treść jest wymagana.")]
        [StringLength(2000, MinimumLength = 10, ErrorMessage = "Treść powinna mieć od 10 do 2000 znaków.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Data ważności jest wymagana.")]
        [DataType(DataType.DateTime, ErrorMessage = "Wprowadź poprawny format daty.")]
        public DateTime Deadline { get; set; }
    }
}
