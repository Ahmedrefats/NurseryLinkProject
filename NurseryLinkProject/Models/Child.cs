using System;

namespace NurseryLink.Models
{
    public class Child
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? NurseryId { get; set; }
        public Nursery Nursery { get; set; }
        public int? ParentId { get; set; }
        public Parent Parent { get; set; }
    }
}
