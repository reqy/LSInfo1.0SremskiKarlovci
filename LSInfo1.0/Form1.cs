using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Web;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using System.Net.Mail;





namespace LSInfo1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            label2.MouseEnter += new EventHandler(label2_MouseEnter);
            label2.MouseLeave += new EventHandler(label2_MouseLeave);

            label3.MouseEnter += new EventHandler(label3_MouseEnter);
            label3.MouseLeave += new EventHandler(label3_MouseLeave);

            label4.MouseEnter += new EventHandler(label4_MouseEnter);
            label4.MouseLeave += new EventHandler(label4_MouseLeave);
           

            label5.MouseEnter += new EventHandler(label5_MouseEnter);
            label5.MouseLeave += new EventHandler(label5_MouseLeave);


        }
        int ans =Screen.PrimaryScreen.Bounds.Width;
        public string opstina = "SremskiKarlovci";

        
        private void Form1_Load(object sender, EventArgs e)
        {

            spica();
        

            
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            label6.Text = DateTime.Now.ToString("dddd, dd. MMMM yyyy.", new CultureInfo("sr-Cyrl-CS"));
            splitContainer2.Panel2Collapsed = true; ////  Ovim sa ocistio moju brlju!!! //////////////
            proveraInterneta();

            passwordForm();

        }



      

        private void label2_Click(object sender, EventArgs e)
        {
            ocistiKontejner2();
            porukaGradjanima();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            ocistiKontejner2();
            upitnikGradjanima();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ocistiKontejner2();
            pregledPoruka();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ocistiKontejner2();
            pregledUpitnika();
        }


       







        public void spica()
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        public void ocistiKontejner2()
        { 
            splitContainer2.Panel1.Controls.Clear();

        }



        void label2_MouseLeave(object sender, EventArgs e)
        {
            
            this.label2.Font = new Font(label2.Font, FontStyle.Regular);
        }


        void label2_MouseEnter(object sender, EventArgs e)
        {
            
            this.label2.Font = new Font(label2.Font, FontStyle.Bold);
        }

        void label3_MouseLeave(object sender, EventArgs e)
        {

            this.label3.Font = new Font(label3.Font, FontStyle.Regular);
        }


        void label3_MouseEnter(object sender, EventArgs e)
        {

            this.label3.Font = new Font(label3.Font, FontStyle.Bold);
        }

        void label4_MouseLeave(object sender, EventArgs e)
        {

            this.label4.Font = new Font(label4.Font, FontStyle.Regular);
        }


        void label4_MouseEnter(object sender, EventArgs e)
        {

            this.label4.Font = new Font(label4.Font, FontStyle.Bold);
        }

        void label5_MouseLeave(object sender, EventArgs e)
        {

            this.label5.Font = new Font(label5.Font, FontStyle.Regular);
        }


        void label5_MouseEnter(object sender, EventArgs e)
        {

            this.label5.Font = new Font(label5.Font, FontStyle.Bold);
        }

        public void porukaGradjanima()
        {

            ////////////  label naslov poruke   ///////////////
            Label l = new Label();
            l.Text = "Наслов поруке:";
            l.Location = new Point(20,20);
            splitContainer2.Panel1.Controls.Add(l);
            ///////////////////////////////////////////////////

            //////////////  textbox naslova poruke  ///////////
            TextBox textNaslova = new TextBox();
            textNaslova.Location = new Point(20,50);
            textNaslova.Size = new Size(300,20);
            splitContainer2.Panel1.Controls.Add(textNaslova);
            ///////////////////////////////////////////////////
            
            //////////////  label unosTeksta   ////////////////
            Label l2 = new Label();
            l2.Text = "Унесите текст поруке (максимално 250 словних знакова)";
            l2.Location = new Point(20,80);
            l2.Size = new Size(350,20);
            splitContainer2.Panel1.Controls.Add(l2);
            ////////////////////////////////////////////////////
            
            /////////////// textbox tekst poruke  //////////////
            TextBox textPoruke = new TextBox();
            textPoruke.Multiline = true;
            textPoruke.Location = new Point(20, 110);
            textPoruke.Size = new Size(300, 250);
            splitContainer2.Panel1.Controls.Add(textPoruke);
            ////////////////////////////////////////////////////
            
            //////////////  label unosa datuma  ///////////////
            Label l3 = new Label();
            l3.Text = "Унесите датум до када је порука активна";
            l3.Location = new Point(20, 380);
            l3.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(l3);
            /////////////////////////////////////////////////////
            
            /////////////  datetime box   ///////////////////////
            DateTimePicker datumIsteka = new DateTimePicker();
            datumIsteka.Location = new Point(20,410);
            datumIsteka.Size = new Size(300,20);
            splitContainer2.Panel1.Controls.Add(datumIsteka);
            ///////////////////////////////////////////////////

            ///////////////  Button  ////////////////////////////
            Button btn = new Button();
            btn.Location = new Point(220,450);
            btn.Size = new Size(100,30);
            btn.Text = "Пошаљи";
            splitContainer2.Panel1.Controls.Add(btn);
            btn.Click += (s, e) => ////////////// odavde ide kod za if_button_clicked
            {
               
                string a, b, c, d;
                
                a = textNaslova.Text;
                b = textPoruke.Text;
                c = datumIsteka.Value.ToString("yyyy-MM-dd");
                d = DateTime.Now.ToString("yyyy-MM-dd");

                if (a != "")
                {
                    if (b != "")
                    {
                        if (datumIsteka.Value > DateTime.Now)
                        {
                            DialogResult dijalog = MessageBox.Show("Порука изгледа овако: " + Environment.NewLine + "Наслов: " + a + Environment.NewLine + "Текст поруке: " + b + Environment.NewLine + "Порука је валидна до: " + c, "Да ли желите да пошањете поруку?", MessageBoxButtons.YesNo);

                            if (dijalog == DialogResult.Yes)
                            {

                                Cursor.Current = Cursors.WaitCursor;
                                
                                /////////// slanje JSON-a php-u na serveru  ////////////

                                Dictionary<string, string> keyValues = new Dictionary<string, string>();
                                keyValues.Add("tekstNaslova", a);
                                keyValues.Add("tekstPoruke", b);
                                keyValues.Add("datumIsteka", c);
                                keyValues.Add("datumSada", d);
                                JavaScriptSerializer js = new JavaScriptSerializer();
                                string json = js.Serialize(keyValues);

                                WebClient webClient = new WebClient();
                                NameValueCollection formData = new NameValueCollection();
                                formData.Add("a", json);

                                byte[] response = webClient.UploadValues("http://www.igorion.in.rs/LSInfo/SremskiKarlovci/PhpToSql.php", "POST", formData);
                                string responsebody = Encoding.UTF8.GetString(response);
                                MessageBox.Show("" + responsebody);

                                Cursor.Current = Cursors.Default;
                            }
                            if (dijalog == DialogResult.No)
                            { 
                                textNaslova.Text = "";
                                textPoruke.Text = "";

                            }



                        }
                        else
                        {
                            MessageBox.Show("Датум није добро одређен!", "Пажња!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }

                    }
                    else { MessageBox.Show("Морате унети текст поруке!", "Пажња!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); }

                }
                else { MessageBox.Show("Морате унети назив поруке!", "Пажња!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); }

            };
            /////////////////////////////////////////////////////

        }

        public void upitnikGradjanima()
        {
            ////////////  label naslov pitanja   ///////////////
            Label ln = new Label();
            ln.Text = "Унесите наслов питања:";
            ln.Location = new Point(20, 20);
            ln.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(ln);
            ///////////////////////////////////////////////////

            /////////////  textbox naslova pitanja  /////////
            TextBox tekstNaslova = new TextBox();
            tekstNaslova.Location = new Point(20, 50);
            tekstNaslova.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(tekstNaslova);
            ////////////////////////////////////////////////////////

            ////////////  label tekst pitanja   ///////////////
            Label l = new Label();
            l.Text = "Унесите текст питања:";
            l.Location = new Point(20,80);
            l.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(l);
            ///////////////////////////////////////////////////

            /////////////// textbox tekst pitanja  //////////////
            TextBox textPitanja = new TextBox();
            textPitanja.Multiline = true;
            textPitanja.Location = new Point(20, 110);
            textPitanja.Size = new Size(350, 250);
            splitContainer2.Panel1.Controls.Add(textPitanja);
            ////////////////////////////////////////////////////

            ////////////  label ponudjen odgovor 1   ///////////////
            Label o1 = new Label();
            o1.Text = "Унесите понуђен одговор број 1";
            o1.Location = new Point(20, 380);
            o1.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(o1);
            ///////////////////////////////////////////////////

            /////////////  textbox ponudjenog odgovora 1  /////////
            TextBox odg1 = new TextBox();
            odg1.Location = new Point(20, 410);
            odg1.Size = new Size(350,20);
            splitContainer2.Panel1.Controls.Add(odg1);
            ////////////////////////////////////////////////////////

            ////////////  label ponudjen odgovor 2   ///////////////
            Label o2 = new Label();
            o2.Text = "Унесите понуђен одговор број 2";
            o2.Location = new Point(20, 440);
            o2.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(o2);
            ///////////////////////////////////////////////////

            /////////////  textbox ponudjenog odgovora 2  /////////
            TextBox odg2 = new TextBox();
            odg2.Location = new Point(20, 470);
            odg2.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(odg2);
            ////////////////////////////////////////////////////////

            ////////////  label ponudjen odgovor 3   ///////////////
            Label o3 = new Label();
            o3.Text = "Унесите понуђен одговор број 3";
            o3.Location = new Point(20, 500);
            o3.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(o3);
            ///////////////////////////////////////////////////

            /////////////  textbox ponudjenog odgovora 3  /////////
            TextBox odg3 = new TextBox();
            odg3.Location = new Point(20, 530);
            odg3.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(odg3);
            ////////////////////////////////////////////////////////

            ////////////  label ponudjen odgovor 4   ///////////////
            Label o4 = new Label();
            o4.Text = "Унесите понуђен одговор број 4";
            o4.Location = new Point(20, 560);
            o4.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(o4);
            ///////////////////////////////////////////////////

            /////////////  textbox ponudjenog odgovora 4  /////////
            TextBox odg4 = new TextBox();
            odg4.Location = new Point(20, 590);
            odg4.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(odg4);
            ////////////////////////////////////////////////////////

            ////////////  label ponudjen odgovor 5   ///////////////
            Label o5 = new Label();
            o5.Text = "Унесите понуђен одговор број 5";
            o5.Location = new Point(20, 620);
            o5.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(o5);
            ///////////////////////////////////////////////////

            /////////////  textbox ponudjenog odgovora 5  /////////
            TextBox odg5 = new TextBox();
            odg5.Location = new Point(20, 650);
            odg5.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(odg5);
            ////////////////////////////////////////////////////////

            ////////////  label ponudjen datetime   ///////////////
            Label dtp = new Label();
            dtp.Text = "Унесите датум до када је питање актуелно";
            dtp.Location = new Point(20, 680);
            dtp.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(dtp);
            ///////////////////////////////////////////////////

            /////////////  datetime box   ///////////////////////
            DateTimePicker datumIstekaUpitnika = new DateTimePicker();
            datumIstekaUpitnika.Location = new Point(20, 710);
            datumIstekaUpitnika.Size = new Size(350, 20);
            splitContainer2.Panel1.Controls.Add(datumIstekaUpitnika);
            ///////////////////////////////////////////////////

            ///////////////  Button  ////////////////////////////
            Button btnUpitnik = new Button();
            btnUpitnik.Location = new Point(270, 770);
            btnUpitnik.Size = new Size(100, 30);
            btnUpitnik.Text = "Пошаљи";
            splitContainer2.Panel1.Controls.Add(btnUpitnik);
            btnUpitnik.Click += (s, e) => ////////////// odavde ide kod za if_button_clicked
            {
                string aa, a, b,c,d,f,g, h, i;
                aa = tekstNaslova.Text;
                a = textPitanja.Text;
                b = odg1.Text;
                c = odg2.Text;
                d = odg3.Text;
                f = odg4.Text;
                g = odg5.Text;
                h = datumIstekaUpitnika.Value.ToString("yyyy-MM-dd");
                i = DateTime.Now.ToString("yyyy-MM-dd");

                //MessageBox.Show("" + a + " " + b + " " + c + " " + d + " " + f + " " + g);


                if (a != "")
                {

                    if (datumIstekaUpitnika.Value > DateTime.Now)
                    {
                        DialogResult dijalog = MessageBox.Show("Питање изгледа овако: " + Environment.NewLine + "Наслов: " + a + Environment.NewLine + "Одговор 1: " + b + Environment.NewLine + "Одговор 2: " + c + Environment.NewLine + "Одговор 3: " + d + Environment.NewLine + "Одговор 4: " + f + Environment.NewLine + "Одговор 5: " + g + Environment.NewLine + "Порука је валидна до: " + h, "Да ли желите да пошањете поруку?", MessageBoxButtons.YesNo);

                        if (dijalog == DialogResult.Yes)
                        {

                            Cursor.Current = Cursors.WaitCursor;

                            /////////// slanje JSON-a php-u na serveru  ////////////

                            Dictionary<string, string> keyValues = new Dictionary<string, string>();
                            keyValues.Add("tekstNaslova", aa); 
                            keyValues.Add("tekstPitanja", a);
                            keyValues.Add("odgovor1", b);
                            keyValues.Add("odgovor2", c);
                            keyValues.Add("odgovor3", d);
                            keyValues.Add("odgovor4", f);
                            keyValues.Add("odgovor5", g);
                            keyValues.Add("datumIstekaUpitnika", h);
                            keyValues.Add("datumSadaUpitnika", i);
                            JavaScriptSerializer js = new JavaScriptSerializer();
                            string json = js.Serialize(keyValues);

                            WebClient webClient = new WebClient();
                            NameValueCollection formData = new NameValueCollection();
                            formData.Add("a", json);

                            byte[] response = webClient.UploadValues("http://www.igorion.in.rs/LSInfo/SremskiKarlovci/PhpToSqlUpitnik.php", "POST", formData);
                            string responsebody = Encoding.UTF8.GetString(response);
                            MessageBox.Show("" + responsebody);

                            Cursor.Current = Cursors.Default;
                        }
                        if (dijalog == DialogResult.No)
                        {
                            textPitanja.Text = "";
                            odg1.Text = "";
                            odg2.Text = "";
                            odg3.Text = "";
                            odg4.Text = "";
                            odg5.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Датум није добро одређен!", "Пажња!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }
                else { MessageBox.Show("Морате унети текст питања!", "Пажња!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1); }          

            };
            /////////////////////////////////////////////////////


        }


        public void pregledPoruka()
        { 
            ///////////////////////////// label lista poruka  //////////////////////
            Label labelLista = new Label();
            labelLista.Location = new Point(20,20);
            labelLista.Size = new Size(350,20);
            labelLista.Text = "Листа порука упућених грађанима:";
            splitContainer2.Panel1.Controls.Add(labelLista);
            ////////////////////////////////////////////////////////////////////////

            /////////////////  listbox sa do sada poslatim porukama  ////////////////
            ListView lstViewPoruke = new ListView();
            lstViewPoruke.Location = new Point(20, 50);
            lstViewPoruke.Size = new Size(ans - 550, 200);
            lstViewPoruke.View = View.Details;            
            lstViewPoruke.Columns.Add("Naziv poruke");
            lstViewPoruke.Columns.Add("Tekst poruke");
            lstViewPoruke.Columns.Add("Datum unosa poruke");            
            lstViewPoruke.Columns.Add("Datum isteka poruke");
            lstViewPoruke.Columns.Add("Број прегледа");

            Cursor.Current = Cursors.WaitCursor;
            
            string trt = " ";
            WebClient webClient = new WebClient();
            NameValueCollection formData = new NameValueCollection();
            formData.Add("a", trt);

            byte[] response = webClient.UploadValues("http://www.igorion.in.rs/LSInfo/SremskiKarlovci/porukePregled.php", "POST", formData);
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
            ////////////////////////////////////////////////////////////////////////

            //////////////////  Label naslov poruke  /////////////////////

            Label labelNaslovPoruke = new Label();
            labelNaslovPoruke.Size = new Size(380,20);
            labelNaslovPoruke.Location = new Point(20,350);
            labelNaslovPoruke.Text = "Наслов поруке";               ////////////// Ovo ce se menjati klikom na button
            splitContainer2.Panel1.Controls.Add(labelNaslovPoruke);
            //////////////////////////////////////////////////////////////

            /////////////////  label DAtum уноса poruke   ////////////////
            Label labelDatumUnosaPoruke = new Label();
            labelDatumUnosaPoruke.Size = new Size(350, 20);
            labelDatumUnosaPoruke.Location = new Point(20, 410);
            labelDatumUnosaPoruke.Text = "Датум уноса поруке";                    ////////////// Ovo ce se menjati klikom na button
            splitContainer2.Panel1.Controls.Add(labelDatumUnosaPoruke);
            /////////////////////////////////////////////////////////

            /////////////////  label DAtum истека poruke   ////////////////
            Label labelDatumIstekaPoruke = new Label();
            labelDatumIstekaPoruke.Size = new Size(350, 20);
            labelDatumIstekaPoruke.Location = new Point(20, 440);
            labelDatumIstekaPoruke.Text = "Датум до када је порука била активна";                    ////////////// Ovo ce se menjati klikom na button
            splitContainer2.Panel1.Controls.Add(labelDatumIstekaPoruke);
            /////////////////////////////////////////////////////////

            ///////////////// label teksta poruke   ///////////////////////
            Label labelTekstaPoruke = new Label();
            labelTekstaPoruke.Location = new Point(20,380);
            labelTekstaPoruke.Size = new Size(300,30);
            labelTekstaPoruke.Text = "Овде ће се наћи изабрани текст";                    ////////////// Ovo ce se menjati klikom na button
            splitContainer2.Panel1.Controls.Add(labelTekstaPoruke);
            ////////////////////////////////////////////////////////////

            ////////////////// label broja pregleda poruke  ///////////////
            Label labelBrojPregledaPoruke = new Label();
            labelBrojPregledaPoruke.Location = new Point(20, 470);
            labelBrojPregledaPoruke.Size = new Size(300, 20);
            labelBrojPregledaPoruke.Text = "Број прегледа поруке";                         ////////////// Ovo ce se menjati klikom na button
            splitContainer2.Panel1.Controls.Add(labelBrojPregledaPoruke);
            ////////////////////////////////////////////////////////////////

            //////////////////////////  crtanje linije   //////////////////////////////////
            System.Drawing.Graphics graphicsObj;
            graphicsObj = splitContainer2.Panel1.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Gray, 2);
            graphicsObj.DrawLine(myPen, 20, 330, ans - 530, 330);
            
            ///////////////////////////////////////////////////////////////////////////



            /////////////////   Button prelgledPoruke ////////////////////////////////
            Button bPregledPoruke = new Button();
            bPregledPoruke.Size = new Size(100, 30);
            bPregledPoruke.Location = new Point(20,270);
            bPregledPoruke.Text = "Погледај поруку";
            splitContainer2.Panel1.Controls.Add(bPregledPoruke);

            bPregledPoruke.Click += (s, e) => ////////////// odavde ide kod za if_button_clicked
            {


                if (lstViewPoruke.SelectedItems.Count > 0)
                {
                    ListViewItem item = lstViewPoruke.SelectedItems[0];
                    labelNaslovPoruke.Text = "Наслов поруке: " + item.Text;
                    labelDatumUnosaPoruke.Text = "Датум поруке: " + item.SubItems[2].Text;
                    labelDatumIstekaPoruke.Text = "Порука је била активна до: " + item.SubItems[3].Text;
                    labelTekstaPoruke.Text = "Текст поруке: " + item.SubItems[1].Text;
                    labelBrojPregledaPoruke.Text = "Порука је погледана " + item.SubItems[4].Text + " пута.";

                }
                else
                {
                    MessageBox.Show("Морате обележити једну од порука!");
                }
            };
            //////////////////////////////////////////////////////////////////////////          
  

            //////////////  dupli klik na naki od itema //////////////
            lstViewPoruke.DoubleClick += (Object s, EventArgs e) =>
                {
                    ListViewItem item = lstViewPoruke.SelectedItems[0];
                    labelNaslovPoruke.Text = "Наслов поруке: " + item.Text;
                    labelDatumUnosaPoruke.Text = "Датум поруке: " + item.SubItems[2].Text;
                    labelDatumIstekaPoruke.Text = "Порука је била активна до: " + item.SubItems[3].Text;
                    labelTekstaPoruke.Text = "Текст поруке: " + item.SubItems[1].Text;
                    labelBrojPregledaPoruke.Text = "Порука је погледана " + item.SubItems[4].Text + " пута.";
                };
            ///////////////////////////////////////////////////////////
        }


       


        public void pregledUpitnika()
        {
            ///////////////////////////// label lista ptanja  //////////////////////
            Label labelListaUpitnik = new Label();
            labelListaUpitnik.Location = new Point(20, 20);
            labelListaUpitnik.Size = new Size(350, 20);
            labelListaUpitnik.Text = "Листа питања постављених грађанима:";
            splitContainer2.Panel1.Controls.Add(labelListaUpitnik);
            ////////////////////////////////////////////////////////////////////////

            /////////////////  listbox sa do sada poslatim pitanjima  ////////////////
            ListView lstViewPitanja = new ListView();
            lstViewPitanja.Location = new Point(20, 50);
            lstViewPitanja.Size = new Size(ans - 550, 200);
            lstViewPitanja.View = View.Details;
            lstViewPitanja.Columns.Add("Текст питања");
            lstViewPitanja.Columns.Add("Понуђен одговор 1.");
            lstViewPitanja.Columns.Add("Понуђен одговор 2.");
            lstViewPitanja.Columns.Add("Понуђен одговор 3.");
            lstViewPitanja.Columns.Add("Понуђен одговор 4.");
            lstViewPitanja.Columns.Add("Понуђен одговор 5.");
            lstViewPitanja.Columns.Add("Датум уноса питања");
            lstViewPitanja.Columns.Add("Датум истека питања");

            Cursor.Current = Cursors.WaitCursor;

            string trt = " ";
            WebClient webClient = new WebClient();
            NameValueCollection formData = new NameValueCollection();
            formData.Add("a", trt);

            byte[] response = webClient.UploadValues("http://www.igorion.in.rs/LSInfo/SremskiKarlovci/upitnikPregled.php", "POST", formData);
            string responsebody = Encoding.UTF8.GetString(response);

            JavaScriptSerializer js = new JavaScriptSerializer();
            prijemUpitnik[] pitanje = js.Deserialize<prijemUpitnik[]>(responsebody);


            for (int aList = 0; aList < pitanje.LongLength; aList++)
            {
                ListViewItem item = new ListViewItem(pitanje[aList].tekstPitanja);
                item.SubItems.Add("" + pitanje[aList].odgovor1);
                item.SubItems.Add("" + pitanje[aList].odgovor2);
                item.SubItems.Add("" + pitanje[aList].odgovor3);
                item.SubItems.Add("" + pitanje[aList].odgovor4);
                item.SubItems.Add("" + pitanje[aList].odgovor5);
                item.SubItems.Add("" + DateTime.ParseExact(pitanje[aList].datumSadaUpitnika, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("dddd, dd. MMMM yyyy.", new CultureInfo("sr-Cyrl-CS"))); //DateTime.ParseExact("12/02/21 10:56:09", "yy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("MMM. dd, yyyy HH:mm:ss");
                item.SubItems.Add("" + DateTime.ParseExact(pitanje[aList].datumIstekaUpitnika, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture).ToString("dddd, dd. MMMM yyyy.", new CultureInfo("sr-Cyrl-CS"))); //DateTime.ParseExact("12/02/21 10:56:09", "yy/MM/dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture).ToString("MMM. dd, yyyy HH:mm:ss");
                //item.SubItems.Add("" + pitanje[aList].datumIstekaUpitnika);
                item.SubItems.Add("" + pitanje[aList].kolikoOdgovoraPod1);
                item.SubItems.Add("" + pitanje[aList].kolikoOdgovoraPod2);
                item.SubItems.Add("" + pitanje[aList].kolikoOdgovoraPod3);
                item.SubItems.Add("" + pitanje[aList].kolikoOdgovoraPod4);
                item.SubItems.Add("" + pitanje[aList].kolikoOdgovoraPod5);
                item.SubItems.Add("" + pitanje[aList].kolikoOdgovora);

                lstViewPitanja.Items.Add(item);
            }

            lstViewPitanja.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            splitContainer2.Panel1.Controls.Add(lstViewPitanja);
            Cursor.Current = Cursors.Default;
            ////////////////////////////////////////////////////////////////////////

            //////////////////////////  crtanje linije   //////////////////////////////////
            System.Drawing.Graphics graphicsObj;
            graphicsObj = splitContainer2.Panel1.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Gray, 2);
            graphicsObj.DrawLine(myPen, 20, 330, ans - 530, 330);
            ///////////////////////////////////////////////////////////////////////////

            ///////////////////////////// label odabrano pitanje  //////////////////////
            Label labelOdabranoPitanje = new Label();
            labelOdabranoPitanje.Location = new Point(20, 360);
            labelOdabranoPitanje.Size = new Size(750, 20);
            labelOdabranoPitanje.Text = "Одабрано питање";
            splitContainer2.Panel1.Controls.Add(labelOdabranoPitanje);
            ////////////////////////////////////////////////////////////////////////

            ///////////////////////////// label ponudjen odgovor 1  //////////////////////
            Label labelodgovor1 = new Label();
            labelodgovor1.Location = new Point(20, 390);
            labelodgovor1.Size = new Size(750, 20);
            labelodgovor1.Text = "Понуђен одговор број 1";
            splitContainer2.Panel1.Controls.Add(labelodgovor1);
            ////////////////////////////////////////////////////////////////////////

            ///////////////////////////// label ponudjen odgovor 2  //////////////////////
            Label labelodgovor2 = new Label();
            labelodgovor2.Location = new Point(20, 420);
            labelodgovor2.Size = new Size(750, 20);
            labelodgovor2.Text = "Понуђен одговор број 2";
            splitContainer2.Panel1.Controls.Add(labelodgovor2);
            ////////////////////////////////////////////////////////////////////////

            ///////////////////////////// label ponudjen odgovor 3  //////////////////////
            Label labelodgovor3 = new Label();
            labelodgovor3.Location = new Point(20, 450);
            labelodgovor3.Size = new Size(750, 20);
            labelodgovor3.Text = "Понуђен одговор број 3";
            splitContainer2.Panel1.Controls.Add(labelodgovor3);
            ////////////////////////////////////////////////////////////////////////

            ///////////////////////////// label ponudjen odgovor 4  //////////////////////
            Label labelodgovor4 = new Label();
            labelodgovor4.Location = new Point(20, 480);
            labelodgovor4.Size = new Size(750, 20);
            labelodgovor4.Text = "Понуђен одговор број 4";
            splitContainer2.Panel1.Controls.Add(labelodgovor4);
            ////////////////////////////////////////////////////////////////////////

            ///////////////////////////// label ponudjen odgovor 5  //////////////////////
            Label labelodgovor5 = new Label();
            labelodgovor5.Location = new Point(20, 510);
            labelodgovor5.Size = new Size(750, 20);
            labelodgovor5.Text = "Понуђен одговор број 5";
            splitContainer2.Panel1.Controls.Add(labelodgovor5);
            ////////////////////////////////////////////////////////////////////////

            //////////////////////// label datum unosa pitanja  ////////////////////
            Label datumUnosaPitanja = new Label();
            datumUnosaPitanja.Location = new Point(20, 540);
            datumUnosaPitanja.Size = new Size(750, 20);
            datumUnosaPitanja.Text = "Датум уноса питања: ";
            splitContainer2.Panel1.Controls.Add(datumUnosaPitanja);
            ////////////////////////////////////////////////////////////////////////

            //////////////////////// label datum isteka pitanja  ////////////////////
            Label datumIstekaPitanja = new Label();
            datumIstekaPitanja.Location = new Point(20, 570);
            datumIstekaPitanja.Size = new Size(750, 20);
            datumIstekaPitanja.Text = "Датум до када је питање било активно: ";
            splitContainer2.Panel1.Controls.Add(datumIstekaPitanja);
            ////////////////////////////////////////////////////////////////////////


            /////////////////   Button prelgledPoruke ////////////////////////////////
            Button bPregledPoruke = new Button();
            bPregledPoruke.Size = new Size(100, 30);
            bPregledPoruke.Location = new Point(20, 270);
            bPregledPoruke.Text = "Погледај поруку";
            splitContainer2.Panel1.Controls.Add(bPregledPoruke);

            bPregledPoruke.Click += (s, e) => ////////////// odavde ide kod za if_button_clicked
            {

                ///////////////////  racunanje procenata  /////////////////////
              
                

                if (lstViewPitanja.SelectedItems.Count > 0)
                {

                    ListViewItem item = lstViewPitanja.SelectedItems[0];

                    int absVrednostodg1 = 0;
                    int absVrednostodg2 = 0;
                    int absVrednostodg3 = 0;
                    int absVrednostodg4 = 0;
                    int absVrednostodg5 = 0;
                    int ukupnoOdgovora = 0;
                    double procenatOdg1 = 0;
                    double procenatOdg2 = 0;
                    double procenatOdg3 = 0;
                    double procenatOdg4 = 0;
                    double procenatOdg5 = 0;

                    absVrednostodg1 = Int32.Parse(item.SubItems[8].Text);
                    absVrednostodg2 = Int32.Parse(item.SubItems[9].Text);
                    absVrednostodg3 = Int32.Parse(item.SubItems[10].Text);
                    absVrednostodg4 = Int32.Parse(item.SubItems[11].Text);
                    absVrednostodg5 = Int32.Parse(item.SubItems[12].Text);
                    ukupnoOdgovora = Int32.Parse(item.SubItems[13].Text);
                    procenatOdg1 = (double)(absVrednostodg1 * 100) / ukupnoOdgovora;
                    procenatOdg2 = (double)(absVrednostodg2 * 100) / ukupnoOdgovora;
                    procenatOdg3 = (double)(absVrednostodg3 * 100) / ukupnoOdgovora; 
                    procenatOdg4 = (double)(absVrednostodg4 * 100) / ukupnoOdgovora;
                    procenatOdg5 = (double)(absVrednostodg5 * 100) / ukupnoOdgovora; 

                   
                    
                    labelOdabranoPitanje.Text = item.Text;
                    labelodgovor1.Text = "Понуђен одговор број 1 је: " + item.SubItems[1].Text + ". Овај одговор је дало: " + item.SubItems[8].Text + " корисника. (" + Math.Round(procenatOdg1, 2, MidpointRounding.ToEven) + "%)";
                    labelodgovor2.Text = "Понуђен одговор број 2 је: " + item.SubItems[2].Text + ". Овај одговор је дало: " + item.SubItems[9].Text + " корисника. (" + Math.Round(procenatOdg2, 2, MidpointRounding.ToEven) + "%)";
                    labelodgovor3.Text = "Понуђен одговор број 3 је: " + item.SubItems[3].Text + ". Овај одговор је дало: " + item.SubItems[10].Text + " корисника. (" + Math.Round(procenatOdg3, 2, MidpointRounding.ToEven) + "%)";
                    labelodgovor4.Text = "Понуђен одговор број 4 је: " + item.SubItems[4].Text + ". Овај одговор је дало: " + item.SubItems[11].Text + " корисника. (" + Math.Round(procenatOdg4,2,MidpointRounding.ToEven) + "%)";
                    labelodgovor5.Text = "Понуђен одговор број 5 је: " + item.SubItems[5].Text + ". Овај одговор је дало: " + item.SubItems[12].Text + " корисника. (" + Math.Round(procenatOdg5, 2, MidpointRounding.ToEven) + "%)";
                    datumUnosaPitanja.Text = "Питања је постављено дана: " + item.SubItems[6].Text;
                    datumIstekaPitanja.Text = "Питање је било активно до: " + item.SubItems[7].Text;

                }
                else
                {
                    MessageBox.Show("Морате обележити једно од питања!");
                }


                
            };
            //////////////////////////////////////////////////////////////////////////   

            lstViewPitanja.DoubleClick += (Object s, EventArgs e) =>
            {
                ListViewItem item = lstViewPitanja.SelectedItems[0];

                int absVrednostodg1 = 0;
                int absVrednostodg2 = 0;
                int absVrednostodg3 = 0;
                int absVrednostodg4 = 0;
                int absVrednostodg5 = 0;
                int ukupnoOdgovora = 0;
                double procenatOdg1 = 0;
                double procenatOdg2 = 0;
                double procenatOdg3 = 0;
                double procenatOdg4 = 0;
                double procenatOdg5 = 0;

                absVrednostodg1 = Int32.Parse(item.SubItems[8].Text);
                absVrednostodg2 = Int32.Parse(item.SubItems[9].Text);
                absVrednostodg3 = Int32.Parse(item.SubItems[10].Text);
                absVrednostodg4 = Int32.Parse(item.SubItems[11].Text);
                absVrednostodg5 = Int32.Parse(item.SubItems[12].Text);
                ukupnoOdgovora = Int32.Parse(item.SubItems[13].Text);
                procenatOdg1 = (double)(absVrednostodg1 * 100) / ukupnoOdgovora;
                procenatOdg2 = (double)(absVrednostodg2 * 100) / ukupnoOdgovora;
                procenatOdg3 = (double)(absVrednostodg3 * 100) / ukupnoOdgovora;
                procenatOdg4 = (double)(absVrednostodg4 * 100) / ukupnoOdgovora;
                procenatOdg5 = (double)(absVrednostodg5 * 100) / ukupnoOdgovora;



                labelOdabranoPitanje.Text = item.Text;
                labelodgovor1.Text = "Понуђен одговор број 1 је: " + item.SubItems[1].Text + ". Овај одговор је дало: " + item.SubItems[8].Text + " корисника. (" + Math.Round(procenatOdg1, 2, MidpointRounding.ToEven) + "%)";
                labelodgovor2.Text = "Понуђен одговор број 2 је: " + item.SubItems[2].Text + ". Овај одговор је дало: " + item.SubItems[9].Text + " корисника. (" + Math.Round(procenatOdg2, 2, MidpointRounding.ToEven) + "%)";
                labelodgovor3.Text = "Понуђен одговор број 3 је: " + item.SubItems[3].Text + ". Овај одговор је дало: " + item.SubItems[10].Text + " корисника. (" + Math.Round(procenatOdg3, 2, MidpointRounding.ToEven) + "%)";
                labelodgovor4.Text = "Понуђен одговор број 4 је: " + item.SubItems[4].Text + ". Овај одговор је дало: " + item.SubItems[11].Text + " корисника. (" + Math.Round(procenatOdg4, 2, MidpointRounding.ToEven) + "%)";
                labelodgovor5.Text = "Понуђен одговор број 5 је: " + item.SubItems[5].Text + ". Овај одговор је дало: " + item.SubItems[12].Text + " корисника. (" + Math.Round(procenatOdg5, 2, MidpointRounding.ToEven) + "%)";
                datumUnosaPitanja.Text = "Питања је постављено дана: " + item.SubItems[6].Text;
                datumIstekaPitanja.Text = "Питање је било активно до: " + item.SubItems[7].Text;
            };
        }


        public void proveraInterneta()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "google.com";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                //return (reply.Status == IPStatus.Success);
                //MessageBox.Show("ima neta");
            }
            catch (Exception)
            {
                //return false;
                //MessageBox.Show("nema neta");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public void passwordForm()
        {
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;

            Cursor.Current = Cursors.WaitCursor;


            WebClient webClient = new WebClient();
            NameValueCollection formData = new NameValueCollection();
            formData.Add("nazivOpstine", opstina);

            byte[] response = webClient.UploadValues("http://www.igorion.in.rs/LSInfo/passwordRed.php", formData);
            string responsebody = Encoding.UTF8.GetString(response);
            JavaScriptSerializer js = new JavaScriptSerializer();
            passwordOpstina[] podaciOOpstini = js.Deserialize<passwordOpstina[]>(responsebody);

            string nazivOpstineWeb = podaciOOpstini[0].nazivOpstine;
            string userNameWeb = podaciOOpstini[0].userName;
            string passwordWeb = podaciOOpstini[0].password;
            string mailWeb = podaciOOpstini[0].mail;
            string nivoKoriscenjaWeb = podaciOOpstini[0].nivoKoriscenja;


            if (nazivOpstineWeb == "nema")
            {
                generisiPassword();
            }
            else
            {
                traziUserPass();
            }



            ////////////  le   ///////////////
            Label l = new Label();
            l.Text = opstina;
            l.Location = new Point(20, 20);
            l.Size = new Size(250, 20);
            l.Font = new Font("Arial", 12, FontStyle.Bold);

            splitContainer2.Panel1.Controls.Add(l);
            ///////////////////////////////////////////////////



         



        }
        public void traziUserPass()
        {
            Label userNameLabel = new Label();
            userNameLabel.Text = "Корисничко име: ";
            userNameLabel.Size = new Size(100, 20);
            userNameLabel.Location = new Point(270, 23);
            splitContainer2.Panel1.Controls.Add(userNameLabel);

            TextBox usernameTxtBox = new TextBox();
            usernameTxtBox.Size = new Size(100, 10);
            usernameTxtBox.Location = new Point(370, 15);
            usernameTxtBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#E6E6E6");
            usernameTxtBox.PasswordChar = '*';
            splitContainer2.Panel1.Controls.Add(usernameTxtBox);

            Label passWordLabel = new Label();
            passWordLabel.Text = "Лозинка: ";
            passWordLabel.Size = new Size(55, 20);
            passWordLabel.Location = new Point(485, 23);
            splitContainer2.Panel1.Controls.Add(passWordLabel);

            TextBox passWordTxtBox = new TextBox();
            passWordTxtBox.Size = new Size(100, 10);
            passWordTxtBox.Location = new Point(545, 15);
            passWordTxtBox.BackColor = System.Drawing.ColorTranslator.FromHtml("#E6E6E6");
            passWordTxtBox.PasswordChar = '*';
            splitContainer2.Panel1.Controls.Add(passWordTxtBox);


            Button logIn = new Button();
            logIn.Text = "Улогујте се";
            logIn.Size = new Size(100, 20);
            logIn.Location = new Point(660, 15);
            logIn.Font = new Font("Arial", 8);
            splitContainer2.Panel1.Controls.Add(logIn);
            logIn.Click += (s, e) =>
                {
                    Cursor.Current = Cursors.WaitCursor;


                    WebClient webClient = new WebClient();
                    NameValueCollection formData = new NameValueCollection();
                    formData.Add("nazivOpstine", opstina);

                    byte[] response = webClient.UploadValues("http://www.igorion.in.rs/LSInfo/passwordRed.php", formData);
                    string responsebody = Encoding.UTF8.GetString(response);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    passwordOpstina[] podaciOOpstini = js.Deserialize<passwordOpstina[]>(responsebody);

                    string nazivOpstineWeb = podaciOOpstini[0].nazivOpstine;
                    string userNameWeb = podaciOOpstini[0].userName;
                    string passwordWeb = podaciOOpstini[0].password;
                    string mailWeb = podaciOOpstini[0].mail;
                    string nivoKoriscenjaWeb = podaciOOpstini[0].nivoKoriscenja;

                    string userNameIzTxTBoxa = usernameTxtBox.Text;
                    string passwordIzTxTBoxa = passWordTxtBox.Text;

                    if (passwordWeb == passwordIzTxTBoxa && userNameWeb == userNameIzTxTBoxa && nivoKoriscenjaWeb == "3")
                    {
                        MessageBox.Show("Имате могућност неограниченог коришћења система");
                        ocistiKontejner2();
                        label2.Enabled = true;
                        label3.Enabled = true;
                        label4.Enabled = true;
                        label5.Enabled = true;
                    }
                    else if (passwordWeb == passwordIzTxTBoxa && userNameWeb == userNameIzTxTBoxa && nivoKoriscenjaWeb == "2")
                    {
                        MessageBox.Show("Имате ограничен приступ систему");
                        ocistiKontejner2();
                        label2.Enabled = true;
                        label3.Enabled = true;
                        label4.Enabled = false;
                        label5.Enabled = false;
                    }
                    else if (passwordWeb == passwordIzTxTBoxa && userNameWeb == userNameIzTxTBoxa && nivoKoriscenjaWeb == "1")
                    {
                        MessageBox.Show("Жао нам је. Пробни период је истекао!");
                        ocistiKontejner2();
                        label2.Enabled = false;
                        label3.Enabled = false;
                        label4.Enabled = false;
                        label5.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Нису правилно унети корисничко име или лозинка ");
                        usernameTxtBox.Text = "";
                        passWordTxtBox.Text = "";
                    }
                    
                };

        }

        public void generisiPassword()
        {
            Random random = new Random();
            string input = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < 8; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            string userName = builder.ToString();

            for (int i = 8; i < 16; i++)
            {
                ch = input[random.Next(0, input.Length)];
                builder.Append(ch);
            }
            string password1 = builder.ToString();
            string password = password1.Substring(password1.Length - Math.Min(8, password1.Length));


            /////////// ovo treba da posalje mail   ////////////////
            string mailZaSlanje = "lsinfo.app@gmail.com";

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.UseDefaultCredentials = true;
            client.EnableSsl = true;
            client.Timeout = 100000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(
              "lsinfo.app@gmail.com", "2hermes2");
            MailMessage msg = new MailMessage();
            msg.To.Add(mailZaSlanje);
            msg.From = new MailAddress("lsinfo.app@gmail.com");
            msg.Subject = "LSInfomail";
            msg.Body = "Поштовани систем је аутоматски генерисао Ваше корисничко име и лозинку. Ради сигурности и заштите података ову поруку сте добили само Ви и молимо Вас да сачувате Ваше поверљиве информације."
        + System.Environment.NewLine + "Ваше корисничко име је : " + userName + System.Environment.NewLine + "Ваша лозинка је: " + password;
            client.Send(msg);
            MessageBox.Show("Успешно послат e-mail.");


            //////////  ovo puni sql tabelu sa usernam i password

            WebClient webClient = new WebClient();
            NameValueCollection formData = new NameValueCollection();
            formData["opstina"] = opstina;
            formData["userName"] = userName;
            formData["password"] = password;
            formData["mailZaSlanje"] = mailZaSlanje;
            byte[] response = webClient.UploadValues("http://www.igorion.in.rs/LSInfo/prihvatiUserPass.php", formData);





        }

      
    
       
        
    }
}
