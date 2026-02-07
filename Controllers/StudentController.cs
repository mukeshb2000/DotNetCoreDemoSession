using CurdOperationEntityFramework.Data;
using CurdOperationEntityFramework.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CurdOperationEntityFramework.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext Dbcontext)
        {
            this._dbContext = Dbcontext;
        }
        //ApplicationDbContext _Context = new ApplicationDbContext();
        //Test Demo

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var StudentList = _dbContext.tblStudents.ToList();
                return View(StudentList);
            }
            catch(Exception ex)
            {
                return View();
            }
          
          
        }

        [HttpGet]

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Student objstudent)
        {
            _dbContext.tblStudents.Add(objstudent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid Id) 
        {
            var GetStudentDetails = _dbContext.tblStudents.Find(Id);
            return PartialView(GetStudentDetails);
        }

        [HttpPost]

        public IActionResult Edit(Student objstudent) 
        {
            _dbContext.tblStudents.Update(objstudent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        
        }

        [HttpDelete]

        public IActionResult Delete(Student objStudent) 
        {
            _dbContext.tblStudents.Remove(objStudent);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        
        }
    }
}
