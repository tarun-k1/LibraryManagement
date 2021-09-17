using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class index : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LibraryManagement.mdf;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();


    }


        public void Display_Book()
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Select id_book as Book_ID, name As Book_Title, author_name As Author_Name from Book";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();

    }

    public void Available_Book()
    {
        
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Select id_book as Book_ID, name As Book_Title, author_name As Author_Name from Book WHERE Book.id_user IS NULL ";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();
    }
    public void Unavailable_Book()
    {


        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT dbo.Book.name, dbo.Book.author_name, dbo.User_tbl.name AS Issued_Book_By FROM dbo.Book INNER JOIN dbo.User_tbl ON dbo.Book.id_user = dbo.User_tbl.id_user WHERE dbo.Book.id_user IS NOT NULL";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        con.Close();
    }


    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "All")
        {
            Display_Book();
        }
        else if (RadioButtonList1.SelectedValue == "Available")
        {
            Available_Book();
        }
        else
        {
            Unavailable_Book();
        }
    }
}