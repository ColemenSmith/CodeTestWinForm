using Syncfusion.Presentation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace CodeTestWinForm
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a new instance of PowerPoint Presentation file
            IPresentation pptxDoc = Presentation.Create();

            //Add a new slide to file and apply background color
            ISlide slide = pptxDoc.Slides.Add(SlideLayoutType.TitleOnly);

            //Specify the fill type and fill color for the slide background 
            slide.Background.Fill.FillType = FillType.Solid;
            slide.Background.Fill.SolidFill.Color = ColorObject.FromArgb(232, 241, 229);

            //Add title content to the slide by accessing the title placeholder of the TitleOnly layout-slide
            IShape titleShape = slide.Shapes[0] as IShape;
            titleShape.TextBody.AddParagraph(titleTextBox.Text).HorizontalAlignment = HorizontalAlignmentType.Center;

            //Add description content to the slide by adding a new TextBox
            IShape descriptionShape = slide.AddTextBox(53.22, 141.73, 874.19, 77.70);
            descriptionShape.TextBody.Text = textAreaTextBox.Text;

            //Add image to slide from image URL
            WebClient myWebClient = new WebClient();
            //checking which images want to be used
            if (pbImageCheckBox1.Checked == true)
            {
                byte[] image1 = myWebClient.DownloadData(pbImageCheckBox1.Text);
                Stream imageStream1 = new MemoryStream(image1);
                slide.Shapes.AddPicture(imageStream1, 100, 238.59, 364.54, 192.16);
            }
            if (pbImageCheckBox2.Checked == true)
            {
                byte[] image2 = myWebClient.DownloadData(pbImageCheckBox2.Text);
                Stream imageStream2 = new MemoryStream(image2);
                slide.Shapes.AddPicture(imageStream2, 300, 238.59, 364.54, 192.16);
            }
            if (pbImageCheckBox3.Checked == true)
            {
                byte[] image3 = myWebClient.DownloadData(pbImageCheckBox3.Text);
                Stream imageStream3 = new MemoryStream(image3);
                slide.Shapes.AddPicture(imageStream3, 500, 238.59, 364.54, 192.16);
            }
            if (pbImageCheckBox4.Checked == true)
            {
                byte[] image4 = myWebClient.DownloadData(pbImageCheckBox4.Text);
                Stream imageStream4 = new MemoryStream(image4);
                slide.Shapes.AddPicture(imageStream4, 700, 238.59, 364.54, 192.16);
            }

            //Save the PowerPoint Presentation 
            pptxDoc.Save("Sample.pptx");

            //Close the PowerPoint presentation
            pptxDoc.Close();

            //Open the PowerPoint presentation file
            System.Diagnostics.Process.Start("Sample.pptx");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textAreaTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbImage_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            //extracting images from google based on text in titleTextBox
            var str = titleTextBox.Text;
            var extractedData = ImageGrabber.ExtractCustomSearchData(str);

            //taking images from extractedData and putting them into a list of results for easier access
            List<string> results = new List<string>();
            int count = 0;
            foreach (var data in extractedData)
            {
                results.Add(data.Link);
                count++;
            }

            //putting image and link into pb1 and check box below
            pbImageCheckBox1.Text = results[0];
            pbImage.Load(results[0]);
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            //putting image and link into pb2 and text box below
            pbImageCheckBox2.Text = results[1];
            pictureBox1.Load(results[1]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            //putting image and link into pb3 and text box below
            pbImageCheckBox3.Text = results[2];
            pictureBox2.Load(results[2]);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            //putting image and link into pb4 and text box below
            pbImageCheckBox4.Text = results[3];
            pictureBox3.Load(results[3]);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void pbImageCheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
