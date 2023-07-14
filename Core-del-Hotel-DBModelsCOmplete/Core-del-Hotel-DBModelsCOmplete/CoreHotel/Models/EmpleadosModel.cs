using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class EmpleadosModel
    {
        [Key]
        public int Id_Empleados { get; set; }

        [MaxLength(55)]
        [Required]
        [DataType(DataType.Text)]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Direccion { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Sueldo { get; set; }

        public string Id_Usuario { get; set; }

        public bool? Is_deleted { get; set; }

        [Required]
        public string Created_at { get; set; }

        public string? Updated_at { get; set; }




    }
}
