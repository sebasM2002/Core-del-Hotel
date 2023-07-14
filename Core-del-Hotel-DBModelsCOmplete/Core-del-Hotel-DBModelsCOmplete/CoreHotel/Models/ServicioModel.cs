using System.ComponentModel.DataAnnotations;

namespace CoreHotel.Models
{
    public class ServicioModel
    {
        [Key]   
        public int Id_servicio { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.Text)]
        public string Descripcion { get; set;}

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Precio { get; set; }

        public bool? Is_deleted { get; set; }

        [Required]
        public string Created_at { get; set; }

        public string? Updated_at { get; set; }


    }
}
