using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ClientsController(ApplicationDBContext context)
        {

            _context = context;
        }

        [HttpGet]
        public List<Client> Get()
        {
            //try
            //{
            //var users = _userAppService.GetUsers();
            return _context.Clients.OrderByDescending(c => c.Id).ToList();
            // return StatusCode(StatusCodes.Status500InternalServerError, "");
            //  }
            //catch (Exception ex)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            //}
        }



        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
           
            var cl = _context.Clients.Find(id);
            if (cl==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(cl);
            }

           
        }

        [HttpPost("{id}")]
        public IActionResult CreateClinet(ClientDto clientDto)
        {

            var client = new Client
            {
                FirstName = clientDto.FirstName,
                LatName = clientDto.LatName,
                Email = clientDto.Email,
                Phone = clientDto.Phone,
                Address = clientDto.Address,
                Status = clientDto.Status,
                CreatedAt = DateTime.Now

            };
            _context.Clients.Add(client);
            _context.SaveChanges();

            return Ok(client);


        }

        [HttpPost("{id}")]
        public IActionResult EditClient(int id,ClientDto clientDto)
        {
            var cl = _context.Clients.Find(id);
            if (cl == null)
            {
                return NotFound();
            }
           
            cl.FirstName = clientDto.FirstName;
            cl.LatName = clientDto.LatName;
            cl.Email = clientDto.Email;
            cl.Phone = clientDto.Phone;
            cl.Address = clientDto.Address;
            cl.Status = clientDto.Status;
            return Ok();
        }


        }
}
