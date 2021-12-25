using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static SystemDAL.Attributes.CustomValidation;

namespace SystemDAL.Entities.Knowledges
{
    public class Area
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(20)]
        [CheckCapitalized]
        public string Name { get; set; }

        public ICollection<KnowledgeArea> Knowledges { get; set; }
    }
}
