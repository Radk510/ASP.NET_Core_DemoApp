﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client_Side.Models
{
    public class Note
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]
        public string Text { get; set; }
    }
}
