using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static SystemDAL.Attributes.CustomValidation;

namespace SystemDAL.Entities.Knowledges
{
    public class Knowledge
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MinLength(5), MaxLength(20)]
        [CheckCapitalized]
        public string Title { get; set; }


        [Required]
        public Area Area { get; set; }


        [Required]
        [MinLength(100), MaxLength(500)]
        [CheckCapitalized]
        public string Description { get; set; }


        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

    }
}
