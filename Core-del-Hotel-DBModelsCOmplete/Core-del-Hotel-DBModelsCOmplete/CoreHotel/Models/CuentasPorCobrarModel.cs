using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class CuentasPorCobrarModel
    {
        [Key]
        public int id_cuenta { get; set; }
        public int id_factura { get; set; }
        [ForeignKey("id_factura")]
        public FacturaModel facturaModel { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Fecha_vencimiento { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public decimal balance { get; set; }

        public bool? is_deleted { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string created_at { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string? updated_at { get; set; }

    }
}
