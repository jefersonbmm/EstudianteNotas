using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NOTASDEESTUDIANTE.Models
{
    public partial class NotasEstudiante
    {
        public int IdnotasEstudiantes { get; set; }
        public string? Carnet { get; set; }
        public string? Apellido { get; set; }
        public string? Nombre { get; set; }


        [Range(0,35)]
        public short? NotaIp { get; set; }

        [Range(0, 35)]
        public short? NotaIip { get; set; }

        [Range(0, 30)]
        public short? NotaSist { get; set; }

        [Range(0, 30)]
        public short? NotaProy { get; set; }
        public short? NotaFinal { get; set; }
    }
}
