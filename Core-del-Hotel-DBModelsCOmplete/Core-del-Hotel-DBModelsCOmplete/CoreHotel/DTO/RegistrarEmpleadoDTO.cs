﻿namespace CoreHotel.DTO
{
    public class RegistrarEmpleadoDTO
    {
        public string email { get; set; }
        public string password { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public decimal Sueldo { get; set; }
    }
}
