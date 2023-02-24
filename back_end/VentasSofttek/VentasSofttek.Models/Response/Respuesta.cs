using System;
using System.Collections.Generic;
using System.Text;

namespace VentasSofttek.Models.Response
{
    public class Respuesta
    {
        public Respuesta()
        {
            data=new MUserResponse();
        }
        public string Mensaje { get; set; }
        public int Exito { get; set; }
        public MUserResponse data { get; set; }
    }
}
