using System;

namespace pustokbackend.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedData { get; set; }
        public DateTime? UpdatedData { get; set; }
    }
}
