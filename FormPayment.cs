using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SAD_APLIKASI_BEBEK_LUMER_FITUR_PAYMENT_AND_INVOICE
{
    public partial class FormPayment : Form
    {

        // JANGAN LUPA COPY FORM KE INTIALIZZE BLA BLA BLAAA

        public static string connectionString = "server=localhost;uid=root;pwd=root;database=secu";
        public MySqlConnection conn = new MySqlConnection(connectionString);
        public MySqlCommand cmd;
        public MySqlDataAdapter adapter;
        public string sqlQuery;
        DataTable dtCustName = new DataTable();
        DataTable dtSimpanPayment = new DataTable();

        Bitmap memoryImage;
        public FormPayment()
        {
            InitializeComponent();
        }

        PictureBox makeorder = new PictureBox();
        PictureBox payment = new PictureBox();
        PictureBox checkorder = new PictureBox();
        Font BigFont = new Font("Montserrat", 30);

        Button Open = new Button();
        Button Print = new Button();

        Panel print = new Panel();

        ComboBox comboboxCustName = new ComboBox();

        private void Form1_Load(object sender, EventArgs e)
        {
            dtCustName.Rows.Clear();
            /*PictureBox baru = new PictureBox();
            baru.Size = new Size(1920, 781);
            baru.Location = new Point(0, 299);
            baru.Image = imageListFormPayment.Images[0];*/ // @"D:\SAD - AFL 3 PROJECT\T_BACKGROUND"

            panelPayment.BackgroundImage = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_BACKGROUND.png");
            PictureBox logo = new PictureBox();
            logo.Size = new Size(863, 192);
            logo.Location = new Point(-20, -10);
            logo.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_LOGO.png");
            //this.Controls.Add(logo);
            PictureBox tombolback = new PictureBox();
            tombolback.Size = new Size(113, 113);
            tombolback.Location = new Point(1807, 0);
            tombolback.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_TOMBOLBACK.png");
            this.Controls.Add(tombolback);
            PictureBox tombolhome = new PictureBox();
            tombolhome.Size = new Size(113, 113);
            tombolhome.Location = new Point(1694, 0);
            tombolhome.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_TOMBOLHOME.png");
            this.Controls.Add(tombolhome);
            PictureBox txtServices = new PictureBox();
            txtServices.Size = new Size(438, 137);
            txtServices.Location = new Point(63, 157);
            txtServices.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_ServicesTXT.png");
            this.Controls.Add(txtServices);
            txtServices.BringToFront();
            //MAKE ORDER
            makeorder.Size = new Size(282, 66);
            makeorder.Location = new Point(519, 170);
            makeorder.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_MAKEORDER.png");
            this.Controls.Add(makeorder);
            //PAYMENT
            payment.Size = new Size(282, 66);
            payment.Location = new Point(819, 170);
            payment.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_PAYMENTSELECT.png");
            payment.Click += BtnPaymentClick;
            this.Controls.Add(payment);
            //CHECKORDER
            checkorder.Size = new Size(290, 66);
            checkorder.Location = new Point(1118, 170);
            checkorder.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_CHECKORDER.png");
            checkorder.Click += BtnCheckOrder;
            this.Controls.Add(checkorder);
            PictureBox rectangle = new PictureBox();
            rectangle.Size = new Size(560, 64);
            rectangle.Location = new Point(1109, 24);
            rectangle.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_RECTANGLE.png");
            this.Controls.Add(rectangle);
            PictureBox logout = new PictureBox();
            logout.Size = new Size(158, 47);
            logout.Location = new Point(1485, 34);
            logout.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_LOGOUT.png");
            logout.BackColor = Color.Transparent;
            this.Controls.Add(logout);
            logout.BringToFront();

            PictureBox Payment = new PictureBox();
            Payment.Size = new Size(372, 123);
            Payment.Location = new Point(73, 70);
            Payment.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_PAYMENTBSR.png");
            Payment.BackColor = Color.Transparent;
            panelPayment.Controls.Add(Payment);
            Payment.BringToFront();

            //sqlQuery = "SELECT * FROM customer;";
            //cmd = new MySqlCommand(sqlQuery, conn);
            //adapter = new MySqlDataAdapter(cmd);
            //adapter.Fill(dtCustName);
            //comboboxCustName.DataSource = dtCustName;
            //comboboxCustName.ValueMember = "IDcustomer";
            //comboboxCustName.DisplayMember = "nama_customer";

            comboboxCustName.Size = new Size(431, 120);
            comboboxCustName.Location = new Point(73, 220);
            comboboxCustName.BackColor = Color.Chocolate;
            panelPayment.Controls.Add(comboboxCustName);
            comboboxCustName.BringToFront();

            sqlQuery = "SELECT IDcustomer,nama_customer FROM customer;";
            cmd = new MySqlCommand(sqlQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtCustName);
            comboboxCustName.DataSource = dtCustName;
            comboboxCustName.ValueMember = "IDcustomer";
            comboboxCustName.DisplayMember = "nama_customer";

            comboboxCustName.Font = new Font("Montserrat Bold", 15, FontStyle.Bold);

            //Button Open Payment
            Open.Size = new Size(90, 33);
            Open.Location = new Point(520, 220);
            Open.BackColor = Color.Chocolate;
            Open.Text = "OPEN";
            Open.Font = new Font("Montserrat Bold", 15, FontStyle.Bold);
            //Open.ForeColor = Color.White;
            Open.Click += comboboxCustName_ClickPayment;
            panelPayment.Controls.Add(Open);
            Open.BringToFront();

            //Button Print
            Print.Size = new Size(90, 33);
            Print.Location = new Point(1750, 600);
            Print.BackColor = Color.Chocolate;
            Print.Text = "PRINT";
            Print.Font = new Font("Montserrat Bold", 15, FontStyle.Bold);
            //Print.Click += comboboxCustName_ClickPayment;
            Print.Click += BtnPrint;
            panelPayment.Controls.Add(Print);
            Print.BringToFront();

            Button Close = new Button();
            Close.Size = new Size(90, 66);
            Close.Location = new Point(1750, 520);
            Close.BackColor = Color.Chocolate;
            Close.Text = "Close\nPrint Display";
            Close.Font = new Font("Montserrat Bold", 9, FontStyle.Bold);
            Close.Click += closePrint;
            panelPayment.Controls.Add(Close);
            Close.BringToFront();


        }

        private void BtnPaymentClick(object sender, EventArgs e)
        {

            statusDisplayBTN = false;
            dtCustName.Rows.Clear();
            panelPayment.Controls.Clear();
            payment.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_PAYMENTSELECT.png");
            checkorder.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_CHECKORDER.png");

            PictureBox Payment = new PictureBox();
            Payment.Size = new Size(372, 123);
            Payment.Location = new Point(73, 70);
            Payment.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_PAYMENTBSR.png");
            Payment.BackColor = Color.Transparent;
            panelPayment.Controls.Add(Payment);
            Payment.BringToFront();

            comboboxCustName.Location = new Point(73, 220);
            //comboboxCustName.SelectionChangeCommitted += ComboboxCustName_Click;
            panelPayment.Controls.Add(comboboxCustName);
            comboboxCustName.BringToFront();

            sqlQuery = "SELECT IDcustomer,nama_customer FROM customer;";
            cmd = new MySqlCommand(sqlQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtCustName);
            comboboxCustName.DataSource = dtCustName;
            comboboxCustName.ValueMember = "IDcustomer";
            comboboxCustName.DisplayMember = "nama_customer";
            comboboxCustName.Font = new Font("Montserrat Bold", 15, FontStyle.Bold);

            panelPayment.Controls.Add(Open);
            Open.BringToFront();


            //Button Print
            Print.Size = new Size(90, 33);
            Print.Location = new Point(1750, 600);
            Print.BackColor = Color.Chocolate;
            Print.Text = "PRINT";
            Print.Font = new Font("Montserrat Bold", 15, FontStyle.Bold);
            Print.Click += BtnPrint;
            panelPayment.Controls.Add(Print);
            Print.BringToFront();

            Button Close = new Button();
            Close.Size = new Size(90, 66);
            Close.Location = new Point(1750, 520);
            Close.BackColor = Color.Chocolate;
            Close.Text = "Close\nPrint Display";
            Close.Font = new Font("Montserrat Bold", 9, FontStyle.Bold);
            Close.Click += closePrint;
            panelPayment.Controls.Add(Close);
            Close.BringToFront();



        }

        private void comboboxCustName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Panel display = new Panel();
            display.Size = new Size(780, 300);
            display.Location = new Point(1000, 100);
            display.BackColor = Color.Orange;
            this.Controls.Add(display);
            display.BringToFront();
        }

        List<Button> status = new List<Button>();
        bool statusDisplayBTN = false;
        private void BtnCheckOrder(object sender, EventArgs e)
        {
            statusDisplayBTN = true;
            panelPayment.Controls.Clear();
            this.Controls.Remove(display);
            dtCustName.Rows.Clear();

            payment.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_PAYMENT.png");
            checkorder.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_CHECKORDERSELECTED.png");

            PictureBox CheckOrderTXT = new PictureBox();
            CheckOrderTXT.Size = new Size(372, 38);
            CheckOrderTXT.Location = new Point(73, 70);
            CheckOrderTXT.Image = Image.FromFile(@"D:\SAD - AFL 3 PROJECT\T_CHECK ORDER.png");
            CheckOrderTXT.BackColor = Color.Transparent;
            panelPayment.Controls.Add(CheckOrderTXT);

            comboboxCustName.Location = new Point(73, 140);
            panelPayment.Controls.Add(comboboxCustName);
            comboboxCustName.BringToFront();

            sqlQuery = "SELECT IDcustomer,nama_customer FROM customer;";
            cmd = new MySqlCommand(sqlQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtCustName);
            comboboxCustName.DataSource = dtCustName;
            comboboxCustName.ValueMember = "IDcustomer";
            comboboxCustName.DisplayMember = "nama_customer";

            comboboxCustName.Font = new Font("Montserrat Bold", 15, FontStyle.Bold);

            Open.Size = new Size(90, 33);
            Open.Location = new Point(520, 140);
            Open.BackColor = Color.Chocolate;
            Open.Text = "OPEN";
            Open.Font = new Font("Montserrat Bold", 15, FontStyle.Bold);
            //Open.ForeColor = Color.White;
            Open.Click += comboboxCustName_ClickPayment;
            panelPayment.Controls.Add(Open);
            Open.BringToFront();
        }

        private void statusDoneClick(object sender, EventArgs e)
        {
            for (int i = 0; i < dtSimpanPayment.Rows.Count; i++)
            {
                if (status[i].ForeColor == Color.White)
                {
                    status[i].ForeColor = Color.Green;
                }
                else
                {
                    status[i].ForeColor = Color.Red;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void comboboxCustNameprivatobject sender, MouseEventArgs e)
        Panel display = new Panel();

        String TglPemesanan = "";
        String IDOrder = "";
        private void comboboxCustName_ClickPayment(object sender, EventArgs e) //PANEL
        {
            dtSimpanPayment.Rows.Clear();
            display.Size = new Size(900, 500);
            display.Location = new Point(800, 430);
            display.BackColor = Color.Gray;
            display.BorderStyle = BorderStyle.Fixed3D;
            display.Controls.Clear();
            this.Controls.Remove(display);
            this.Controls.Add(display);
            display.BringToFront();

            Label DetailPesanan = new Label();
            DetailPesanan.Text = "Detail Pesanan";
            DetailPesanan.Font = new Font("Montserrat", 22, FontStyle.Bold);
            DetailPesanan.ForeColor = Color.White;
            DetailPesanan.Size = new Size(300, 40);
            DetailPesanan.Location = new Point(330, 10);
            display.Controls.Add(DetailPesanan);

            //Label t = new Label();
            //t.Text = "Detail Pesanan";
            //t.Font = new Font("Montserrat", 22, FontStyle.Bold);
            //t.ForeColor = Color.White;
            //t.Size = new Size(300, 40);
            //t.Location = new Point(30, 100);
            //display.Controls.Add(t);

            sqlQuery = $"SELECT m.nama_menu, m.harga, p.jumlah_pes, p.tglOrder,p.IDorder,p.done FROM menu m LEFT JOIN pesan p ON p.IDmenu = m.IDmenu WHERE p.IDcustomer = '{comboboxCustName.SelectedValue.ToString()}';";
            cmd = new MySqlCommand(sqlQuery, conn);
            adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(dtSimpanPayment);

            int x = 30;
            int y = 120;
            //
            int a = 750;
            int b = 120;

            Label JDL = new Label();
            JDL.Text = $"NAMA MENU                                  PCS                              JUMLAH";
            JDL.Font = new Font("Montserrat", 15, FontStyle.Bold);
            JDL.ForeColor = Color.White;
            JDL.Size = new Size(700, 40);
            JDL.Location = new Point(30, 80);
            display.Controls.Add(JDL);

            if (dtSimpanPayment.Rows.Count > 0)
            {
                TglPemesanan = dtSimpanPayment.Rows[1][3].ToString();
                IDOrder = dtSimpanPayment.Rows[1][4].ToString();
            }
            else
            {
                TglPemesanan = "";
                IDOrder = "";
            }


            if (dtSimpanPayment.Rows.Count > 0)
            {
                status.Clear();
                int total = 0;
                int totalHarga = 0;
                for (int i = 0; i < dtSimpanPayment.Rows.Count; i++)
                {
                    string namaMenu = dtSimpanPayment.Rows[i][0].ToString();
                    int jumlahPesanan = int.Parse(dtSimpanPayment.Rows[i][1].ToString());
                    int hargaMenu = int.Parse(dtSimpanPayment.Rows[i][2].ToString());
                    totalHarga = jumlahPesanan * hargaMenu;
                    total += totalHarga;
                    //MASIH BELUM RAPIH TLG RAPIHIN
                    string displayText = $"{namaMenu} {hargaMenu.ToString().PadLeft(35, ' ')} {totalHarga.ToString().PadLeft(48, ' ')}";

                    Label pilihanMenu = new Label
                    {
                        Text = displayText,
                        Font = new Font("Montserrat", 15, FontStyle.Regular),
                        ForeColor = Color.White,
                        Size = new Size(800, 40),
                        Location = new Point(x, y)
                    };

                    display.Controls.Add(pilihanMenu);
                    y += 45;
                    if (statusDisplayBTN == true)
                    {
                        Button Stts = new Button();
                        Stts.Size = new Size(90, 33);
                        Stts.Location = new Point(a, b);
                        Stts.BackColor = Color.White;
                        Stts.Text = dtSimpanPayment.Rows[i][5].ToString();
                        Stts.Font = new Font("Montserrat Bold", 12, FontStyle.Bold);
                        if (Stts.Text == "DONE")
                        {
                            Stts.ForeColor = Color.Green;
                        }
                        Stts.Click += statusDoneClick;
                        Stts.Tag = $"Status {i.ToString()}";
                        display.Controls.Add(Stts);
                        Stts.BringToFront();
                        status.Add(Stts);
                        b += 45;
                    }
                }
                Label TotalHarga = new Label
                {
                    Text = $"------------------------------------\nTotal :                       Rp.{total.ToString()}",
                    Font = new Font("Montserrat", 15, FontStyle.Regular),
                    ForeColor = Color.White,
                    Size = new Size(800, 80),
                    Location = new Point(400, 400)
                };
                display.Controls.Add(TotalHarga);
            }
            label1.Text = comboboxCustName.SelectedValue.ToString();

        }

        private void BtnPrint(object sender, EventArgs e)
        {
            print.Enabled = true;
            print.Visible = true;
            print.Controls.Clear();
            print.Size = new Size(630, 732);
            print.Location = new Point(681, 130);
            print.BackColor = Color.White;
            this.Controls.Add(print);
            print.BringToFront();

            Button PrintOK = new Button();
            PrintOK.Size = new Size(60, 33);
            PrintOK.Location = new Point(550, 680);
            PrintOK.BackColor = Color.Chocolate;
            PrintOK.Text = "PRINT";
            PrintOK.Font = new Font("Montserrat Bold", 9, FontStyle.Bold);
            PrintOK.Click += printOK;
            print.Controls.Add(PrintOK);
            PrintOK.BringToFront();


            Label JDL = new Label();
            JDL.Text = $"Bebek Lumer Mbak Siti";
            JDL.Font = new Font("Montserrat", 15, FontStyle.Bold);
            JDL.ForeColor = Color.Black;
            JDL.Size = new Size(700, 25);
            JDL.Location = new Point(200, 10);
            print.Controls.Add(JDL);

            Label Alamat = new Label();
            Alamat.Text = $"Jl. Griya Babatan Mukti IX No.20A, Babatan, Kec. Wiyung, Surabaya, Jawa Timur 60227";
            Alamat.Font = new Font("Montserrat", 9, FontStyle.Regular);
            Alamat.ForeColor = Color.Black;
            Alamat.Size = new Size(700, 25);
            Alamat.Location = new Point(60, 50);
            Alamat.BackColor = Color.Transparent;
            Alamat.BringToFront();
            print.Controls.Add(Alamat);

            Label Garis = new Label();
            Garis.Text = $"---------------------------------------------------------------------------------------";
            Garis.Font = new Font("Montserrat", 15, FontStyle.Bold);
            Garis.ForeColor = Color.Black;
            Garis.Size = new Size(1000, 30);
            Garis.Location = new Point(0, 70);
            print.Controls.Add(Garis);

            Label txtIDpemesanan = new Label();
            txtIDpemesanan.Text = $"NO. Pemesanan : {IDOrder}";
            txtIDpemesanan.Font = new Font("Montserrat", 9, FontStyle.Regular);
            txtIDpemesanan.ForeColor = Color.Black;
            txtIDpemesanan.Size = new Size(700, 25);
            txtIDpemesanan.Location = new Point(10, 100);
            txtIDpemesanan.BackColor = Color.Transparent;
            txtIDpemesanan.BringToFront();
            print.Controls.Add(txtIDpemesanan);

            Label txttglwaktu = new Label();
            txttglwaktu.Text = $"Tgl/Waktu : {TglPemesanan}";
            txttglwaktu.Font = new Font("Montserrat", 9, FontStyle.Regular);
            txttglwaktu.ForeColor = Color.Black;
            txttglwaktu.Size = new Size(700, 25);
            txttglwaktu.Location = new Point(10, 125);
            txttglwaktu.BackColor = Color.Transparent;
            txttglwaktu.BringToFront();
            print.Controls.Add(txttglwaktu);

            Label txtStaff = new Label();
            txtStaff.Text = $"Staff :";
            txtStaff.Font = new Font("Montserrat", 9, FontStyle.Regular);
            txtStaff.ForeColor = Color.Black;
            txtStaff.Size = new Size(700, 25);
            txtStaff.Location = new Point(10, 150);
            txtStaff.BackColor = Color.Transparent;
            txtStaff.BringToFront();
            print.Controls.Add(txtStaff);

            Label Garis1 = new Label();
            Garis1.Text = $"---------------------------------------------------------------------------------------";
            Garis1.Font = new Font("Montserrat", 15, FontStyle.Bold);
            Garis1.ForeColor = Color.Black;
            Garis1.Size = new Size(1000, 30);
            Garis1.Location = new Point(0, 165);
            print.Controls.Add(Garis1);

            Label JDL1 = new Label();
            JDL1.Text = $"NAMA MENU                                  PCS                                  JUMLAH";
            JDL1.Font = new Font("Montserrat", 12, FontStyle.Bold);
            JDL1.ForeColor = Color.Black;
            JDL1.Size = new Size(700, 40);
            JDL1.Location = new Point(10, 195);
            print.Controls.Add(JDL1);


            int x = 10;
            int y = 240;

            ///////////////////////////////////////////////////////


            if (dtSimpanPayment.Rows.Count > 0)
            {
                int total = 0;
                int totalHarga = 0;
                for (int i = 0; i < dtSimpanPayment.Rows.Count; i++)
                {
                    ;
                    string namaMenu = dtSimpanPayment.Rows[i][0].ToString();
                    int jumlahPesanan = int.Parse(dtSimpanPayment.Rows[i][1].ToString());
                    int hargaMenu = int.Parse(dtSimpanPayment.Rows[i][2].ToString());
                    totalHarga = jumlahPesanan * hargaMenu;
                    total += totalHarga;
                    //MASIH BELUM RAPIH TLG RAPIHIN
                    string displayText = $"{namaMenu} {hargaMenu.ToString().PadLeft(35, ' ')} {totalHarga.ToString().PadLeft(58, ' ')}";

                    Label pilihanMenu = new Label
                    {
                        Text = displayText,
                        Font = new Font("Montserrat", 10, FontStyle.Regular),
                        ForeColor = Color.Black,
                        Size = new Size(700, 40),
                        Location = new Point(x, y)
                    };

                    print.Controls.Add(pilihanMenu);
                    y += 45;
                }
                Label TotalHarga = new Label
                {
                    Text = $"------------------------------------\nTotal :                       Rp.{total.ToString()}",
                    Font = new Font("Montserrat", 12, FontStyle.Regular),
                    ForeColor = Color.Black,
                    Size = new Size(800, 80),
                    Location = new Point(370, 570)
                };
                print.Controls.Add(TotalHarga);
            }


        }

        private void closePrint(object sender, EventArgs e)
        {
            print.Enabled = false;
            print.Visible = false;
        }


        private void printOK(object sender, EventArgs e)
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = print.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, s);

            printDocument1.Print();
        }

        private void printDocument1_PrintPage_1(System.Object sender,
           System.Drawing.Printing.PrintPageEventArgs e) =>
               e.Graphics.DrawImage(memoryImage, 0, 0);

    }
}
