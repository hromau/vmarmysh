using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vmarmysh.Services;

namespace vmarmysh.API.Controllers;

[ApiController]
public class UserTreeController : Controller
{
    private readonly IReadOnlyDbContext _readOnlyDbContext;

    public UserTreeController(IReadOnlyDbContext readOnlyDbContext)
    {
        _readOnlyDbContext = readOnlyDbContext;
    }

    [HttpPost("/api.user.tree.get")]
    public async Task<IActionResult> Get([FromQuery] string treeName)
    {
        var result = await _readOnlyDbContext.Trees.FirstOrDefaultAsync(x => x.Name == treeName);
        return Ok(result);
    }
}