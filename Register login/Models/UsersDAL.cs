using System.Data.SqlClient;

namespace Register_login.Models
{
    public class UsersDAL
    {
        private readonly IConfiguration configuration;
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public UsersDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            con = new SqlConnection(this.configuration.GetConnectionString("defaultConnection"));
        }
        public int UserrRegister(Users us)
        {
            string qry = "insert into Users values(@name,@email,@contact,@pass)";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", us.Name);
            cmd.Parameters.AddWithValue("@email", us.Email);
            cmd.Parameters.AddWithValue("@contact", us.Contact);
            cmd.Parameters.AddWithValue("@pass", us.Password);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public Users UserLogin(Users us)
        {
            Users cs = new Users();
            string qry = "select * from Users where email=@email and password=@pass";
            cmd=new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@email", us.Email);
            cmd.Parameters.AddWithValue("@pass", us.Password);
            con.Open();
            dr=cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    cs.Id=Convert.ToInt32(dr["Id"]);
                    cs.Name=dr["name"].ToString();
                    cs.Email=dr["email"].ToString();
                }
                return cs;
            }
            else
            {
                return null;
            }
        }

        public List<Users> GetAllUsers()
        {
            List<Users> UsersList = new List<Users>();
            string qry = "select * from Users";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Users us = new Users();
                    us.Name = dr["name"].ToString();
                    us.Email=dr["email"].ToString();
                    us.Contact = dr["contact"].ToString();
                    us.Password = dr["password"].ToString() ;
                    UsersList.Add(us);

                }
                con.Close();
                return UsersList;

            }
            else
            {
                return null;
            }
        }
    }
}

