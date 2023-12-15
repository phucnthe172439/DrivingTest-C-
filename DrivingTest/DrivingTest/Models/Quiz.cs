using System;
using System.Collections.Generic;

namespace DrivingTest.Models
{
    public partial class Quiz
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? A { get; set; } = null!;
        public string? B { get; set; } = null!;
        public string? C { get; set; }
        public string? D { get; set; }
        public string? Answer { get; set; } = null!;
        public bool? IsZeroPoint { get; set; }
        public int? Categoryid { get; set; }
        public string? AnswerChar { get; set; }

        public virtual Category Category { get; set; } = null!;
    }
}
