using System;
using System.Collections.Generic;
using System.Text;

namespace VentasSofttek.Models.GesVentas
{
    public class Ventas
    {
      
        public int ID { get; set; }
        public string NumDocumento { get; set; }
        public string CodVendedor { get; set; }
        public string CodSucursal { get; set; }
        public string CodClient { get; set; }
        public double Total { get; set; }
        public string FechaVenta { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public string CodFormaPago { get; set; }
       

    }
}
