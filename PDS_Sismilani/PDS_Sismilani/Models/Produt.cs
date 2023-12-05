﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDS_Sismilani.Models
{
    internal class Produt
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string marca { get; set; }
        public int quantidade { get; set; }
        public string tipo { get; set; }
        public DateTime? validade { get; set; }
        public double valor { get; set; }
        public int idFor { get; set; }
        public int idEst { get; set; }
    }
}
