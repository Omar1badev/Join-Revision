using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuickRevision.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QuickRevision.Controllers;
[Route("api/[controller]")]
[ApiController]
public class tryController(AppDbContext context) : ControllerBase
{
    private readonly AppDbContext context = context;



    [HttpGet("Inner/{Join}")]
    public IActionResult Get()
    {
        var data = context.Students.Join(

           context.Dep,
              student => student.Id,
                dep => dep.StudentId,
                (student, dep) => new
                {
                    StudentId = student.Id,
                    StudentName = student.Name,
                    DepName = dep.Name,
                    student.DepartmentId
                }

            ).Join(
               context.Departments,
                student => student.DepartmentId,
                Depart => Depart.Id,
                (student, Department) => new
                {
                    StudentId = student.StudentId,
                    StudentName = student.StudentName,
                    DepName = student.DepName,
                    DepartmentName = Department.Name
                }

            );

        return Ok(data);
    }





    [HttpGet("inner/{Join}/WithLinq")]
    public IActionResult Getinner()
    {
        var data = (from student in context.Students
                   join dep in context.Dep on student.Id equals dep.StudentId
                   join Department in context.Departments on student.DepartmentId equals Department.Id
                   select new
                   {
                       StudentId = student.Id,
                       StudentName = student.Name,
                       DepName = dep.Name,
                       DepartmentName = Department.Name
                   }).ToList();
        return Ok(data);
    }





    [HttpGet("left/{Join}/WithLinq")]
    public IActionResult Getleftwithlinq()
    {
        var data = (from student in context.Students
                    join dep in context.Dep 
                    on student.Id equals dep.StudentId
                    join Departmen in context.Departments 
                    on student.DepartmentId equals Departmen.Id into temp
                    from an in temp.DefaultIfEmpty()
                    select new
                    {
                        StudentId = student.Id,
                        StudentName = student.Name,
                        DepName = dep.Name,
                        DepartmentName = temp.FirstOrDefault()!.Name
                    }).ToList();
        return Ok(data);
    }






    [HttpGet("Left/{Join}")]
    public IActionResult Getall()
    {
        var data = context.Students.Join(

           context.Dep,
              student => student.Id,
                dep => dep.StudentId,
                (student, dep) => new
                {
                    StudentId = student.Id,
                    StudentName = student.Name,
                    DepName = dep.Name,
                    student.DepartmentId
                }

            ).GroupJoin(
               context.Departments,
                student => student.DepartmentId,
                Depart => Depart.Id,
                (student, Department) => new
                {
                    student,
                    Department
                }

            ).SelectMany(
            b => b.Department.DefaultIfEmpty(),
            (b, n) => new
            {
                b.student.StudentId,
                Department = n
            }

            );

        return Ok(data);
    }





    [HttpGet("Eager/{Laudding}")]
    public IActionResult GetEager()
    {
        var data = context.Departments
            .Include(x => x.Students.Where(i => i.Id > 50))
            .ThenInclude(i => i.devs.Where(i => i.Id < 50))
            .Where(i => i.Id > 50)
            .ToList();

        return Ok(data);
    }




    [HttpGet("Eager/{Laudding}/asSplitQuery")]
    public IActionResult GetEagerSplit()
    {
        var data = context.Departments
            .Include(x => x.Students.Where(i => i.Id > 50))
            .AsSplitQuery()
            .ToList();

        return Ok(data);
    }





    [HttpGet("Explicit/{Laudding}")]
    public IActionResult GetExplicite()
    {
        var data = context.Departments
            .SingleOrDefault(i => i.Id == 10);


        context.Entry(data).Collection(x => x!.Students).Query().Where(i => i.Id > 30).ToList();

        return Ok(data);


    }






    [HttpGet("Explicit/{Laudding}/Refrence-NOCollection")]
    public IActionResult GetExpliciteRefrence()
    {
        var ata = context.Students
            .SingleOrDefault(i => i.Id == 10);


        context.Entry(ata).Reference(x => x!.Dep).Load();

        return Ok(ata);
    }





    [HttpGet("Lazy-Loading")]
    public IActionResult GetLazyLoading()
    {
        var data = context.Students.SingleOrDefault(i => i.Id == 10);
        //download entityframeworkcore.proxies and
        //make all the entities relations virtual and
        //uselazyloadingproxies before UseSqlServer
        //to enable lazy loading
        return Ok(data);
    }






}
