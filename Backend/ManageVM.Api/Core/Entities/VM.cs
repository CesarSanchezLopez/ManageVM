using System.ComponentModel.DataAnnotations;

namespace ManageVM.Api.Core.Entities
{
    public class VM
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cores { get; set; }
        public int RAM { get; set; }
        public int Disk { get; set; }
        public string OperatingSystem { get; set; }
        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int OwnerId { get; set; }
    }
}
