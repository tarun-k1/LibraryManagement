using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LibraryManagement.mdf;Integrated Security=True");
    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();
        Display_Book();

        
    }

    public void Display_Book()
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT Book.id_book As Book_ID, dbo.Book.name As Book_Title, dbo.Book.author_name As Author_Name, dbo.User_tbl.name AS Issued_Book_By FROM dbo.Book INNER JOIN dbo.User_tbl ON dbo.Book.id_user = dbo.User_tbl.id_user";
        cmd.ExecuteNonQuery();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();

    }

    protected void add_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "insert into Book values('"+ bookname.Text +",'"+author.Text+"')";
        cmd.ExecuteNonQuery();
        bookname.Text = "";
        Display_Book();
    }

    protected void delete_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from Book where name = '" + bookname.Text + "' and author_name = '"+author.Text+"'";
        cmd.ExecuteNonQuery();
        bookname.Text = "";
        author.Text = "";
        Display_Book();
    }

    protected void Update_Click(object sender, EventArgs e)
    {

        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "update Book set name = '" + bookname.Text + "', author_name = '" + author.Text + "' where id_book = " +Convert.ToInt32(updateId.Text)+"";
        cmd.ExecuteNonQuery();
        bookname.Text = "";
        author.Text = "";
        Display_Book();
    }
}