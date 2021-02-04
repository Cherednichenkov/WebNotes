using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicatioNotes.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameNote { get; set; }
        public string Tag { get; set; }
        public DateTime Date { get; set; }
        public DateTime Notification { get; set; }
    }
}
