using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;

namespace iTextSharpSign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void debug(string txt)
        {
            DebugBox.AppendText(txt + System.Environment.NewLine);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile;
            openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "PDF files *.pdf|*.pdf";
            openFile.Title = "Select a file";
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            inputBox.Text = openFile.FileName;


            PdfReader reader = new PdfReader(inputBox.Text);

            MetaData md = new MetaData();
            md.Info = reader.Info;

            authorBox.Text = md.Author;
            titleBox.Text = md.Title;
            subjectBox.Text = md.Subject;
            kwBox.Text = md.Keywords;
            creatorBox.Text = md.Creator;
            prodBox.Text = md.Producer;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFile;
            saveFile = new System.Windows.Forms.SaveFileDialog();            
            saveFile.Filter = "PDF files (*.pdf)|*.pdf";
            saveFile.Title = "Save PDF File";
            if (saveFile.ShowDialog() != DialogResult.OK)
                return;
            outputBox.Text = saveFile.FileName;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFile;
            openFile = new System.Windows.Forms.OpenFileDialog();
            openFile.Filter = "Certificate files *.pfx|*.pfx";
            openFile.Title = "Select a file";
            if (openFile.ShowDialog() != DialogResult.OK)
                return;

            certTextBox.Text = openFile.FileName;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            debug("Started ...");

            debug("Checking certificate ...");
            Cert myCert=null;
            try
            {
                myCert = new Cert(certTextBox.Text, passwordBox.Text);
                debug("Certificate OK");
            }
            catch (Exception ex)
            {                
                debug("Error : please make sure you entered a valid certificate file and password");
                debug("Exception : "+ex.ToString());
                return;
            }


            debug("Creating new MetaData ... ");

            //Adding Meta Datas
            MetaData MyMD = new MetaData();
            MyMD.Author = authorBox.Text;
            MyMD.Title = titleBox.Text;
            MyMD.Subject = subjectBox.Text;
            MyMD.Keywords = kwBox.Text;
            MyMD.Creator = creatorBox.Text;
            MyMD.Producer = prodBox.Text;


            debug("Signing document ... ");
            PDFSigner pdfs = new PDFSigner(inputBox.Text, outputBox.Text, myCert, MyMD);
            pdfs.Sign(Reasontext.Text, Contacttext.Text, Locationtext.Text, SigVisible.Checked);

            debug("Done :)");

        }


    }
}