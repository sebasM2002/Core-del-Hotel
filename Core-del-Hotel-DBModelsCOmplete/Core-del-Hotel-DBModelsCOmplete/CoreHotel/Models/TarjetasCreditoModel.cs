using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class TarjetasCreditoModel
    {
        [Key]
        public int Id_tarjeta { get; set; }

        [Required]
        public int Id_huesped { get; set; }

        [Required]
        [DataType(DataType.CreditCard)]
        public string numero { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public string FechaVencimiento { get; set; }

        [Required]
        public int cvv { get; set; }

        [Required]
        [MaxLength(55)]
        [DataType(DataType.Text)]
        public string Nombre_titular { get; set; }

        public bool? Is_deleted { get; set; }

        [Required]
        public string Created_at { get; set; }

        public string? Updated_at { get; set; }




    }
}
