using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class FacturaModel
    {
        [Key]
        public int Id_Factura{ get; set; }

        [Required]
        public int Id_Reservacion { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal Monto_total { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Fecha { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Metodo_de_pago { get; set; } = string.Empty;

        public bool? is_deleted { get; set; }

        [Required]
        public string created_at { get; set; }
        public string? updated_at { get; set; }


    }
}
