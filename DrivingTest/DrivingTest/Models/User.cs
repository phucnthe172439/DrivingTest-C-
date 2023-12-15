using System;
using System.Collections.Generic;

namespace DrivingTest.Models
{
    public partial class User
    {
        public User()
        {
            Results = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Roleid { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
