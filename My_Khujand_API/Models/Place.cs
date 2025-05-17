namespace My_Khujand_API.Models
{
    public class Place
    {
        public int? Id { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Description { get; set; }
    }
}
