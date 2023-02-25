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
using VkNet;

namespace VKAdmin.vkadm.Forms.AutoMem
{
    public partial class AddNewPublics : Form
    {
        public static string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/publics.db";
        VkApi api = new VkApi();

        public AddNewPublics(VkApi _api)
        {
            InitializeComponent();
            api = _api;
        }
        List<String> pub = new List<string>();
        private void addMore_Click(object sender, EventArgs e)
        {
            if (link.TextLength >= 2)
            {
                ConcurrentPublicsDataManager cpm = new ConcurrentPublicsDataManager(api);
                bool isValid = cpm.addLink(link.Text);
                if (!isValid)
                {
                    MessageBox.Show("Format link is not valid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   else
                {
                    reloadListBox();
                }        
            } else
            {
                MessageBox.Show("You forgot to enter the link", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reloadListBox ()
        {
            listPublics.Items.Clear();
            pub.Clear();
            StreamReader sr = new StreamReader(dataPath, Encoding.UTF8, true);
            String[] list = sr.ReadToEnd().Split('|');
            int c = 0;
            while (c < list.Length - 1)
            {
                pub.Add(list[c].Split(',')[0]);
                c++;
            }
            c = 0;
            while (c < pub.Count) {
                listPublics.Items.Add(pub[c]);
                c++;
            }
            sr.Close();
        }
        private void removePublic ()
        {
            ConcurrentPublicsDataManager concurrentPublicsManager = new ConcurrentPublicsDataManager(api);
            concurrentPublicsManager.removeLink(listPublics.SelectedIndex);
            reloadListBox();
        }

        private void listPublics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            removePublic();
        }

        private void AddNewPublics_Load(object sender, EventArgs e)
        {

            reloadListBox();
            
        }

        private void AddNewPublics_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        
    }
}
