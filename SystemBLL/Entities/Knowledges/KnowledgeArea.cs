using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        private Knowledge Knowledge { get; set; }
        private Area Area { get; set; }
    }
}
