using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ComputerRepairStore.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class RepairOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User Customer { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; } = DateTime.Now;

        public DateTime PlannedFinishDate { get; set; }

        public RepairStatus RepairStatus { get; set; }

        public bool Deleted { get; set; } = false;

        public User Employee { get; set; }

        public string EmployeeId { get; set; }

        public IList<string> Photos { get; set; } = new List<string>();
        public string CommentCancellation { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
    }
}