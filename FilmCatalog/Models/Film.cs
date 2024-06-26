﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmCatalog.Models
{
    public class Film
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Назва фільму обов'язкова")]
        [StringLength(200, ErrorMessage = "Назва фільму повинна містити не більше 200 символів")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Режисер фільму обов'язковий")]
        [StringLength(200, ErrorMessage = "Режисер фільму повинен містити не більше 200 символів")]
        public string Director { get; set; }

        [Required(ErrorMessage = "Дата виходу фільму обов'язкова")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }        
    }
}