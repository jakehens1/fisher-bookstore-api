using System;

namespace Fisher.Bookstore.Api.Models
{

    public class Author
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Hometown { get; set; }

        public DateTime DOB { get; set; }

        public int noOfBooks { get; set; }
        
        public string Awards { get; set; }
    }
}