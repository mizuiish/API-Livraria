using Chapter.Models;
using Microsoft.EntityFrameworkCore;

namespace Chapter.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        
        public SqlContext(DbContextOptions<SqlContext> options) : base(options){}
        // vamos utilizar esse método para configurar o banco de dados

        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured){
                // após o Datasource = colocar o caminho do SSMS do seu computador. Caso tenha um \
                //no meio do nome, adicionar outra \ para que ele entenda como parte do texto
                // o initial catalog é o nome do banco de dados que está sendo utilizado

                optionsBuilder.UseSqlServer("Data Source = LAPTOP-MVT3RCM3\\SQLEXPRESS; initial catalog = Chapter;Integrated Security = true");
            }
        }
        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Livro>? Livros { get; set; }
        //faz a referencia da classe Livro à tabela do banco de dados chamada Livros

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
