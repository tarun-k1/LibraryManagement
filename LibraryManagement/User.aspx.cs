using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class User : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\LibraryManagement.mdf;Integrated Security=True");
    private int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.Open();

        string uname = Session["uEmail"].ToString();
        Label1.Text = uname;
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Select id_user from User_tbl where email = '"+uname+"'";
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            id = dr.GetInt32(0);
            
        }
        con.Close();

    }

   
    public void MyBook()
    {
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Select id_book,name, author_name from Book where id_user = '"+id+"'";
        con.Open();
        cmd.ExecuteNonQuery();

        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        if (GridView1.Rows.Count == 0)
        {
            Label1.Text = "You have currently no books issued...";
            Label1.Visible = true;
        }
        con.Close();
    }

    public void IssueBook()
    {
        con.Open();

        SqlCommand checkbook = new SqlCommand("select id_user from Book where id_book='" + TextBox1.Text + "'", con);
        SqlDataReader dr = checkbook.ExecuteReader();
        Object o= null;
         while (dr.Read())
        {
            o = dr["id_user"];
            //userID = dr.GetString(0);
        }
        dr.Close();
        if (o == DBNull.Value)  
        {
            //avaliable to book
            SqlCommand cmd3 = new SqlCommand("update Book set id_user=" + id + " where id_book=" + TextBox1.Text + "", con);
            cmd3.ExecuteNonQuery();
            TextBox1.Text = "";
            con.Close();
            TextBox1.Visible = false;
            Label2.Visible = false;
            Button2.Visible = false;
        }
        else
        {
            //Not avaliable
            Label2.Text = "Already Booked or Invalid BookID!! Select another book...";
            Label2.Visible = true;
        }

        con.Close();

    }

    public void ReturnBook()
    {
        con.Open();

        SqlCommand checkbook = new SqlCommand("select id_user from Book where id_book='" + TextBox1.Text + "'", con);
        SqlDataReader dr = checkbook.ExecuteReader();

        Object o = null;
        while (dr.Read())
        {

            o = dr["id_user"];
        }
        dr.Close();
        if (o != DBNull.Value)

            {

            SqlCommand cmd3 = new SqlCommand("update Book set id_user= NULL where id_book=" + TextBox1.Text + "", con);
            cmd3.ExecuteNonQuery();
            TextBox1.Text = "";
            con.Close();
            GridView1.Visible = false;
            Label2.Text = "Successfully return";
            TextBox1.Visible = false;
            Label2.Visible = true;
            Button2.Visible = false;
            
        }
        else
        {


            Label2.Visible = true;
            Label2.Text = "No Book available for return";
            TextBox1.Visible = false;
            Button2.Visible = false;

        }

        con.Close();
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "myBook")
        {
            MyBook();
        }
        else if (RadioButtonList1.SelectedValue == "issue")
        {
            TextBox1.Visible= true;
            Label2.Visible = true;
            Label2.Text = "Enter Book Id to issue new book";
            Button2.Visible = true;
            Button2.Text = "Issue";
            
        }
        else if(RadioButtonList1.SelectedValue == "return")
        {
            TextBox1.Visible = true;
            Label2.Visible = true;
            Label2.Text = "Enter Book Id to return book";
            Button2.Visible = true;
            Button2.Text = "Issue";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "issue")
        {
            IssueBook();
        }
        else if (RadioButtonList1.SelectedValue == "return")
        {
            ReturnBook();
        }
        
    }
}