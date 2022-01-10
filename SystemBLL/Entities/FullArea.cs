using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDAL.Entities
{
    public class FullArea
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public int KnowledgeWritten { get; set; }
    }
}
