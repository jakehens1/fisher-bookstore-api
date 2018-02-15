using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly BookstoreContext db;

        public AuthorsController(BookstoreContext db)
        {
            this.db = db;
            this.db.SaveChanges();
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Authors);
        }

        [HttpGet("{ID}", Name="GetAuthor")]
        public IActionResult GetById(int ID)
        {
            var author = db.Authors.Find(ID);

            if(author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Author author)
        {
            if(author == null)
            {
                return BadRequest();
            }

            this.db.Authors.Add(author);
            this.db.SaveChanges();

            return CreatedAtRoute("GetAuthor", new { ID = author.ID }, author);
        }

        [HttpPut("{ID}")]
        public IActionResult Put(int ID, [FromBody]Author newAuthor)
        {
            if (newAuthor == null || newAuthor.ID != ID)
            {
                return BadRequest();
            }
            var currentAuthor = this.db.Authors.FirstOrDefault(x => x.ID == ID);

            if (currentAuthor == null)
            {
                return NotFound();
            }

            currentAuthor.Name = newAuthor.Name;
            currentAuthor.Hometown = newAuthor.Hometown;
            currentAuthor.DOB = newAuthor.DOB;
            currentAuthor.Awards = newAuthor.Awards;
            currentAuthor.noOfBooks = newAuthor.noOfBooks;

            this.db.Authors.Update(currentAuthor);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{ID}")]
        public IActionResult Delete(int ID)
        {
            var author = this.db.Authors.FirstOrDefault(x => x.ID == ID);

            if (author == null)
            {
                return NotFound();
            }

            this.db.Authors.Remove(author);
            this.db.SaveChanges();

            return NoContent();
        }
    }
}