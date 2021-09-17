using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

public partial class Default3 : System.Web.UI.Page
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select * from User_tbl where name = '" + TextBox1.Text + "' and email = '" + TextBox2.Text + "'", con);
       
        SqlDataReader dr = cmd.ExecuteReader();

        if ( TextBox1.Text=="admin" && TextBox2.Text == "admin@admin.com")
        {
            Label1.Text = "admin here";
            Response.Redirect("Default.aspx");
        }
        else if (dr.Read() == true)
        {
            if (TextBox2.Text == dr.GetString(2))
            {


                
                Label1.Text = "Login Success!";
                Session["uEmail"] = TextBox2.Text.ToString();
                Response.Redirect("User.aspx");
            }
            else
            {
                Label1.Text = "wrong email";
            }
        }
        else
        {
            Label1.Text = "No user Found";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand("select * from User_tbl where name = '" + TextBox1.Text + "' and email = '" + TextBox2.Text + "'", con);
        SqlDataReader dr = cmd.ExecuteReader();
       
        if (dr.Read() == true && TextBox2.Text == dr.GetString(2))
        {
                Label1.Text = "User Already Exist";  
        }
        
        else
        {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            cmd.CommandText = "insert into User_tbl values('" + TextBox1.Text + "','" + TextBox2.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            Label1.Text = "User registered successfully";
            
        }
    }
}