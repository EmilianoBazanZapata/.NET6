namespace WebApi.Models
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime LastModified { get; set; }
        public bool SoftDelete { get; set; }
    }
}
