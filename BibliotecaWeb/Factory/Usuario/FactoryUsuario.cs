using BibliotecaWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaWeb.Factory.Usuario
{
    public class FactoryUsuario
    {
        public IList<UserViewModel> Factory(DataTable dataTable)
        {
            var list = new List<UserViewModel>();

            foreach (DataRow item in dataTable.Rows)
            {
                var user = new UserViewModel();
                user.ID = Convert.ToInt32(item["id"]);
                user.Email = Convert.ToString(item["email"]);
                user.Senha = Convert.ToString(item["senha"]);
                user.Nome = Convert.ToString(item["nome"]);
                user.Sobrenome = Convert.ToString(item["sobrenome"]);
             
                list.Add(user);
            }
            return list;
        }
    }
}
