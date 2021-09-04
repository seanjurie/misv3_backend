using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using misV3.Models;

namespace misV3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly AuthenticationContext _context;
        private readonly IConfiguration _configuration;

        public EmailsController(AuthenticationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Emails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emails>>> GetEmails()
        {
            return await _context.Emails.ToListAsync();
        }

        // GET: api/Emails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emails>> GetEmails(int id)
        {
            var emails = await _context.Emails.FindAsync(id);

            if (emails == null)
            {
                return NotFound();
            }

            return emails;
        }

        // PUT: api/Emails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public JsonResult Put(Emails email)
        {
            string query = @"
                    update dbo.Emails set 
                    EmailName = '" + email.EmailName + @"'
                    ,Emailem = '" + email.Emailem + @"'
                    ,EmailPass = '" + email.EmailPass + @"'
                    ,Department = '" + email.Department + @"'
                    ,Branch = '" + email.Branch + @"'
                    where EmailId = " + email.EmailId + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("IdentityConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        // POST: api/Emails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Emails>> PostEmails(Emails emails)
        {
            _context.Emails.Add(emails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmails", new { id = emails.EmailId }, emails);
        }

        // DELETE: api/Emails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Emails>> DeleteEmails(int id)
        {
            var emails = await _context.Emails.FindAsync(id);
            if (emails == null)
            {
                return NotFound();
            }

            _context.Emails.Remove(emails);
            await _context.SaveChangesAsync();

            return emails;
        }

        private bool EmailsExists(int id)
        {
            return _context.Emails.Any(e => e.EmailId == id);
        }
    }
}
