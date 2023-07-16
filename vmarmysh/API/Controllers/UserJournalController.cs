using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vmarmysh.API.Models;
using vmarmysh.Services;

namespace vmarmysh.API.Controllers;

[ApiController]
public class UserJournalController : Controller
{
    private readonly IReadOnlyDbContext _readOnlyDbContext;

    public UserJournalController(IReadOnlyDbContext readOnlyDbContext)
    {
        _readOnlyDbContext = readOnlyDbContext;
    }

    [HttpPost("/api.user.journal.getRange")]
    public async Task<IActionResult> GetRange([FromQuery] int skip, [FromQuery] int take, [FromBody] FilterModel filter)
    {

        var result = await _readOnlyDbContext.ExceptionLogs.Skip(skip).Take(take).Where(x => x.CreatedAt >= filter.From
            && x.CreatedAt <= filter.To && x.Text.Contains(filter.Search)).ToListAsync();
        return Ok(result);
    }

    [HttpPost("/api.user.journal.getSingle")]
    public async Task<IActionResult> GetSingle([FromQuery] int id)
    {
        var result = await _readOnlyDbContext.ExceptionLogs.FirstOrDefaultAsync(x => x.Id == id);
        return Ok(result);
    }
}