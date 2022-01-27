using BibliotecaWeb.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BibliotecaWeb.Factory.Usuario;
using System.Threading.Tasks;

namespace BibliotecaWeb.DAO.Account
{
    public class AccountDAO : ExecutandoComandosSQL
    {
        
        internal async Task Create(UserViewModel user)
        {
            var command = new MySqlCommand();


            command.CommandText = "insert into usuario (nome, sobrenome, email, senha) values(@nome, @sobrenome, @email, @senha)";

            command.Parameters.AddWithValue("@nome", user.Nome);
            command.Parameters.AddWithValue("@sobrenome", user.Sobrenome);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@senha", user.Senha);

            await Insert(command);

        }
        internal async Task<UserViewModel> Get(int id)
        {
            var command = new MySqlCommand();
            command.CommandText = ("select * from usuario where id=@userid");
            command.Parameters.AddWithValue("@userid", id);

            var dataTable = await Select(command);
            var FactoryUsuario = new FactoryUsuario();
            var user = FactoryUsuario.Factory(dataTable);
            return user.FirstOrDefault();
        }
        internal async Task<UserViewModel> Login(string email)
        {
            var command = new MySqlCommand();
            command.CommandText = ("select * from usuario where email=@email");
            command.Parameters.AddWithValue("@email", email);

            var dataTable = await Select(command);
            var FactoryUsuario = new FactoryUsuario();
            var user = FactoryUsuario.Factory(dataTable);
            return user.FirstOrDefault();
        }


    }
}
