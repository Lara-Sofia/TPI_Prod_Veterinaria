﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Veterinario : User
    {
        [Required]
        [MaxLength(5)]
        public int Matricula {  get; set; }
    }
}
