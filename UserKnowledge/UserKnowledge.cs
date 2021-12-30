using Administration.Account.Models;
using System;
using System.ComponentModel.DataAnnotations;
using SystemDAL.Entities.Knowledges;

namespace UserKnowledgeConnector
{
    public class UserKnowledge
    {
        [Key]
        public int Id { get; set; }
        public int KnowledgeId { get; set; }
        public string UserId { get; set; }

        public User Users { get; set; }
        public Knowledge Knowledges { get; set }
    }
}
