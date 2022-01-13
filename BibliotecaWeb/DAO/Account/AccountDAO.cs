using BibliotecaWeb.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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

        
    }
}
