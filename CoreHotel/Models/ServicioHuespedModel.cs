using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreHotel.Models
{
    public class ServicioHuespedModel
    {
        [Required]
        public int Id_servicio { get; set; }
        [ForeignKey("Id_servicio")]
        public ServicioModel ServicioModel { get; set; }

        [Required]
        public int Id_Huesped{ get; set; }
        [ForeignKey("Id_Huesped")]
        public HuespedModel HuespedModel { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Created_at { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Updated_at { get; set; }
    }
}
