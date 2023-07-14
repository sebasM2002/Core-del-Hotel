namespace CoreHotel.DTO
{
    public class ReservacionHabitacionDTO
    {
        public string Fecha_Entrada { get; set; }
        public string Fecha_Salida { get; set; }
        public int Cantidad { get; set; }
        public string descripcion { get; set; }
        public int Id_Huesped { get; set; }
    }
}
