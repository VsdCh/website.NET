using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        OleDbConnection con = new OleDbConnection(ConfigurationManager.ConnectionStrings["db1ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string find = "SELECT * FROM Goods WHERE NameGood LIKE '%' + @NName + '%'";
            OleDbCommand cmd = new OleDbCommand(find, con);
            cmd.Parameters.AddWithValue("@NName", TextBox3.Text);

            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "Name");
            GridView1.DataSourceID = null;
            GridView1.DataSource = ds;
            GridView1.DataBind();

            con.Close();
        }
    }
}