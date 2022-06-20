﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class ArticuloEtiqueta
    {
        [ForeignKey("Articulo")]
        public int Articulo_Id { get; set; }
        [ForeignKey("Etiqueta")]
        public int Etiqueta_ID { get; set; }

        public Articulo? Articulo { get; set; }  
        public Etiqueta? Etiqueta { get; set; }
    }
}
