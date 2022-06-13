using CommunalApartment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CommunalApartment.Controllers
{
    public class ForTerminalController : Controller
    {
        private SqlConnection con = null;
        private SqlDataAdapter adap = null; //Для обеспечения выполнения запросов
        public DataTable table = null;
        string SqlConnectionString = "Data Source=SHELOVESLOLOO;Initial Catalog=callmeyujiro;User ID=Loloo;Password=123"; //Подключение к SQL Server
        // GET: ForTerminal
        public List<Clients> Get(int pers)
        {
            List<Clients> GettingJsonValuesInDatabase = new List<Clients>();
            {
                con = new SqlConnection(SqlConnectionString);
                con.Open();
                SqlCommand comm = new SqlCommand("PersonalClientForTerminal", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                comm.Parameters.Add(new SqlParameter("@Person", pers));
                adap = new SqlDataAdapter(comm);
                table = new DataTable();
                adap.Fill(table);
                if (table.Rows.Count == 0)
                {    
                    comm = new SqlCommand("PersonalClientForTermina", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    comm.Parameters.Add(new SqlParameter("@Person", pers));
                    adap = new SqlDataAdapter(comm);
                    table = new DataTable();
                    adap.Fill(table);
                    for (int i = 0; i < table.Rows.Count; i++) //Цикл для вывода списка
                    {
                        Clients students = new Clients();
                        students.Name = table.Rows[i]["Name"].ToString();
                        GettingJsonValuesInDatabase.Add(students);
                    }
                }
                else if(table.Rows.Count==1)
                {
                    for (int i = 0; i < table.Rows.Count; i++) //Цикл для вывода списка
                    {
                        Clients students = new Clients();
                        students.Name = table.Rows[i]["Rspns"].ToString();
                        GettingJsonValuesInDatabase.Add(students);
                    }
                }
                con.Close();
            }
            return GettingJsonValuesInDatabase;
        }
    

    }
}