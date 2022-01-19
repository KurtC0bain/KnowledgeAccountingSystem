using System.ComponentModel.DataAnnotations;

namespace SystemBLL.DTO.Knowledge
{
    public class AreaRating
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
