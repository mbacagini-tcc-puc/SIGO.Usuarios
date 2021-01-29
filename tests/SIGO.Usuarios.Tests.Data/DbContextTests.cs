using Microsoft.EntityFrameworkCore;
using Npgsql;
using SIGO.Usuarios.Data;
using System.Linq;
using Xunit;

namespace SIGO.Usuarios.Tests.Data
{
    public class DbContextTests
    {
        [Fact]
        public void TestarBanco()
        {
            // apagar banco de teste caso exista
            using (var conn = new NpgsqlConnection("Host=127.0.0.1;Port=5432;Pooling=true;Database=postgres;User Id=postgres;Password=mysecretpassword;"))
            using (var cmd = new NpgsqlCommand("drop database if exists usuarios_test_db", conn))
            {
                conn.Open();
                cmd.ExecuteScalar();
                conn.Close();
            }

            // iniciar nova conexão
            var optionsBuilder = new DbContextOptionsBuilder<UsuariosContext>();
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Pooling=true;Database=usuarios_test_db;User Id=postgres;Password=mysecretpassword;");
            var context = new UsuariosContext(optionsBuilder.Options);

            // forçar execução da migration
            context.Database.Migrate();

            // forçar execução das configurações dos DbContexts:
            context.Usuarios.FirstOrDefault();
            context.Modulos.FirstOrDefault();

            // fechar conexão
            context.Database.CloseConnection();
            context.Dispose();

            Assert.True(true, "Não houve erros de execução");
        }
    }
}
