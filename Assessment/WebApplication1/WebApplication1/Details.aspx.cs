using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
namespace WebApplication1
{
    public partial class Details : System.Web.UI.Page
    {

        //string ConnectionString = @"Data Source=DESKTOP-3VC78I8\SQLEXPRESS;Initial Catalog=Work2021;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }

        }
            private void BindData()
            {
                try
                {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sConnectionstring"].ConnectionString);
                   // using (SqlConnection Sqlcon = new SqlConnection(@"Data Source=DESKTOP-3VC78I8\SQLEXPRESS;Initial Catalog=Work2021;Integrated Security=True"))
                    //{
                        DataTable dtsql = new DataTable();
                        SqlDataAdapter sqlda = new SqlDataAdapter("GetBuyerDetails", con);
                        con.Open();
                        sqlda.Fill(dtsql);
                        con.Close();
                        GVEmployee1.DataSource = dtsql;
                        GVEmployee1.DataBind();
                   // }
                }
                catch 
                {
                    throw;
                }
            }

        protected void GVEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            
            
                GVEmployee1.PageIndex = e.NewPageIndex;
                this.BindData();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultPage.aspx");//home page
        }


        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.ClearContent();
        //    Response.AppendHeader("content-disposition", "attachment; filename=Employee.xls");
        //    Response.ContentType = "application/excel";
        //    StringWriter stringWriter = new StringWriter();
        //    HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
        //    GVEmployee1.RenderControl(htmlTextWriter);
        //    Response.Write(stringWriter.ToString());
        //    Response.End();

        //}
        //public override void VerifyRenderingInServerForm(Control control)
        //{

        //}

    }
}

   