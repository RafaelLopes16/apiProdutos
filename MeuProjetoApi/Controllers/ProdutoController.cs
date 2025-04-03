using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuProjetoApi.Models;

namespace MeuProjetoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/produto
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<TAB_Produtos>>> GetProdutos()
        {
            Console.WriteLine("testes");
            return await _context.tab_produtos.ToListAsync();
        }

        // GET: api/produto/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TAB_Produtos>> GetProduto(int id)
        {
            var produto = await _context.tab_produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        // POST: api/produto
        [HttpPost]
        public async Task<ActionResult<TAB_Produtos>> PostProduto(TAB_Produtos produto)
        {
            _context.tab_produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.id }, produto);
        }

        // PUT: api/produto/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, TAB_Produtos produto)
        {
            if (id != produto.id)
            {
                return BadRequest();
            }

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.tab_produtos.Any(e => e.id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/produto/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.tab_produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.tab_produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
