using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webapicontrollers.Controllers;

[ApiController]
[Route("department")]
public class DepartmentController : ControllerBase
{

    private readonly AppDbContext _db;

    public DepartmentController(AppDbContext db)
    {
        _db = db;        
    }

    [HttpGet(Name = "department")]
    public IActionResult GetDepartments()
    {
        var alldepts = _db.Departments.ToList<Employee>();
        if(alldepts == null){
            return NotFound();
        }
        return Ok(alldepts);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetEmployee(int id)
    {
        var e = _db.Find<Employee>(id);
        if(e == null){
            return NotFound();
        }
        return Ok(e);       
    }

    [HttpPost]
    public IActionResult AddEmployee(Employee e){
        _db.Add(e);
        _db.SaveChanges();
        return Created($"/employee/{e.Id}", e);
    }

    [HttpPut]
    public IActionResult UpdateEmployee(int id, [FromBody] Employee e){
        if(id != e.Id){
            return BadRequest();
        }
        if(_db.Find<Employee>(id) == null){
            return NotFound();            
        }
        _db.Entry(e).State = EntityState.Modified;
        _db.SaveChanges();
        return NoContent();
    }


    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployee(int id){
        var e = _db.Find<Employee>(id);
        if(e == null){
            return NotFound();
        }
        _db.Remove(e);
        _db.SaveChanges();
        return Ok();     
    }
















    







    
     
}
