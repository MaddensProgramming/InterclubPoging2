﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    public class Club
    {       
        public  int Id { get; set; }
        public string Name { get; set; }       
        public List<Speler> Spelers { get; set; }

    }
}