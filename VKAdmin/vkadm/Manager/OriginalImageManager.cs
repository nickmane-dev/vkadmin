using ImageProcessor;
using ImageProcessor.Imaging.Filters.Photo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VKAdmin.vkadm.Manager
{
    class OriginalImageManager
    {
        public static string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/ImageManager.vkadmin";
        public int brightness = 0;
        public int contrast = 0;
        public int saturation = 0;
        public int quality = 0;
        public bool filter = false;

        public Image getImage(int count, Image img)
        {
            getConfig();

            ImageFactory imageFactory = new ImageFactory();
            imageFactory.Load(img);

            imageFactory.Pixelate(quality);
            imageFactory.Saturation(saturation);
            imageFactory.Contrast(contrast);
            imageFactory.Brightness(brightness);
            if (filter)
                imageFactory.Filter(MatrixFilters.LoSatch);

            imageFactory.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/cache/" + count + ".jpg");

            return imageFactory.Image;
        }

        public Image getImage_forSetting(int count, Image img)
        {

            ImageFactory imageFactory = new ImageFactory();
            imageFactory.Load(img);

            imageFactory.Pixelate(quality);
            imageFactory.Saturation(saturation);
            imageFactory.Contrast(contrast);
            imageFactory.Brightness(brightness);
            if (filter)
                imageFactory.Filter(MatrixFilters.LoSatch);

            //imageFactory.Save(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/cache/" + count + ".jpg");

            return imageFactory.Image;
        }

        public void getConfig ()
        {
            StreamReader sr = new StreamReader(dataPath);
            String[] var = sr.ReadToEnd().Split(';');
            brightness = int.Parse(var[0].Split('=')[1]);
            contrast   = int.Parse(var[1].Split('=')[1]);
            saturation = int.Parse(var[2].Split('=')[1]);
            quality    = int.Parse(var[3].Split('=')[1]);

            string _filter  = var[4].Split('=')[1];
            if (_filter == "true")
                filter = true;
            

            sr.Close();
        }

        public void createConfig ()
        {
            if (!File.Exists(dataPath))
            {
                File.Create(dataPath).Close();

                StreamWriter sw = new StreamWriter(dataPath);
                sw.WriteLine("brightness=0;");
                sw.WriteLine("contrast=0;");
                sw.WriteLine("saturation=0;");
                sw.WriteLine("quality=0;");
                sw.WriteLine("filter=false;");
                sw.Close();
            }
        }
    }

}

