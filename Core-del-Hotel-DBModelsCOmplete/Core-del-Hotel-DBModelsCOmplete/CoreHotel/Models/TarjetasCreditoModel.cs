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
        [ForeignKey("Id_huesped")]
        public HuespedModel huespedModel { get; set; }

        [Required]
        [DataType(DataType.CreditCard)]
        public int numero { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yy-MM}", ApplyFormatInEditMode = true)]
        public DateTime FechaVencimiento { get; set; }

        [Required]
        [MaxLength(4)]
        public int cvv { get; set; }

        [Required]
        [MaxLength(55)]
        [DataType(DataType.Text)]
        public string Nombre_titular { get; set; }

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
