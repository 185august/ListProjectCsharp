using System.Runtime.InteropServices.JavaScript;
using Microsoft.AspNetCore.Mvc;

namespace ListProjectApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListItemController : ControllerBase
{
    List<string> item = ["Kake", "buy now"];
    [HttpGet]
    public ActionResult GetItem()
    {
        if (!item.Any())
            return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public ActionResult UpdateItem(string newItem)
    {
        item.Add(newItem);
        if (item.Last() == newItem)
        {
            return Ok(newItem);
        }
        return NotFound();
    }
}