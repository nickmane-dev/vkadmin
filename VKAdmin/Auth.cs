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
using VKAdmin.vkadm;
using VKAdmin.vkadm.Forms;
using VKAdmin.vkadm.Manager;

namespace VKAdmin
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }
        public static string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/at.vkadmin";
        private void button1_Click(object sender, EventArgs e)
        {
            module mod = new module();            
            if (textBox1.Text != "" && mod.tryEntry(textBox1.Text))
            {                
                ConcurrentPublicsDataManager cpm = new ConcurrentPublicsDataManager(mod.api);
                createDataWithAccessToken(textBox1.Text);
                cpm.createData();

                this.Hide();
                AutoMeme am = new AutoMeme(mod.GetVkApi());
                am.Show();

            } else
            {
                MessageBox.Show("AccessToken недействителен", "ОШИБКА", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void openMenu ()
        {

        }
        public void createDataWithAccessToken(string accessToken)
        {
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin");
            //создать пустой файл

            if (!File.Exists(dataPath))
            {
                File.Create(dataPath).Close();                
            }
            //получить доступ к  существующему либо создать новый
            StreamWriter file1 = new StreamWriter(dataPath);
            //записать в него
            file1.Write(textBox1.Text);
            //закрыть для сохранения данных
            file1.Close();
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            if (File.Exists(dataPath))
            {
                StreamReader file = new StreamReader(dataPath);
                textBox1.Text = file.ReadLine();
                file.Close();
            }
            OriginalImageManager imageManager = new OriginalImageManager();
            imageManager.createConfig();
        }
    }
}
