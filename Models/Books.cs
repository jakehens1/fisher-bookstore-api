using System;

namespace Fisher.Bookstore.Api.Models
{

    public class Book
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public DateTime PublishDate { get; set; }

        public string Publisher { get; set; }
    }
}