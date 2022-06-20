﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayFormat(ConvertEmptyStringToNull = true,NullDisplayText = "[NULL]")]
        public string? Nombre { get; set; }

        public List<Articulo>? Articulo { get; set; }
    }
}
