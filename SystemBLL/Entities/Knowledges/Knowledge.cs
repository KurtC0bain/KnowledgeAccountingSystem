
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SystemDAL.Administration.Account.Models;
using static SystemDAL.Attributes.CustomValidation;


namespace SystemDAL.Entities.Knowledges
{
    public class Knowledge
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(50)]
        [CheckCapitalized]
        public string Title { get; set; }

        [Required]
        [MinLength(100), MaxLength(500)]
        [CheckCapitalized]
        public string Description { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public ICollection<KnowledgeArea> Areas { get; set; }
        private User User { get; set; }
    }
}
