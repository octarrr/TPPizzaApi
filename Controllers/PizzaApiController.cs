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

    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {

    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {

    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {

    }

    [HttpDelete("{id}")]
    public IActionResult DeleteByID(int id)
    {

    }
}
