﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsEntidades
{
    public class SesionDto
    {
        public int Idusuario { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public Boolean Administrador { get; set; }
        public string Token { get; set; }
    }
}
