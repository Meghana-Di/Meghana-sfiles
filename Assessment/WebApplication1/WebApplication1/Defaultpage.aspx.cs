using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

namespace WebApplication1
{
    public partial class Defaultpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LoadData();
                LoadData1();
                LoadData2();
                LoadData3();
            }
        }
        void LoadData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3VC78I8\SQLEXPRESS;Initial Catalog=Work2021;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select Country, Count(Country) as Count from TblEMployee group by Country",con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            Chart5.Series[0].Points.DataBindXY(x, y);
            Chart5.Series[0].ChartType = SeriesChartType.StackedColumn;

        }
        void LoadData1()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-3VC78I8\SQLEXPRESS;Initial Catalog=Work2021;Integrated Security=True"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select Country, Count(Country) as Count from TblEMployee group by Country", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            Chart2.Series[0].Points.DataBindXY(x, y);
            Chart2.Series[0].ChartType = SeriesChartType.Pie;

        }
        void LoadData2()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Sqlconn = new SqlConnection(@"Data Source=DESKTOP-3VC78I8\SQLEXPRESS;Initial Catalog=Work2021;Integrated Security=True"))
            {
                Sqlconn.Open();
                SqlCommand cmd = new SqlCommand("select Country,Sum(Salary) from tblEmployee group by Country ", Sqlconn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Sqlconn.Close();
            }
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            Chart3.Series[0].Points.DataBindXY(x, y);
            Chart3.Series[0].ChartType = SeriesChartType.StackedBar;

        }
        void LoadData3()
        {
            DataTable dt = new DataTable();
            using (SqlConnection Sqlcon = new SqlConnection(@"Data Source=DESKTOP-3VC78I8\SQLEXPRESS;Initial Catalog=Work2021;Integrated Security=True"))
            {
                Sqlcon.Open();
                SqlCommand cmd = new SqlCommand("select Country,Sum(Salary) from tblEmployee group by Country ", Sqlcon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                Sqlcon.Close();
            }
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            Chart4.Series[0].Points.DataBindXY(x, y);
            Chart4.Series[0].ChartType = SeriesChartType.FastLine;

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("User.aspx");//User Details
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Details.aspx");//Buyers
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Update.aspx");//Invoice Addtion
        }

       
    }
}
