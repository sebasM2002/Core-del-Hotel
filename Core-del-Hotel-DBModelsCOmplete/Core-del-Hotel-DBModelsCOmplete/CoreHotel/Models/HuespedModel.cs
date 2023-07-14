using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class HuespedModel
    {
        [Key]
        public int Id_Huesped  {get; set; }

        [MaxLength(55)]
        [Required]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [MaxLength(55)]
        [Required]
        [DataType(DataType.Text)]
        public string Apellidos { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        public string Id_Usuario { get; set; }

        public bool? Is_deleted { get; set; }

        [Required]
        public string Created_at { get; set; }

        public string? Updated_at { get; set; }
    }
}
