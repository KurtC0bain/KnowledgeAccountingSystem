using System.Collections.Generic;

namespace SystemDAL.DTO.Knowledge
{
    public class FullKnowledge 
    {
        public int Id { get; set; }
        public string Title{ get; set; }
        public string Description{ get; set; }
        public string UserId { get; set; }
        public IEnumerable<AreaRating> AreaRating { get; set; }
    }
}
