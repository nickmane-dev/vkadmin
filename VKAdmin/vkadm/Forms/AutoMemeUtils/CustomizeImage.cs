using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKAdmin.vkadm.Manager;

namespace VKAdmin.vkadm.Forms.AutoMemeUtils
{
    public partial class CustomizeImage : Form
    {
        Form main;
        public CustomizeImage(Form form)
        {
            InitializeComponent();
            main = form;
        }

        public static string dataPath = Environment.GetFolderPath
            (Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/ImageManager.vkadmin";
        OriginalImageManager originalImageManager;
        Image image_static;

        private void CustomizeImage_Load(object sender, EventArgs e)
        {
            image_static = picture.Image;
            originalImageManager = new OriginalImageManager();
            originalImageManager.getConfig();
            brightnessBar.Value = originalImageManager.brightness;
            contrastBar.Value = originalImageManager.contrast;
            saturationBar.Value = originalImageManager.saturation;
            qualityBar.Value = originalImageManager.quality;
            filterCB.Checked = originalImageManager.filter;
        }

        public void updatePicture ()
        {
            picture.Image = image_static;

            originalImageManager.brightness = brightnessBar.Value;
            originalImageManager.contrast = contrastBar.Value;
            originalImageManager.saturation = saturationBar.Value;
            originalImageManager.quality = qualityBar.Value;
            originalImageManager.filter = filterCB.Checked;

            picture.Image = originalImageManager.getImage_forSetting(-1, picture.Image);
        }

        public void saveData ()
        {
            File.WriteAllText(dataPath, string.Empty);
            StreamWriter sw = new StreamWriter(dataPath);
            sw.WriteLine("brightness={0};", brightnessBar.Value);
            sw.WriteLine("contrast={0};", contrastBar.Value);
            sw.WriteLine("saturation={0};", saturationBar.Value);
            sw.WriteLine("quality={0};", qualityBar.Value);
            sw.WriteLine("filter={0};", filterCB.Checked.ToString().ToLower());
            sw.Close();
        }

        private void brightnessBar_Scroll(object sender, EventArgs e)
        {
            updatePicture();
        }

        private void contrastBar_Scroll(object sender, EventArgs e)
        {
            updatePicture();
        }

        private void saturationBar_Scroll(object sender, EventArgs e)
        {
            updatePicture();
        }

        private void qualityBar_Scroll(object sender, EventArgs e)
        {
            updatePicture();
        }

        private void filterCB_CheckedChanged(object sender, EventArgs e)
        {
            updatePicture();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveData();
            MessageBox.Show("Твоя настройка была сохраненна!", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            main.Show();
        }
    }
}
