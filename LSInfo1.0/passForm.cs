using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web;
using System.IO;
using System.Net;
using System.Collections.Specialized;


namespace LSInfo1._0
{
    public partial class passForm : Form
    {
        public passForm()
        {
            InitializeComponent();
        }
        string nazivOpstine = "igorionGrad";

        private void passForm_Load(object sender, EventArgs e)
        {
            try
            {
                
               pictureBox1.ImageLocation = "http://www.igorion.in.rs/LSInfo/slikaIgorionGrad/iGSlika.png";
               pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                
             
                
                
               Label usernameLabel1 = new Label();
               usernameLabel1.Text = "Унесите корисничко име: ";
               usernameLabel1.Location = new Point(12, 12);
               usernameLabel1.Size = new Size(350, 20);
               usernameLabel1.BackColor = Color.Transparent;
               usernameLabel1.ForeColor = System.Drawing.Color.Yellow;
               usernameLabel1.Font = new Font("Arial", 11, FontStyle.Bold);
               pictureBox1.Controls.Add(usernameLabel1);
                
               TextBox textBox3 = new TextBox();
               textBox3.Location = new Point(12, 32);
               textBox3.Size = new Size(200,20);
               textBox3.BackColor = Color.DimGray;
               textBox3.ForeColor = System.Drawing.Color.Yellow;
               textBox3.Font = new Font("Arial", 11, FontStyle.Bold);
               pictureBox1.Controls.Add(textBox3);
               
               Label usernameLabel2 = new Label();
               usernameLabel2.Text = "Унесите корисничко име: ";
               usernameLabel2.Location = new Point(12, 92);
               usernameLabel2.Size = new Size(335, 20);
               usernameLabel2.BackColor = Color.Transparent;
               usernameLabel2.ForeColor = System.Drawing.Color.Yellow;
               usernameLabel2.Font = new Font("Arial", 11, FontStyle.Bold);
               pictureBox1.Controls.Add(usernameLabel2);

               TextBox textBox2 = new TextBox();
               textBox2.Location = new Point(12, 112);
               textBox2.Size = new Size(200, 20);
               textBox2.BackColor = Color.DimGray;
               textBox2.ForeColor = System.Drawing.Color.Yellow;
               textBox2.Font = new Font("Arial", 11, FontStyle.Bold);
               pictureBox1.Controls.Add(textBox2);

               Button btn = new Button();
               btn.Text = "Потврди";
               btn.Location = new Point(112, 155);
               btn.Size = new Size(100,30);
               pictureBox1.Controls.Add(btn);
               
               

            }
            catch { }
            /*

            Cursor.Current = Cursors.WaitCursor;

            string trt = " ";
            WebClient webClient = new WebClient();
            NameValueCollection formData = new NameValueCollection();
            formData.Add("a", trt);

            byte[] response = webClient.UploadValues("http://www.igorion.in.rs/LSInfo/porukePregled.php", "POST", formData);
            string responsebody = Encoding.UTF8.GetString(response);

            JavaScriptSerializer js = new JavaScriptSerializer();
            prijemPoruke[] poruke = js.Deserialize<prijemPoruke[]>(responsebody);


            for (int aList = 0; aList < poruke.LongLength; aList++)
            {
                ListViewItem item = new ListViewItem(poruke[aList].NazivPoruka);
                item.SubItems.Add("" + poruke[aList].TekstPoruke);
                item.SubItems.Add("" + DateTime.ParseExact(poruke[aList].DatumSlanjaPoruke, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("dddd, dd. MMMM yyyy.", new CultureInfo("sr-Cyrl-CS")));
                item.SubItems.Add("" + DateTime.ParseExact(poruke[aList].DatumIstekaPoruke, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("dddd, dd. MMMM yyyy.", new CultureInfo("sr-Cyrl-CS")));
                item.SubItems.Add("" + poruke[aList].brojPregleda);
                lstViewPoruke.Items.Add(item);
            }
            lstViewPoruke.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            splitContainer2.Panel1.Controls.Add(lstViewPoruke);
            Cursor.Current = Cursors.Default;

            */

        }
    }
}
