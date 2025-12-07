using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.OleDb;
using System.Configuration;

using System.Data.SqlClient;
using System.Data;
namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        //загрузка страницы
        protected void Page_Load(object sender, EventArgs e)
        {
            string Suser;
            long IDU;
            IDU = Convert.ToInt32(Session["IDU"]); //код пользователя
            Suser = Convert.ToString(Session["SUser"]);// имя пользователя
            Label3.Visible = false;
            Label4.Visible = false;
            if (IDU != 0)
            {
                Button2.Visible = false;//кнопка регистрация
                Button1.Visible = false;//кнопка вход
                Button3.Visible = true;//кнопка выход
               // Label1.Visible = false;//метка имя!!!
                Label2.Visible = false;//метка пароль
                TextBox1.Visible = false;//поле имя
                TextBox2.Visible = false;//поле пароль
                Label1.Text = "Привет " + Session["SUser"];//!!!
            }
            else
            {
                Button2.Visible = true;//кнопка регистрация
                Button1.Visible = true;//кнопка вход
                Button3.Visible = false;//кнопка выход
                Label1.Visible = true;//метка имя
                Label2.Visible = true;//метка пароль
                TextBox1.Visible = true;//поле имя
                TextBox2.Visible = true;//поле пароль
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("News.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Find.aspx");
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("FindAdv.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con4 = new OleDbConnection(ConfigurationManager.ConnectionStrings["db1ConnectionString"].ConnectionString);
            //string Stroka = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("Web.mdb");
            //var con4 = new OleDbConnection(Stroka);
            try
            {
                //Открытие подключения
                con4.Open();
            }
            catch (Exception ex1)
            {
                //Вывод в метку сообщения об ошибке
                Label3.Text = ex1.Message;
                con4.Close();
                return;
            }
            string sparol, slogin;
            sparol = Convert.ToString(TextBox2.Text);
            slogin = Convert.ToString(TextBox1.Text);
            string sqlQ = "SELECT * FROM S_user WHERE Named='" + slogin + "' AND Parol='" + sparol + "'";
            Label4.Text = sqlQ;
            var Команда = new OleDbCommand();
            Команда.CommandText = sqlQ;
            Команда.Connection = con4;
            try
            {
                // выполнение команды sql
                OleDbDataReader Чтение;
                // while
                // DateReader=Команда.ExecuteReader;
                // bool rr;
                Чтение = Команда.ExecuteReader();
                // rr = "Чтение.Read";
                if (Чтение.Read() == true)
                {
                    var id = Чтение.GetValue(0);
                    Session["TOU"] = id;
                    Session["SUser"] = TextBox1.Text;
                    // имя Session["SUser"] =Чтение.GetValue(1);
                    Button2.Visible = false;//кнопка регистрация
                    Button1.Visible = false;//кнопка входа
                    Button3.Visible = true;//кнопка выхода
                    //Label1.Visible = false;//метка имя!!!
                    Label2.Visible = false;//метка пароль

                    TextBox1.Visible = false;//поле имя
                    TextBox2.Visible = false;//поле пароль
                    Label1.Text = "Привет " + Session["SUser"];//!!!
                }
                else
                {
                    Label1.Text = "пароль не верен";
                    Button2.Visible = true;//кнопка регистрация
                    Button1.Visible = true;//кнопка входа
                    Button3.Visible = false;//кнопка выхода
                   // Label2.Visible = true;//метка имя/////!!!!!
                    Label2.Visible = true;//метка пароль
                    TextBox1.Visible = true;//поле имя
                    TextBox2.Visible = true;//поле пароль
                }
            }
            catch (Exception ex1)
            {
                // Вывод в минуту сообщения об ошибке
                Label3.Text = ex1.Message;
                con4.Close();
                return;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("MainPage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration2.aspx");
        }
    }
}