﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class DiagnosticoLinea
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreationDate { get; private set; } = DateTime.Now;

        [ForeignKey ("DiagnosticoId")]
        public int DiagnosticoId { get; set; }
        [JsonIgnore]
        public Diagnostico Diagnostico { get; set; }
    }
}
