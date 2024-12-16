﻿using System.ComponentModel.DataAnnotations.Schema;

namespace yenideneme.Models
{
    [Table("Users")]

    public class Users
    {
        public long Id { get; set; }
        public string? Firstname { get; set; }

        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Status { get; set; }

    }
}
