//Gürkan GÖKDEMİR 140202038

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D; // for resize image
using System.Drawing.Imaging; //to save image format
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace ImageProcessor
{
    public partial class formImageProcessor : Form
    {
        Image bttnImg11;
        Image bttnImg12;
        Image bttnImg13;
        Image bttnImg14;
        Image bttnImg21;
        Image bttnImg22;
        Image bttnImg23;
        Image bttnImg24;
        Image bttnImg31;
        Image bttnImg32;
        Image bttnImg33;
        Image bttnImg34;
        Image bttnImg41;
        Image bttnImg42;
        Image bttnImg43;
        Image bttnImg44;

        Image bttnImg11Org;
        Image bttnImg12Org;
        Image bttnImg13Org;
        Image bttnImg14Org;
        Image bttnImg21Org;
        Image bttnImg22Org;
        Image bttnImg23Org;
        Image bttnImg24Org;
        Image bttnImg31Org;
        Image bttnImg32Org;
        Image bttnImg33Org;
        Image bttnImg34Org;
        Image bttnImg41Org;
        Image bttnImg42Org;
        Image bttnImg43Org;
        Image bttnImg44Org;


        double totalPoint = 0;
        Boolean cheatButton = false;
        int clickedFirst = 0;
        int clickedSecond = 0;
        Image clickedFirstImage;
        Image clickedSecondImage;
        Bitmap imageBitmap;
        Image imageFile;
        Boolean isFileOpened = false;
        int imgHeight = 320, imgWidth = 320;
        

        public formImageProcessor()
        {
            InitializeComponent();
        }

        enum Buttons {



        }

        public void PointChecker() {
            if (totalPoint == 100)
            {
                MessageBox.Show("Congratulations! You've finished the puzzle!");
            }
        }

        public void ImageChecker() {

            totalPoint = 0;

            if (bttnImg11 == bttnImg11Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg12 == bttnImg12Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg13 == bttnImg13Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg14 == bttnImg14Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg21 == bttnImg21Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg22 == bttnImg22Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg23 == bttnImg23Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg24 == bttnImg24Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg31 == bttnImg31Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg32 == bttnImg32Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg33 == bttnImg33Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg34 == bttnImg34Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg41 == bttnImg41Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg42 == bttnImg42Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg43 == bttnImg43Org)
            {
                totalPoint = totalPoint + 6.25;
            }
            if (bttnImg44 == bttnImg44Org)
            {
                totalPoint = totalPoint + 6.25;
            }

            PointChecker();
            


        }


        public void ImageSetter() {

            imgBttn11.BackgroundImage = bttnImg11;
            imgBttn21.BackgroundImage = bttnImg21;
            imgBttn31.BackgroundImage = bttnImg31;
            imgBttn41.BackgroundImage = bttnImg41;

            imgBttn12.BackgroundImage = bttnImg12;
            imgBttn22.BackgroundImage = bttnImg22;
            imgBttn32.BackgroundImage = bttnImg32;
            imgBttn42.BackgroundImage = bttnImg42;

            imgBttn13.BackgroundImage = bttnImg13;
            imgBttn23.BackgroundImage = bttnImg23;
            imgBttn33.BackgroundImage = bttnImg33;
            imgBttn43.BackgroundImage = bttnImg43;

            imgBttn14.BackgroundImage = bttnImg14;
            imgBttn24.BackgroundImage = bttnImg24;
            imgBttn34.BackgroundImage = bttnImg34;
            imgBttn44.BackgroundImage = bttnImg44;

            ImageChecker();


        }


        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {

            pictureBoxNewImage.Hide();
            DialogResult dialogResult = openFileDialogImage.ShowDialog();
            

            if (dialogResult == DialogResult.OK)
            {
                imageBitmap = new Bitmap(openFileDialogImage.FileName);
                imageFile = ResizeImage(Image.FromFile(openFileDialogImage.FileName), imgHeight,imgWidth);
                pictureBoxOriginalImage.Image = imageFile;
                isFileOpened = true;
                pictureBoxOriginalImage.Hide();

                var ImageArrayOrginal = new Image[16];
                var ImageArrayMixed = new Image[16];
                var imageVar = imageFile;   //
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        var index = i * 4 + j;
                        ImageArrayOrginal[index] = new Bitmap(80, 80);
                        var graphics = Graphics.FromImage(ImageArrayOrginal[index]);
                        graphics.DrawImage(imageVar, new Rectangle(0, 0, 80, 80), new Rectangle(i * 80, j * 80, 80, 80), GraphicsUnit.Pixel);
                        graphics.Dispose();



                    }
                }
                ImageArrayMixed = ImageArrayOrginal;

bttnImg11 = ImageArrayMixed[0];
bttnImg21 = ImageArrayMixed[1];
bttnImg31 = ImageArrayMixed[2];
bttnImg41 = ImageArrayMixed[3];
bttnImg12 = ImageArrayMixed[4];
bttnImg22 = ImageArrayMixed[5];
bttnImg32 = ImageArrayMixed[6];
bttnImg42 = ImageArrayMixed[7];
bttnImg13 = ImageArrayMixed[8];
bttnImg23 = ImageArrayMixed[9];
bttnImg33 = ImageArrayMixed[10];
bttnImg43 = ImageArrayMixed[11];
bttnImg14 = ImageArrayMixed[12];
bttnImg24 = ImageArrayMixed[13];
bttnImg34 = ImageArrayMixed[14];
bttnImg44 = ImageArrayMixed[15];

                bttnImg11Org = ImageArrayMixed[0];
                bttnImg21Org = ImageArrayMixed[1];
                bttnImg31Org = ImageArrayMixed[2];
                bttnImg41Org = ImageArrayMixed[3];
                bttnImg12Org = ImageArrayMixed[4];
                bttnImg22Org = ImageArrayMixed[5];
                bttnImg32Org = ImageArrayMixed[6];
                bttnImg42Org = ImageArrayMixed[7];
                bttnImg13Org = ImageArrayMixed[8];
                bttnImg23Org = ImageArrayMixed[9];
                bttnImg33Org = ImageArrayMixed[10];
                bttnImg43Org = ImageArrayMixed[11];
                bttnImg14Org = ImageArrayMixed[12];
                bttnImg24Org = ImageArrayMixed[13];
                bttnImg34Org = ImageArrayMixed[14];
                bttnImg44Org = ImageArrayMixed[15];

                ImageSetter();

            }



        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
            DialogResult dialogResult = saveFileDialogImage.ShowDialog();

                        if (dialogResult == DialogResult.OK)
                        {
                            if (isFileOpened)
                            {

                                if (saveFileDialogImage.FileName.Substring(saveFileDialogImage.FileName.Length - 3).ToLower() == "bmp")
                                {
                                    imageFile.Save(saveFileDialogImage.FileName, ImageFormat.Bmp); //imported system.drawing.imaging
                                }
                                if (saveFileDialogImage.FileName.Substring(saveFileDialogImage.FileName.Length - 3).ToLower() == "jpg")
                                {
                                    imageFile.Save(saveFileDialogImage.FileName, ImageFormat.Jpeg); //imported system.drawing.imaging
                                }
                                if (saveFileDialogImage.FileName.Substring(saveFileDialogImage.FileName.Length - 3).ToLower() == "png")
                                {
                                    imageFile.Save(saveFileDialogImage.FileName, ImageFormat.Png); //imported system.drawing.imaging
                                }
                                if (saveFileDialogImage.FileName.Substring(saveFileDialogImage.FileName.Length - 3).ToLower() == "gif")
                                {
                                    imageFile.Save(saveFileDialogImage.FileName, ImageFormat.Gif); //imported system.drawing.imaging
                                }

                            }
                            else
                            {
                                MessageBox.Show("Please choose an image.");
                            }
                        }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please choose an image. \n" + ex.Message);
            }
            
        }

     

     
        private void buttonScale_Click(object sender, EventArgs e)
        {
            try
            {
                        double width;
                        double.TryParse("300", out width);

                        double height;
                        double.TryParse("300", out height);


                        var ratioX = (double)width / imageFile.Width;
                        var ratioY = (double)height / imageFile.Height;
                        //var ratio = Math.Min(ratioX, ratioY);

                        var newWidth = (int)(imageFile.Width * ratioX);
                        var newHeight = (int)(imageFile.Height * ratioY);

                        var newImage = new Bitmap(newWidth, newHeight);
                        using (var graphics = Graphics.FromImage(newImage))
                        graphics.DrawImage(imageFile, 0, 0, newWidth, newHeight);

                        pictureBoxNewImage.Image = newImage;
                pictureBoxNewImage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please insert a number. \n" + ex.Message);
            }

            
        }


        private void formImageProcessor_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCheat_Click(object sender, EventArgs e)
        {

            pictureBoxOriginalImage.Show();

            imgBttn11.Hide();
            imgBttn12.Hide();
            imgBttn13.Hide();
            imgBttn14.Hide();
            imgBttn21.Hide();
            imgBttn22.Hide();
            imgBttn23.Hide();
            imgBttn24.Hide();
            imgBttn31.Hide();
            imgBttn32.Hide();
            imgBttn33.Hide();
            imgBttn34.Hide();
            imgBttn41.Hide();
            imgBttn42.Hide();
            imgBttn43.Hide();
            imgBttn44.Hide();
       
        }

        private void buttonReOpen_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void buttonReOpen_Click(object sender, EventArgs e)
            {
                try
                {
                    imageFile = Image.FromFile(openFileDialogImage.FileName);
                    imageBitmap = new Bitmap(openFileDialogImage.FileName);
                    pictureBoxOriginalImage.Image = imageFile;
                    isFileOpened = true;
            }
                catch (Exception ex)
                {
                    MessageBox.Show("Please choose an image. \n" + ex.Message);
                }

            }
        private void buttonMixer_Click(object sender, EventArgs e)
        {

            Random r = new Random();
            int z = r.Next();
            z = z % 100;
            for (int i = 0; i < z; i++)
            {


            int x1=0, y1=0;
            int x2 = 0, y2=0;


            x1 = r.Next();
            y1 = r.Next();
             
            x1 = x1 % 4;
            y1 = y1 % 4;

            x2 = r.Next();
            y2 = r.Next();
             
            x2 = x2 % 4;
            y2 = y2 % 4;

            clickedFirst = (x1 + 1) * 10 + (y1 + 1);
            clickedSecond = (x2 + 1) * 10 + (y2 + 1);

            //MessageBox.Show(clickedFirst + " " + clickedSecond);

            switch (clickedSecond)
            {
                case 11:
                    imgBttn11.PerformClick();
                    break;
                case 12:
                    imgBttn12.PerformClick();
                    break;

                case 13:
                    imgBttn13.PerformClick();
                    break;
                case 14:
                    imgBttn14.PerformClick();
                    break;
                case 21:
                    imgBttn21.PerformClick();
                    break;
                case 22:
                    imgBttn22.PerformClick();
                    break;
                case 23:
                    imgBttn23.PerformClick();
                    break;
                case 24:
                    imgBttn24.PerformClick();
                    break;
                case 31:
                    imgBttn31.PerformClick();
                    break;
                case 32:
                    imgBttn32.PerformClick();
                    break;
                case 33:
                    imgBttn33.PerformClick();
                    break;
                case 34:
                    imgBttn34.PerformClick();
                    break;
                case 41:
                    imgBttn41.PerformClick();
                    break;
                case 42:
                    imgBttn42.PerformClick();
                    break;
                case 43:
                    imgBttn43.PerformClick();
                    break;
                case 44:
                    imgBttn44.PerformClick();
                    break;
                default:
                    break;
            }
            ImageSetter();
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void ButtonCheat_Click_1(object sender, EventArgs e)
        {

            if (cheatButton)
            {
               pictureBoxOriginalImage.Hide();

                imgBttn11.Show();
                imgBttn12.Show();
                imgBttn13.Show();
                imgBttn14.Show();
                imgBttn21.Show();
                imgBttn22.Show();
                imgBttn23.Show();
                imgBttn24.Show();
                imgBttn31.Show();
                imgBttn32.Show();
                imgBttn33.Show();
                imgBttn34.Show();
                imgBttn41.Show();
                imgBttn42.Show();
                imgBttn43.Show();
                imgBttn44.Show();

                cheatButton = false;
            }
            else
            {
                pictureBoxOriginalImage.Show();

                imgBttn11.Hide();
                imgBttn12.Hide();
                imgBttn13.Hide();
                imgBttn14.Hide();
                imgBttn21.Hide();
                imgBttn22.Hide();
                imgBttn23.Hide();
                imgBttn24.Hide();
                imgBttn31.Hide();
                imgBttn32.Hide();
                imgBttn33.Hide();
                imgBttn34.Hide();
                imgBttn41.Hide();
                imgBttn42.Hide();
                imgBttn43.Hide();
                imgBttn44.Hide();

                cheatButton = true;
            }
            PointChecker();
 
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void imgBttn11_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 11;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:
                        
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg11;
                        bttnImg11 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    
                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn12_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 12;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg12;
                        bttnImg12 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg12;
                        bttnImg12 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn13_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 13;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg13;
                        bttnImg13 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg13;
                        bttnImg13 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn14_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 14;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg14;
                        bttnImg14 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg14;
                        bttnImg14 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn21_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 21;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg21;
                        bttnImg21 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg21;
                        bttnImg21 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn22_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 22;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg22;
                        bttnImg22 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg22;
                        bttnImg22 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn23_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 23;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg23;
                        bttnImg23 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg23;
                        bttnImg23 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn24_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 24;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg24;
                        bttnImg24 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg24;
                        bttnImg24 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn31_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 31;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg31;
                        bttnImg31 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg31;
                        bttnImg31 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn32_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 32;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg32;
                        bttnImg32 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg32;
                        bttnImg32 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn33_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 33;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg33;
                        bttnImg33 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg33;
                        bttnImg33 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn34_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 34;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg34;
                        bttnImg34 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg34;
                        bttnImg34 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn41_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 41;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg41;
                        bttnImg41 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg41;
                        bttnImg41 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn42_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 42;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg42;
                        bttnImg42 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg42;
                        bttnImg42 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn43_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 43;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg43;
                        bttnImg43 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg43;
                        bttnImg43 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }

        private void imgBttn44_Click(object sender, EventArgs e)
        {
            Image tmp;
            if (clickedFirst == 0)
            {
                clickedFirst = 44;
                clickedFirstImage = imgBttn11.Image;
            }
            else
            {
                switch (clickedFirst)
                {
                    case 11:

                        tmp = bttnImg44;
                        bttnImg44 = bttnImg11;
                        bttnImg11 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 12:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg12;
                        bttnImg12 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 13:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg13;
                        bttnImg13 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 14:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg14;
                        bttnImg14 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 21:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg21;
                        bttnImg21 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 22:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg22;
                        bttnImg22 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 23:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg23;
                        bttnImg23 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 24:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg24;
                        bttnImg24 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 31:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg31;
                        bttnImg31 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 32:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg32;
                        bttnImg32 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 33:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg33;
                        bttnImg33 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 34:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg34;
                        bttnImg34 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 41:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg41;
                        bttnImg41 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 42:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg42;
                        bttnImg42 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 43:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg43;
                        bttnImg43 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;
                    case 44:
                        tmp = bttnImg44;
                        bttnImg44 = bttnImg44;
                        bttnImg44 = tmp;


                        clickedFirst = 0;
                        clickedSecond = 0;
                        ImageSetter();
                        break;

                    default:
                        break;
                }

            }
            ImageSetter();
        }


    }
}
