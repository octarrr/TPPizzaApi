using Microsoft.AspNetCore.Mvc;
using PizzaApi.Models;

namespace PizzaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaApiController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        List<Pizza> l;

        l = BD.GetAll();
        return Ok(l);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Pizza p = BD.GetById(id);
        return p == null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        int n;
        n = BD.Create(pizza);
        return CreatedAtAction(nameof(Create), pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if(id != pizza.Id){
            return BadRequest();
        }
        if(BD.GetById(id) == null){
            return NotFound();
        }
        return BD.Update(pizza) > 0 ? Ok(pizza) : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteByID(int id)
    {
        int n;
        Pizza p;
        p = BD.GetById(id);
        if(p == null){
            return NotFound();
        }
        n = BD.DeleteByID(id);
        if(n > 0){
            return Ok(p);
        }else{
            return NotFound();
        }
    }
}
