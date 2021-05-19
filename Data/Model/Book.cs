using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name {get;set;}
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }
        

        //Navigation Properties
        public int? PublisherId { get; set; }

        public Publisher Publisher { get; set; }
        public List<BookAuthor> Book_Authors { get; set; }

    }
}
