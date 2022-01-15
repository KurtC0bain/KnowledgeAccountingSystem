using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemDAL.Entities.Knowledges
{
    public class KnowledgeArea
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Knowledge")]
        public int KnowledgeId { get; set; } 

        [ForeignKey("Area")]
        public int AreaId { get; set; } 

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        public Knowledge Knowledge { get; set; }
        public Area Area { get; set; }
    }
}
