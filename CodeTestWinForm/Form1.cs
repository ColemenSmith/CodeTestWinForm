using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Customsearch.v1;
using Google.Apis.Services;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using Syncfusion.Presentation;

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
            var str = titleTextBox.Text;
            var extractedData = ImageGrabber.ExtractCustomSearchData(str);

            List<string> results = new List<string>();
            int count = 0;
            foreach (var data in extractedData)
            {
                results.Add(data.Link);
                count++;
            }

            pbImage.Load(results[0]);
            pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Load(results[1]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Load(results[2]);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Load(results[3]);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

        }
    }
}
