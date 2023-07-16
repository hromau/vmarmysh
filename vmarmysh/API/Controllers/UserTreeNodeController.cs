using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vmarmysh.Store;

namespace vmarmysh.Controllers;

[ApiController]
public class UserTreeNodeController : Controller
{
    private readonly DbSet<Tree> _trees;
    private readonly DbSet<Node> _nodes;

    public UserTreeNodeController(ApplicationDbContext dbContext)
    {
        _trees = dbContext.Set<Tree>();
        _nodes = dbContext.Set<Node>();
    }

    [HttpPost("/api.user.tree.node.create")]
    public async Task<IActionResult> Create([FromQuery] string treeName, [FromQuery] int? parentNodeId,
        [FromQuery] string nodeName)
    {
        var tree = await _trees.FirstOrDefaultAsync(x => x.Name == treeName);
        tree.Nodes.Add(new Node()
        {
            Name = nodeName,
            ParentNodeId = parentNodeId
        });
        _trees.Update(tree);

        return NoContent();
    }

    [HttpPost("/api.user.tree.node.delete")]
    public async Task<IActionResult> Delete([FromQuery] string treeName, [FromQuery] int nodeId)
    {
       var node = await _nodes.Include(x => x.Tree).Where(x => x.Tree.Name == treeName && x.Id == nodeId).FirstOrDefaultAsync();
       _nodes.Remove(node);
       
        return NoContent();
    }

    [HttpPost("/api.user.tree.node.rename")]
    public async Task<IActionResult> Rename([FromQuery] string treeName, [FromQuery] int nodeId,
        [FromQuery] string newNodeName)
    {
        var entity = await _nodes.SingleOrDefaultAsync(x => x.Id == nodeId && x.Name == treeName);
        entity.Name = newNodeName;
        _nodes.Update(entity);
        return Ok(entity);
    }
}