using System.ComponentModel.DataAnnotations;

namespace lesson2_hw.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad yazilmalidir!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description yazilmalidir!")]
        public string Description { get; set; }
        public int Pirce { get; set; }
        public int Discount { get; set; }
    }
}
