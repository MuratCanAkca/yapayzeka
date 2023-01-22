using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;
using System.Speech.Recognition;

namespace yapayzeka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        YapayZekaEntities db = new YapayZekaEntities();

        public void ProductList() {

            var products = db.tbl_product.ToList();
            dataGridView1.DataSource = products;

        }

        void Enable()
        {

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            maskedTextBox1.Enabled = false;
            comboBox1.Enabled = false;


        }

        void ColorMethod() {

            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            textBox5.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            maskedTextBox1.BackColor = Color.White;
            comboBox1.BackColor = Color.White;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Enable();
            ColorMethod();
            //timer1.Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Listen Butonu için alan

            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Speak butonu icin alan

            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            try
            {
                button5.Text = "Lütfen konuşun";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();
                richTextBox1.Text = res.Text;
                button5.Text = "Speak";
            }
            catch(Exception) 
            {
                richTextBox1.Text = "HATA! Tekrar deneyiniz..";
            }
            

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            ProductList();  
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            //listelenmesı ıcın yazılacak komutlar

            if (richTextBox1.Text =="Add") { 
                //veritabanına kayıt
            
                tbl_product t= new tbl_product();
                t.name = textBox1.Text;
                t.brand = textBox2.Text ;
                t.stock = short.Parse(textBox3.Text);
                t.buyprice = decimal.Parse(textBox4.Text);
                t.sellprice = decimal.Parse(textBox5.Text);
                t.category = textBox6.Text ;
                t.adddatepro = DateTime.Parse(maskedTextBox1.Text);
                t.productcase = true;//bool.Parse(comboBox1.Text);
                db.tbl_product.Add(t);
                db.SaveChanges();
                label10.Text = "Products saves in database";
            }

            //*****************************************************************************************************

            if (textBox1.BackColor==Color.PowderBlue && textBox1.Enabled==true) {

                textBox1.Text = richTextBox1.Text;
                Enable();
                ColorMethod();

                

            }


            if (textBox2.BackColor == Color.PowderBlue && textBox2.Enabled == true)
            {

                textBox2.Text = richTextBox1.Text;
                Enable();
                ColorMethod();



            }


            if (textBox3.BackColor == Color.PowderBlue && textBox3.Enabled == true)
            {

                textBox3.Text = richTextBox1.Text;
                Enable();
                ColorMethod();



            }


            if (textBox4.BackColor == Color.PowderBlue && textBox4.Enabled == true)
            {

                textBox4.Text = richTextBox1.Text;
                Enable();
                ColorMethod();



            }



            if (textBox5.BackColor == Color.Aqua && textBox5.Enabled == true)
            {

                textBox5.Text = richTextBox1.Text;
                Enable();
                ColorMethod();

                

            }


            if (textBox6.BackColor == Color.PowderBlue && textBox6.Enabled == true)
            {

                textBox6.Text = richTextBox1.Text;
                Enable();
                ColorMethod();



            }

            if (maskedTextBox1.BackColor == Color.Aqua && maskedTextBox1.Enabled == true) {

                //maskedTextBox1.Text = DateTime.Now.ToShortTimeString();
                Enable();
                ColorMethod();

            } 
            
            if (comboBox1.BackColor == Color.Aqua && comboBox1.Enabled == true ) {

                comboBox1.Text = "Active";
                Enable();
                ColorMethod();
                

            }


            //**************************************************************************************************

            if (richTextBox1.Text == "Hello") 
            {
                
                ProductList();

            }
            if (richTextBox1.Text != "Hello")
            {

                dataGridView1.DataSource = null;

            }
            /*if (richTextBox1.Text == "Hi")
            {

                ProductList();

            }*/

            //*****************************************************************************************************


            if (richTextBox1.Text=="Name" || richTextBox1.Text=="The name" || richTextBox1.Text == "Main") {

                textBox1.Focus();
                textBox1.BackColor = Color.PowderBlue;
                textBox1.Enabled = true;
                
                //bu işlemi her bir kısım için yapman gerekiyor sıralamaya dikkat etmelısın

            }
            
            if (richTextBox1.Text == "Brand" || richTextBox1.Text =="Two" || richTextBox1.Text =="2" ) {
                
                textBox2.Focus();
                textBox2.BackColor = Color.Aqua;
                textBox2.Enabled = true;
            
            }

            if (richTextBox1.Text =="Stock" || richTextBox1.Text =="3") {
                
                textBox3.Focus();
                textBox3.BackColor = Color.Aqua;
                textBox3.Enabled = true;
            
            }

            if (richTextBox1.Text == "Buy" || richTextBox1.Text == "4")
            {

                textBox4.Focus();
                textBox4.BackColor = Color.Aqua;
                textBox4.Enabled = true;


            }
            if ( richTextBox1.Text =="Sell" || richTextBox1.Text == "5")
            {

                textBox5.Focus();
                textBox5.BackColor = Color.Aqua;
                textBox5.Enabled = true;
            }

            if (richTextBox1.Text =="Category" || richTextBox1.Text =="6") { 

                textBox6.Focus();   
                textBox6.BackColor = Color.Aqua;
                textBox6.Enabled = true;
            
            }
            


            if (richTextBox1.Text=="Date" || richTextBox1.Text =="7") {

                maskedTextBox1.Focus();
                maskedTextBox1.BackColor = Color.Aqua;  
                maskedTextBox1.Enabled = true;
                //4^^

            }
            
            if (richTextBox1.Text =="Case" || richTextBox1.Text =="8") {
                comboBox1.Focus();
                comboBox1.BackColor = Color.Aqua;
                comboBox1.Enabled = true;
               
            
            }

            //***************************************************************************************************
            
            if (richTextBox1.Text=="Paint"||richTextBox1.Text=="One") {
                System.Diagnostics.Process.Start("MsPaint");
            }
            
            if (richTextBox1.Text=="Closed" || richTextBox1.Text=="Exits" || richTextBox1.Text=="Closing"
                || richTextBox1.Text=="Exit applications" || richTextBox1.Text =="Exits applications") {
                timer1.Stop();
                Application.Exit();
                
            }


            //****************************************************************************************************
        }

        private void maskedTextBox1_BackColorChanged(object sender, EventArgs e)
        {
            if (maskedTextBox1.BackColor == Color.Aqua) {

                maskedTextBox1.Text = DateTime.Now.ToString("dd.MM.yyyy");
            
            }
        }

        private void comboBox1_BackColorChanged(object sender, EventArgs e)
        {
            if (comboBox1.BackColor == Color.Aqua)
            {

                comboBox1.Text = "Active ";

            }
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            
            SpVoice s = new SpVoice();
            s.Speak(label10.Text);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            try
            {
                button5.Text = "Lütfen konuşun";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();
                richTextBox1.Text = res.Text;
                button5.Text = "Speak";
            }
            catch (Exception)
            {
                richTextBox1.Text = "HATA! Tekrar deneyiniz..";
            }

        }
    }
}
