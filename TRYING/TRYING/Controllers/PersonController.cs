using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRYING.Models;

namespace TRYING.Controllers
{
    public class PersonController : Controller
    {
        private readonly AppDbContext _context;
        public PersonController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public async Task<IActionResult> Index()
        {
            var persons = await _context.persons.ToListAsync();
            return View(persons);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Person person)
        {
            await _context.persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(Guid id)
        {
            var person = await _context.persons.FindAsync(id);
            return View(person);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Person person)
        {
            var updatedPerson = await _context.persons.FindAsync(person.id);
            updatedPerson.name = person.name;
            updatedPerson.age = person.age;
            updatedPerson.description = person.description;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletedPErson = await _context.persons.FindAsync(id);
            return View(deletedPErson);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, int? num)
        {
            var deletedPerson = await _context.persons.FindAsync(id);
            if (deletedPerson == null)
                return NotFound("Invalid person id");
             _context.persons.Remove(deletedPerson);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
