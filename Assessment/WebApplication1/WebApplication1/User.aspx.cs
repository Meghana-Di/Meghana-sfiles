using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class User : System.Web.UI.Page
    {


        string ConnectionString = @"Data Source=DESKTOP-3VC78I8\SQLEXPRESS;Initial Catalog=Work2021;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection Sqlcon = new SqlConnection(ConnectionString))
            {
                Sqlcon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("Select * from InvoiceDetails", Sqlcon); ;
                DataTable dtsql = new DataTable();
                sqlda.Fill(dtsql);
                GVEmployee.DataSource = dtsql;
                GVEmployee.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AppendHeader("content-disposition", "attachment; filename=Employee.xls");
            Response.ContentType = "application/excel";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            GVEmployee.RenderControl(htmlTextWriter);
            Response.Write(stringWriter.ToString());
            Response.End();

        }
        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultPage.aspx");
        }
    }
}