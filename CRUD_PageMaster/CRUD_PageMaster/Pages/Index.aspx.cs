using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace CRUD_PageMaster.Pages
{
    public partial class Index : System.Web.UI.Page
    {
        //Cadena de conexion
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("sp_load", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvusuarios.DataSource = dt;
            gvusuarios.DataBind();
            con.Close();
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectRow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectRow.Cells[1].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id="+ id +"&op=R"); //Lectura sobre ese id que se envia
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/CRUD.aspx?op=C");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectRow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectRow.Cells[1].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=U"); 
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string id;
            Button btnConsultar = (Button)sender;
            GridViewRow selectRow = (GridViewRow)btnConsultar.NamingContainer;
            id = selectRow.Cells[1].Text;
            Response.Redirect("~/Pages/CRUD.aspx?id=" + id + "&op=D"); 
        }
    }
}