using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace CRUD_PageMaster.Pages
{
    public partial class CRUD : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public static string sID = "-1";
        public static string sOp = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtener el id
            if (!Page.IsPostBack)
            {
                if(Request.QueryString["id"]!= null)
                {
                    sID = Request.QueryString["id"].ToString();
                    CargarDatos();
                    tbdate.TextMode = TextBoxMode.DateTime;
                }

                if(Request.QueryString["op"]!= null)
                {
                    sOp = Request.QueryString["op"].ToString();

                    switch (sOp)
                    {
                        case "C":
                            this.lbltitulo.Text = "Ingresar Nuevo Usuario";
                            this.btnCreate.Visible = true;
                            break;
                        case "R":
                            this.lbltitulo.Text = "Datos Del Usuario";
                            break;
                        case "U":
                            this.lbltitulo.Text = "Modificar Usuario";
                            btnUpdate.Visible = true;
                            break;
                        case "D":
                            this.lbltitulo.Text = "¿Estás Seguro De Eliminar Este Usuario?";
                            this.btnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("sp_read", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = sID;
            DataSet dataSet = new DataSet();
            dataSet.Clear();
            da.Fill(dataSet);
            DataTable dt = dataSet.Tables[0];
            DataRow row = dt.Rows[0];
            tbnombre.Text = row[1].ToString();
            tbedad.Text = row[2].ToString();
            tbemail.Text = row[3].ToString();
            DateTime d = (DateTime)row[4];
            tbdate.Text = d.ToString("dd/MM/yyyy");
            con.Close();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_create", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = tbnombre.Text;
            cmd.Parameters.Add("@edad", SqlDbType.Int).Value = tbedad.Text;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = tbemail.Text;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = tbdate.Text;

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = sID;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = tbnombre.Text;
            cmd.Parameters.Add("@edad", SqlDbType.Int).Value = tbedad.Text;
            cmd.Parameters.Add("@correo", SqlDbType.VarChar).Value = tbemail.Text;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = tbdate.Text;

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = sID;

            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Index.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}