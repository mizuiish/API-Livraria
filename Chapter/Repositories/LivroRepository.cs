using Chapter.Contexts;
using Chapter.Models;

namespace Chapter.Repositories
{
    public class LivroRepository
    {
        private readonly SqlContext _context;
            
        //injeção de dependância
        public LivroRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

        //método para pesquisar livro pelo ID
        public Livro buscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastrar(Livro L)
        {
            _context.Livros.Add(L);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Livro L = _context.Livros.Find(id);
            _context.Livros.Remove(L);
            _context.SaveChanges();
        }

        public void Alterar(int id, Livro L)
        {
            Livro livroBuscado = _context.Livros.Find(id);

            if (livroBuscado != null)
            {
                livroBuscado.Titulo = L.Titulo;
                livroBuscado.QuantidadePaginas = L.QuantidadePaginas;
                livroBuscado.Disponivel = L.Disponivel;

                _context.Livros.Update(livroBuscado);
                _context.SaveChanges();
            }
        }
    }
}
