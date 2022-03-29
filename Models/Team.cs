﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bowler.Models
{
    public class Team
    {
        [Key]
        [Required]

        public int TeamID { get; set; }
        [Required]
        public string TeamName { get; set; }

        public int CaptainID { get; set; }
    }
}
