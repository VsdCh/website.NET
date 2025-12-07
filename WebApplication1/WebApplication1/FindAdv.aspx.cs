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
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        OleDbConnection con2 = new OleDbConnection(ConfigurationManager.ConnectionStrings["db1ConnectionString2"].ConnectionString);
        protected void Page_Load2(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con2.Open();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            // Строка запроса с фильтрацией по двум критериям (по умолчанию оба используются)
            string find2 = @"
        SELECT Goods.*, TypeGoods.TypeDescr, Dealers.Organization
        FROM (Goods 
        INNER JOIN TypeGoods ON TypeGoods.IDtype = Goods.IDtype) 
        INNER JOIN Dealers ON Dealers.IDdealer = Goods.IDdealer
        WHERE 1=1";  // Добавляем условие для удобства (по умолчанию все строки)

            // Переменные для параметров
            List<OleDbParameter> parameters = new List<OleDbParameter>();

            // Проверяем, выбран ли CheckBox1 (для отключения DropDownList2)
            if (!CheckBox1.Checked && !string.IsNullOrEmpty(DropDownList2.SelectedItem?.Text))
            {
                find2 += " AND Dealers.Organization LIKE '%' + @deal + '%'";
                parameters.Add(new OleDbParameter("@deal", DropDownList2.SelectedItem.Text));
            }

            // Проверяем, выбран ли CheckBox2 (для отключения DropDownList1)
            if (!CheckBox2.Checked && !string.IsNullOrEmpty(DropDownList1.SelectedItem?.Text))
            {
                find2 += " AND TypeGoods.TypeDescr LIKE '%' + @type + '%'";
                parameters.Add(new OleDbParameter("@type", DropDownList1.SelectedItem.Text));
            }

            // Создаем команду и добавляем параметры
            OleDbCommand cmd2 = new OleDbCommand(find2, con2);
            cmd2.Parameters.AddRange(parameters.ToArray());

            // Выполнение запроса
            OleDbDataAdapter da2 = new OleDbDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "IdGood");

            // Настройка источника данных для GridView
            GridView2.DataSourceID = null;
            GridView2.DataSource = ds2;
            GridView2.DataBind();

            // Закрытие соединения
            con2.Close();
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource2_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void SqlDataSourceZapros_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Отключаем или включаем DropDownList2 в зависимости от состояния CheckBox1
            DropDownList2.Enabled = !CheckBox1.Checked;
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Отключаем или включаем DropDownList1 в зависимости от состояния CheckBox2
            DropDownList1.Enabled = !CheckBox2.Checked;
        }
    }
}