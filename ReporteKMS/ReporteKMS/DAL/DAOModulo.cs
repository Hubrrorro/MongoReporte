﻿using ReporteKMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReporteKMS.DAL
{
    public class DAOModulo : Conex<ModeloModulo>
    {
        public DAOModulo() : base("Modulo")
        {

        }
    }
}