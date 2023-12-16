using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Patterns;
using Microsoft.EntityFrameworkCore;
using NetApp.Data;
using NetApp.Models;

namespace NetApp.Controllers;

public class TodoController : Controller
{
    private NetAppDbContext _context;

    public TodoController(NetAppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("todo")]
    public IActionResult Index(){
        var items = _context.TodoItems.ToList();
        ViewBag.Items = items;
        return View("Views/Todo/Index.cshtml");
    }    

    [HttpPost]
    [Route("todo/save")]
    public IActionResult Save(String name){
        TodoItem item = new TodoItem(name);
        _context.TodoItems.Add(item);
        _context.SaveChanges();
        return Redirect("/todo");
    }

    [Route("todo/update/{id:int}")]
    public IActionResult UpdateIndex(int id){
        ViewBag.Item = _context.TodoItems.AsNoTracking().Single(i => i.Id == id);
        return View("Views/Todo/Update.cshtml");
    }

    [HttpPost]
    [Route("todo/update")]
    public JsonResult Update(int id, String name, DateTime time, bool is_done){
        var item = _context.TodoItems.AsNoTracking().Single(qi => qi.Id == id);
        item.Name = name;
        item.IsDone = is_done;
        item.CreatedAt = time;
        _context.TodoItems.Update(item);
       _context.SaveChanges();

       var result = new {StatusCode = 200, Redirect = "/todo"};
        return Json(result);
    }

    [Route("todo/delete/{id:int}")]
    public IActionResult Delete(int id){
        var Item = _context.TodoItems.Single(i => i.Id == id);
        _context.TodoItems.Remove(Item);
        _context.SaveChanges();
        return Redirect("/todo");
    }
}