using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SystemDAL.Attributes.CustomValidation;

namespace SystemBLL.DTO.Knowledge
{
    public class FullKnowledge 
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [CheckCapitalized]
        [MinLength(5), MaxLength(50)]
        public string Title{ get; set; }
        [Required]
        [CheckCapitalized]
        [MinLength(100)]
        public string Description{ get; set; }
        public string UserId { get; set; }
        [Required]
        public IEnumerable<AreaRating> AreaRating { get; set; }
    }
}
