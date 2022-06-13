using CommunalApartment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommunalApartment.Controllers
{
    public class ValuesController : ApiController
    {
        private SqlConnection con = null;
        private SqlDataAdapter adap = null; //Для обеспечения выполнения запросов
        public DataTable table = null;
        string SqlConnectionString = "Data Source=SHELOVESLOLOO;Initial Catalog=callmeyujiro;User ID=Loloo;Password=123"; //Подключение к SQL Server
        // GET api/values
        public List<Clients> Get()
        {
            List<Clients> GettingJsonValuesInDatabase = new List<Clients>();
            {
                con = new SqlConnection(SqlConnectionString);
                con.Open();
                SqlCommand comm = new SqlCommand("ClientsView", con);
                adap = new SqlDataAdapter(comm);
                comm.CommandType = CommandType.StoredProcedure;
                table = new DataTable();
                adap.Fill(table);
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++) //Цикл для вывода списка
                    {
                        Clients students = new Clients();
                        students.Person = Convert.ToInt32(table.Rows[i]["Personal_check"]);
                        students.Name = table.Rows[i]["Name"].ToString();
                        students.Phone = Convert.ToInt32(table.Rows[i]["Phone_Number"]);
                        students.Street = table.Rows[i]["Street"].ToString();
                        students.House = Convert.ToInt32(table.Rows[i]["House"]);
                        students.Apartment = Convert.ToInt32(table.Rows[i]["Apartment"]);
                        students.AmountOfRoom = Convert.ToInt32(table.Rows[i]["Amount_Of_Room"]);
                        students.Square = Convert.ToInt32(table.Rows[i]["Square"]);
                        GettingJsonValuesInDatabase.Add(students);
                    }
                }
                con.Close();
            }
            return GettingJsonValuesInDatabase;
        }
        // GET api/values/5
        public List<Clients> Get(int pers)
        {
            List<Clients> GettingJsonValuesInDatabase = new List<Clients>();
            {
                con = new SqlConnection(SqlConnectionString);
                con.Open();
                SqlCommand comm = new SqlCommand("PersonalClient", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                comm.Parameters.Add(new SqlParameter("@Person", pers));
                adap = new SqlDataAdapter(comm);
                table = new DataTable();
                adap.Fill(table);
                if (table.Rows.Count > 0)
                {
                    for (int i = 0; i < table.Rows.Count; i++) //Цикл для вывода списка
                    {
                        Clients students = new Clients(); 
                        students.Person = Convert.ToInt32(table.Rows[i]["Personal_check"]);
                        students.Name = table.Rows[i]["Name"].ToString();
                        students.Phone = Convert.ToInt32(table.Rows[i]["Phone_Number"]);
                        students.Street = table.Rows[i]["Street"].ToString();
                        students.House = Convert.ToInt32(table.Rows[i]["House"]);
                        students.Apartment = Convert.ToInt32(table.Rows[i]["Apartment"]);
                        students.AmountOfRoom = Convert.ToInt32(table.Rows[i]["Amount_Of_Room"]);
                        students.Square = Convert.ToInt32(table.Rows[i]["Square"]);
                        GettingJsonValuesInDatabase.Add(students);
                    }
                }
                con.Close();
            }
            return GettingJsonValuesInDatabase;
        }

        [HttpGet]
        [Route("GetForTerm")]
        public List<Clients> GetForTerm(int pers)
        {
            int m = 0;
            string messege = "";
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
                    messege = "0";
                    m = 0;
                }
                else if (table.Rows.Count == 1)
                {
                    for (int i = 0; i < table.Rows.Count; i++) //Цикл для вывода списка
                    {
                        Clients students = new Clients();
                        students.Name = table.Rows[i]["Name"].ToString();
                        GettingJsonValuesInDatabase.Add(students);
                    }
                    m = 1;
                }
                con.Close();
            }
            if(m==0)
            {
                return GettingJsonValuesInDatabase;
            }
            else
            {
                return GettingJsonValuesInDatabase;
            }
           
        }

       // POST api/values
        public List<Indication> Post([FromBody] Indication indication)
        {
            List<Indication> GettingJsonValuesInDatabase = new List<Indication>();
            {
                con = new SqlConnection(SqlConnectionString);
                con.Open();
                SqlCommand comm = new SqlCommand("insert_indication", con);
                comm.CommandType = CommandType.StoredProcedure;
                
                comm.Parameters.Add(new SqlParameter("@p",indication.Person));
                comm.Parameters.Add(new SqlParameter("@s", indication.Serv));
                comm.Parameters.Add(new SqlParameter("@c", indication.Cost));
                comm.ExecuteNonQuery();
                con.Close();
            }
            return GettingJsonValuesInDatabase;
        }

        [HttpPost]
        [Route("PostForTerm")]

        public List<Paying> PostForTerm([FromBody] Paying paying)
        {
            List<Paying> GettingJsonValuesInDatabase = new List<Paying>();
            {
                con = new SqlConnection(SqlConnectionString);
                con.Open();
                SqlCommand comm = new SqlCommand("pay_insert", con);
                comm.CommandType = CommandType.StoredProcedure;

                comm.Parameters.Add(new SqlParameter("@p", paying.Person));
                comm.Parameters.Add(new SqlParameter("@s", paying.Serv));
                comm.Parameters.Add(new SqlParameter("@al", paying.AllSum));
                comm.ExecuteNonQuery();
                con.Close();
            }
            return GettingJsonValuesInDatabase;
        }
        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
