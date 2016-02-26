using System.ComponentModel.DataAnnotations;

namespace FSManage.Models
{
    public class UType
    {
        public UType() { }
        public UType(int id)
        {
            this.Id = id;
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}