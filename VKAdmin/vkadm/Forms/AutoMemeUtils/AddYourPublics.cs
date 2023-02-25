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
using VkNet;

namespace VKAdmin.vkadm.Forms.AutoMemeUtils
{
    public partial class AddYourPublics : Form
    {
        VkApi api;
        public static string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/id.vkadmin";
        public long[] id;
        public AddYourPublics(VkApi _api)
        {
            InitializeComponent();
            api = _api;
        }

        private void AddYourPublics_Load(object sender, EventArgs e)
        {
            var groups = api.Groups.Get(new VkNet.Model.RequestParams.GroupsGetParams
            {
                Filter = VkNet.Enums.Filters.GroupsFilters.Editor
            });

            id = new long[groups.Count];
            for (int i = 0; i < id.Length; i++)
            {
                id[i] = groups[i].Id;
                listPublics.Items.Add(groups[i].Id + "");
            }          

        }

        public void saveAction ()
        {
            if (!File.Exists(dataPath))
            {
                File.Create(dataPath).Close();
                StreamWriter sw = new StreamWriter(dataPath);
                sw.Write(id[listPublics.SelectedIndex] + "");
                sw.Close();
            }            
        }

        private void ready_Click(object sender, EventArgs e)
        {
            saveAction();
            AutoMeme form = new AutoMeme(api);
            form.InitializeOwnPublic();
            form.Show();
        }
    }
}
