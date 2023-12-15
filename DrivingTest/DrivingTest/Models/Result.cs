using System;
using System.Collections.Generic;

namespace DrivingTest.Models
{
    public partial class Result
    {
        public int Id { get; set; }
        public int? Userid { get; set; }
        public int Result1 { get; set; }
        public int Categoryid { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual User? User { get; set; }
    }
}
