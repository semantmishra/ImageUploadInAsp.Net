using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

namespace ImageUplodaAndRetrep
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String  connString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            String path = Server.MapPath("Images/");
            if (FileUpload1.HasFile)
            {
                String name = Path.GetFileName(FileUpload1.FileName);
                String Exteson = Path.GetExtension(FileUpload1.FileName);
                HttpPostedFile postfile = FileUpload1.PostedFile;
                int len = postfile.ContentLength;
               
                if (Exteson.ToLower() == ".jpg" || Exteson.ToLower() == ".jpeg" || Exteson.ToLower() == ".png")
                {
                    if (len <= 1000000)
                    {
                        FileUpload1.SaveAs(path + name);
                        string na = "Images/" + name;
                        string Sq = "insert into ImageTbl(Image) values(@img) ";
                        SqlCommand cmd = new SqlCommand(Sq, conn);
                        conn.Open();
                        cmd.Parameters.AddWithValue("@img", na);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        Label1.Text = "Upload Success";
                        Label1.ForeColor = System.Drawing.Color.Blue;
                        LoadGridView();
                    }
                    else 
                    {
                        Label1.Text = "File Size Vary Large!!!";
                        Label1.ForeColor = System.Drawing.Color.Red;
                    }

                }
                else
                {
                    Label1.Text = "Plese Choose Correct Image!!!";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }

            }
            else
            {
                Label1.Text = "Plese Upload an Image!!!";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }

        void LoadGridView() 
        {
            String connString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlDataAdapter d = new SqlDataAdapter("Select * from ImageTbl", conn);
            DataTable dt = new DataTable();
            d.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

    }
}