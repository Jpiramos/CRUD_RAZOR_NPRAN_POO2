using Academico.Data;
using Academico.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Academico.Controllers
{
    public class CursoDisciplinaController : Controller
    {
        private readonly AcademicoContext _context;

        public CursoDisciplinaController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: CursoDisciplina
        public async Task<IActionResult> Index()
        {
            var cursoDisciplinas = await _context.CursosDisciplinas
                .Include(cd => cd.Curso)
                .Include(cd => cd.Disciplina)
                .ToListAsync();
            return View(cursoDisciplinas);
        }

        // GET: CursoDisciplina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoDisciplina = await _context.CursosDisciplinas
                .Include(cd => cd.Curso)
                .Include(cd => cd.Disciplina)
                .FirstOrDefaultAsync(cd => cd.CursoId == id);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // GET: CursoDisciplina/Create
        public IActionResult Create()
        {
            ViewBag.CursoID = new SelectList(_context.Cursos, "Id", "Nome");
            ViewBag.DisciplinaID = new SelectList(_context.Disciplinas, "DisciplinaID", "Nome");
            return View();
        }

        public async Task<IActionResult> AddToAnotherCourse(int disciplinaId, int cursoId, int cargaHoraria)
        {
            var existingCursoDisciplina = await _context.CursosDisciplinas
            .FirstOrDefaultAsync(cd => cd.DisciplinaId == disciplinaId && cd.CursoId == cursoId);

            if (existingCursoDisciplina != null)
            {
                // The combination of disciplinaId and cursoId already exists, update the carga horaria
                existingCursoDisciplina.CargaHoraria = cargaHoraria;
            }
            else
            {
                // The combination of disciplinaId and cursoId does not exist, create a new CursoDisciplina
                var cursoDisciplina = new CursoDisciplina
                {
                    DisciplinaId = disciplinaId,
                    CursoId = cursoId,
                    CargaHoraria = cargaHoraria
                };
                _context.Add(cursoDisciplina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // POST: CursoDisciplina/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DisciplinaID,CursoID,CargaHoraria")] CursoDisciplina cursoDisciplina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cursoDisciplina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CursoID = new SelectList(_context.Cursos, "Id", "Nome", cursoDisciplina.CursoId);
            ViewBag.DisciplinaID = new SelectList(_context.Disciplinas, "DisciplinaID", "Nome", cursoDisciplina.DisciplinaId);
            return View(cursoDisciplina);
        }

        // GET: CursoDisciplina/Delete/5
        [Route("CursoDisciplina/Delete/{disciplinaId:long}/{cursoId:int}")]
        public async Task<IActionResult> Delete(int cursoId, long disciplinaId)
        {
           
            var cursoDisciplina = await _context.CursosDisciplinas
                .Include(cd => cd.Disciplina)
                .Include(cd => cd.Curso)
                .FirstOrDefaultAsync(cd => cd.DisciplinaId == disciplinaId && cd.CursoId == cursoId);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            return View(cursoDisciplina);
        }

        // POST: CursoDisciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("CursoDisciplina/DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long disciplinaId, int cursoId)
        {
            var cursoDisciplina = await _context.CursosDisciplinas.FirstOrDefaultAsync(cd => cd.DisciplinaId == disciplinaId && cd.CursoId == cursoId);
            if (cursoDisciplina == null)
            {
                return NotFound();
            }

            _context.CursosDisciplinas.Remove(cursoDisciplina);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
