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
    public partial class Registration2 : System.Web.UI.Page
    {
        OleDbConnection con3 = new OleDbConnection(ConfigurationManager.ConnectionStrings["db1ConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //string CripcadDgxonwenna = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("Web.mdb");
            //var Dgxonwense = new OleDbConnection(CripcadDgxonwenna);
            
            // Чтение из полей
            if (Page.IsValid)
            {
                string sparol, slogin, spage, semail;
                sparol = Convert.ToString(TextBox6.Text);
                slogin = Convert.ToString(TextBox3.Text);
                semail = Convert.ToString(TextBox4.Text);
                spage = Convert.ToString(TextBox5.Text);

                try
                {
                    // Открытие подключения
                    con3.Open();
                }
                catch (Exception ex1)
                {
                    // Выход в метку сообщения об ошибке
                    Label1.Visible = true;
                    Label1.Text = ex1.Message;
                    con3.Close();
                    return;
                }

                string sqlQ;
                sqlQ = "INSERT INTO S_user(Named, Parol, Email, WebPage) VALUES('" + slogin + "', '" + sparol + "', '" + semail + "', '" + spage + "')";
                // Выход запроса в метку (только во время отладки программы)
                Label1.Text = sqlQ;
                var Kowauza = new OleDbCommand();
                Kowauza.CommandText = sqlQ;
                Kowauza.Connection = con3;

                try
                {
                    // Выполнение команды SQL
                    Kowauza.ExecuteNonQuery();
                    Label1.Visible = true;
                    Label1.Text = "Пользователь добавлен";
                }
                catch (Exception ex1)
                {
                    // Выход в метку сообщения об ошибке
                    Label1.Visible = true;
                    Label1.Text = ex1.Message;
                    con3.Close();
                    return;
                }
            }
        }
    }
}