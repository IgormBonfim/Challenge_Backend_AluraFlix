﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Backend_AluraFlix.Dominio.Genericos.Entidades
{
    public class ListaPaginada<T> where T : class
    {
        public int Pagina { get; set; }
        public int Quantidade { get; set; }
        public int TotalPaginas { get; set; }
        public IList<T> Lista { get; set; }
    }
}
