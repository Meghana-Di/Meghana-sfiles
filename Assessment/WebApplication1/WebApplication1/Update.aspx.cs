using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Update : System.Web.UI.Page
    {
        string connectionString = @"Data Source=DESKTOP-3VC78I8\SQLEXPRESS;Initial Catalog=Work2021;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridView();
            }
        }
        void PopulateGridView()
        {
            DataTable qdt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString)) 

            {
                sqlcon.Open();
                SqlDataAdapter Sqlda = new SqlDataAdapter("exec sp_GetInvoiceDetails", sqlcon);
                Sqlda.Fill(qdt);
            }
            if (qdt.Rows.Count > 0)
            {
                GVAddition.DataSource = qdt;
                GVAddition.DataBind();
            }
            else
            {
                qdt.Rows.Add(qdt.NewRow());
                GVAddition.DataSource = qdt;
                GVAddition.DataBind();
                GVAddition.Rows[0].Cells.Clear();
                GVAddition.Rows[0].Cells.Add(new TableCell());
                GVAddition.Rows[0].Cells[0].ColumnSpan = qdt.Columns.Count;
                GVAddition.Rows[0].Cells[0].Text = "Add new Invoices...!!";
                GVAddition.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void GVAddition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("Add"))
                {
                    using (SqlConnection consql = new SqlConnection(connectionString))
                    {
                        consql.Open();
                        //string query = "insert into InvoiceDetails (InvoiceNumber,InvoiceAmount,PurchaseOrderNumber,InvoiceType,Company,Country) values (@InvoiceNumber,@InvoiceAmount,@PurchaseOrderNumber,@InvoiceType,@Company,@Country)";
                        string query = "exec GetInvoiceDetails @InvoiceNUmber,@InvoiceAmount,@Purchaseordernumber,@InvoiceType,@Company,@Country";
                        SqlCommand sqlcmd = new SqlCommand(query,consql);
                        sqlcmd.Parameters.AddWithValue("@InvoiceNumber", (GVAddition.FooterRow.FindControl("txtInvoiceNumberFooter") as TextBox).Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@InvoiceAmount", (GVAddition.FooterRow.FindControl("txtInvoiceAmountFooter") as TextBox).Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@PurchaseOrderNumber", (GVAddition.FooterRow.FindControl("txtPurchaseOrderNumberFooter") as TextBox).Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@InvoiceType", (GVAddition.FooterRow.FindControl("txtInvoiceTypeFooter") as TextBox).Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Company", (GVAddition.FooterRow.FindControl("txtCompanyFooter") as TextBox).Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@Country", (GVAddition.FooterRow.FindControl("txtCountryFooter") as TextBox).Text.Trim());
                        
                        sqlcmd.ExecuteNonQuery();
                        PopulateGridView();
                        LblSuccessMessage.Text = "New Record Added";
                        LblSuccessMessage.Text = "";
                    }
                }
            }

            catch (Exception ex)
            {
                LblSuccessMessage.Text = "";
                LblSuccessMessage.Text = ex.Message;
            }
}

        protected void GVAddition_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GVAddition.EditIndex = e.NewEditIndex;
            PopulateGridView();
        }

        protected void GVAddition_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GVAddition.EditIndex = -1;
            PopulateGridView();
        }

        protected void GVAddition_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection cosql = new SqlConnection(connectionString))
                {
                    cosql.Open();
                    string query = "update InvoiceDetails set InvoiceNumber=@InvoiceNumber,InvoiceAmount=@InvoiceAmount,PurchaseOrderNumber=@PurchaseOrderNumber, InvoiceType = @InvoiceType, Company = @Company, Country = @Country where ID=@id";
                    SqlCommand sqlcmd = new SqlCommand(query, cosql);
                    sqlcmd.Parameters.AddWithValue("@InvoiceNumber", (GVAddition.Rows[e.RowIndex].FindControl("txtInvoiceNumber") as TextBox).Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@InvoiceAmount", (GVAddition.Rows[e.RowIndex].FindControl("txtInvoiceAmount") as TextBox).Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@PurchaseOrderNumber", (GVAddition.Rows[e.RowIndex].FindControl("txtPurchaseOrderNumber") as TextBox).Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@InvoiceType", (GVAddition.Rows[e.RowIndex].FindControl("txtInvoiceType") as TextBox).Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Company", (GVAddition.Rows[e.RowIndex].FindControl("txtCompany") as TextBox).Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@Country", (GVAddition.Rows[e.RowIndex].FindControl("txtCountry") as TextBox).Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@id", Convert.ToInt32(GVAddition.DataKeys[e.RowIndex].Value.ToString()));
                    sqlcmd.ExecuteNonQuery();
                    GVAddition.EditIndex = -1;
                    PopulateGridView();
                    LblSuccessMessage.Text = "Updated Selected Record";
                    LblSuccessMessage.Text = "";

                }
            }

            catch (Exception ex)
            {
                LblSuccessMessage.Text = "";
                LblSuccessMessage.Text = ex.Message;
            }
        }

        protected void GVAddition_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection cosqln = new SqlConnection(connectionString))
                {
                    cosqln.Open();
                    string query = "Delete from InvoiceDetails where ID=@id";
                    SqlCommand sqlcmd = new SqlCommand(query, cosqln);
                    sqlcmd.Parameters.AddWithValue("@id", Convert.ToInt32(GVAddition.DataKeys[e.RowIndex].Value.ToString()));
                    sqlcmd.ExecuteNonQuery();
                    GVAddition.EditIndex = -1;
                    PopulateGridView();
                    LblSuccessMessage.Text = "Deleted Selected Record";
                    LblSuccessMessage.Text = "";

                }
            }

            catch (Exception ex)
            {
                LblSuccessMessage.Text = "";
                LblSuccessMessage.Text = ex.Message;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultPage.aspx");
        }
    }
}