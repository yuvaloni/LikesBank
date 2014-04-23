using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using System.Data.SqlClient;

namespace BankBg
{
    class ManageDB:IJob
    {

        public void Execute(IJobExecutionContext context)
        {
            SqlConnection con = new SqlConnection("Data Source=74b317f3-97db-468b-91f3-a31200847454.sqlserver.sequelizer.com;Initial Catalog=db74b317f397db468b91f3a31200847454;Persist Security Info=True;User ID=okuodvwkvgtzfduc;Password=TdH4qo2H7SDuFgNatGkbKKu8zBYhYsE5zZ4jXEwuDpJwuG3SHVJN6VCiRJCWxTRM");
            con.Open();
            SqlCommand com = new SqlCommand("DELETE FROM SESSION");
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
