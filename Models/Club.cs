﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Interclub
{
    public class Club
    {       
        public  int Id { get; set; }
        public string Name { get; set; }  
        
 
        public List<Speler> Players { get; set; }

        public List<Team> Teams { get; set; }

    }
}
