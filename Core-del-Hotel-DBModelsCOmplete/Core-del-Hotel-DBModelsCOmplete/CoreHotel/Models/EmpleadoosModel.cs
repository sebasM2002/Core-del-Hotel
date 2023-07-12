using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class EmpleadoosModel
    {
        [Key]
        public int Id_Empleados { get; set; }

        [MaxLength(55)]
        [Required]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required]
        public int Id_Pais { get; set; }
        [ForeignKey("Id_Pais")]
        public PaisModel PaisModel { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }

        [MaxLength(15)]
        [Required]
        [DataType(DataType.PhoneNumber)]
        public int Telefono { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Correo_electronico { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Sueldo { get; set; }

        [Required]
        public string Id_Usuario { get; set; }

        [ForeignKey("Id_Usuario")]
        public IdentityUser User { get; set; }

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
