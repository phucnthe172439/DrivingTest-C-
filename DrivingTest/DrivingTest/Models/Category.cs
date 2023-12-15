using System;
using System.Collections.Generic;

namespace DrivingTest.Models
{
    public partial class Category
    {
        public Category()
        {
            Quizzes = new HashSet<Quiz>();
            Results = new HashSet<Result>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
