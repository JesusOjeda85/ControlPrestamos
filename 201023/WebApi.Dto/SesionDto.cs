﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Dto
{
    public class SesionDto
    {
        public int Idusuario { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public bool Administrador { get; set; }
    }
}
