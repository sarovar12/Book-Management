﻿
using BookManagement.Domain.Enum;

namespace BookManagement.Domain.Entities
{
    public class Staff 
    {
        public Guid StaffId { get; set; } 
        public string Username {  get; set; }
        public string Password { get; set; }
        public StaffType StaffType { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateDeleted { get; set; }

    }
}
