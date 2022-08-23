using DevIO.UI.Site.Data;
using DevIO.UI.Site.Model;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Danilo",
                DataNascimento = DateTime.Now,
                Email = "danilo.silva@msn.com"
            };

            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            var aluno2 = _contexto.Alunos.Find(aluno.Id);

            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "danilo.silva@msn.com");

            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Danilo");

            aluno.Nome = "João";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno);

            return View("_Layout");
        }
    }
}
