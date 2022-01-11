using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPractise11december2022.Models
{
    public class Featured
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IconLink { get; set; }
        public bool Isdeleted { get; set; }
    }
}
