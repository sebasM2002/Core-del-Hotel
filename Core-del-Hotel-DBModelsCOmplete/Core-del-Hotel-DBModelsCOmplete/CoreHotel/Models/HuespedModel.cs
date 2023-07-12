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
        public string Nombre { get; set; }

        [MaxLength(55)]
        [Required]
        public string Appelidos { get; set; }

        [Required]

        [MaxLength(15)]
        [DataType(DataType.PhoneNumber)]
        public int Telefono { get; set; }

        [Required]
        public string Id_Usuario { get; set; }
        [ForeignKey("Id_Usuario")]
        public IdentityUser User { get; set; }

        public int Id_Pais { get; set; }
        [ForeignKey("Id_Pais")]
        public PaisModel PaisModel { get; set; }

        public bool Is_deleted { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_at { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Updated_at { get; set; }
    }
}
