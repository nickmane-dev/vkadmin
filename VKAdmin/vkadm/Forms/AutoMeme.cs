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
using VKAdmin.vkadm.Forms.AutoMem;
using VKAdmin.vkadm.Forms.AutoMemeUtils;
using VKAdmin.vkadm.Manager;
using VkNet;

namespace VKAdmin.vkadm.Forms
{
    public partial class AutoMeme : Form
    {
        VkApi api;
        List<String> pub = new List<string>();
        public int index_wall = 0;

        public int countLikes = 0;
        public int countComments = 0;
        public int countReposts = 0;

        public int idpublic = 0;
        public int id_own_public = 204007373;
        public string name_own_public = "";
        public int subs_own_public = 0;

        public static string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/publics.db";
        public static string cache = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/cache/";
        public static string dataIdPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/id.vkadmin";
        WallPublicManager wallPublicManager;
        public AutoMeme(VkApi _api)
        {
            InitializeComponent();
            api = _api;
            wallPublicManager = new WallPublicManager(api);
        }

        private void AutoMem_Load(object sender, EventArgs e)
        {
            AutoPostManager apm = new AutoPostManager(api);
            reloadListPublics();
            InitializeOwnPublic();
        }

        public void postMeme()
        {
            if (listPublics.SelectedIndex == -1) return;
            AutoPostManager autoPostManager = new AutoPostManager(api);
            ConcurrentPublicsDataManager concurrentPublicsManager = new ConcurrentPublicsDataManager(api);
            autoPostManager.createNewPost_Originamizer(wallPublicManager.getPostWithPhoto_fullHD(-concurrentPublicsManager.getIdPublic(listPublics.SelectedIndex), index_wall), id_own_public);
        }
        public void postScheduleMeme()
        {
            if (listPublics.SelectedIndex == -1) return;                
            AutoPostManager autoPostManager = new AutoPostManager(api);
            ConcurrentPublicsDataManager concurrentPublicsManager = new ConcurrentPublicsDataManager(api);
            if (randomCB.Checked == true)
            {
                Random rnd = new Random();                
                autoPostManager.scheduleNewPost_Originamizer(wallPublicManager.getPostWithPhoto_fullHD(-concurrentPublicsManager.getIdPublic(listPublics.SelectedIndex), index_wall), rnd.Next(11, 59), id_own_public);            
            } else
            {
                autoPostManager.scheduleNewPost_Originamizer(wallPublicManager.getPostWithPhoto_fullHD(-concurrentPublicsManager.getIdPublic(listPublics.SelectedIndex), index_wall), int.Parse(intervalMinute.Text), id_own_public);
            }
        }

        public void switchPost (bool v)
        {
            if (listPublics.SelectedIndex == -1) return;
            ConcurrentPublicsDataManager concurrentPublicsManager = new ConcurrentPublicsDataManager(api);
            if (v)
            {
                if (index_wall == 50)
                {
                    MessageBox.Show("All posts has been watched", "Thats end", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                index_wall++;
                loadPhotoFromPost(wallPublicManager.getPostWithPhoto(-concurrentPublicsManager.getIdPublic(listPublics.SelectedIndex), index_wall));
            } else
            {
                if (index_wall == 0) return;
                index_wall--;
                loadPhotoFromPost(wallPublicManager.getPostWithPhoto(-concurrentPublicsManager.getIdPublic(listPublics.SelectedIndex), index_wall));
            }

            reloadStatisticAboutPost();
        }
        public void reloadStatisticAboutPost ()
        {
            List<int> stat = new List<int>(wallPublicManager.getPostStat(index_wall));
            countReposts = stat[0];
            countComments = stat[1];
            countLikes = stat[2];

            repostTxt.Text = "Reposts - " + countReposts;
            commentsTxt.Text = "Comments - " + countComments;
            likesTxt.Text = "Likes - " + countLikes;
        }
        public void loadPhotoFromPost (String[] url)
        {
            if (url == null)
            {
                switchPost(true);
                return;
            }

            for (int i = 0; i < _pb.Count; i++)
            {
                panel1.Controls.Remove(_pb[i]);
            }
            _pb.Clear();

            createPictureBox(url);
        }
        PictureBox pb;
        List <PictureBox> _pb = new List<PictureBox>();
        public void createPictureBox (String[] url)
        {         

            for (int i = 0; i < url.Length; i++)
            {
                pb = new PictureBox();
                pb.Name = "ph" + i;
                pb.ImageLocation = url[i];
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                switch (url.Length)
                {
                    case 1:
                        pb.Width = 750;
                        pb.Height = 440;
                        pb.Location = new Point(166, 12);
                        break;
                    case 2:
                        pb.Width = 370;
                        pb.Height = 440;
                        switch (i)
                        {
                            case 0:
                                pb.Location = new Point(166, 12);
                                break;
                            case 1:
                                pb.Location = new Point(546, 12);
                                break;
                        }
                        break;
                    case 3:
                        switch (i)
                        {
                            case 0:
                                pb.Width = 370;
                                pb.Height = 440;
                                pb.Location = new Point(166, 12);
                                break;
                            case 1:
                                pb.Width = 405;
                                pb.Height = 226;
                                pb.Location = new Point(511, 12);
                                break;
                            case 2:
                                pb.Width = 405;
                                pb.Height = 210;
                                pb.Location = new Point(511, 244);
                                break;
                        }
                        break;
                    case 4:
                        switch (i)
                        {
                            case 0:
                                pb.Width = 365;
                                pb.Height = 210;
                                pb.Location = new Point(166, 12);
                                break;
                            case 1:
                                pb.Width = 279;
                                pb.Height = 210;
                                pb.Location = new Point(511, 12);
                                break;
                            case 2:
                                pb.Width = 365;
                                pb.Height = 210;
                                pb.Location = new Point(166, 244);
                                break;
                            case 3:
                                pb.Width = 279;
                                pb.Height = 210;
                                pb.Location = new Point(511, 244);
                                break;
                        }
                        break;
                    case 5:
                        switch (i)
                        {
                            case 0:
                                pb.Width = 365;
                                pb.Height = 210;
                                pb.Location = new Point(166, 12);
                                break;
                            case 1:
                                pb.Width = 279;
                                pb.Height = 210;
                                pb.Location = new Point(511, 12);
                                break;
                            case 2:
                                pb.Width = 255;
                                pb.Height = 210;
                                pb.Location = new Point(166, 244);
                                break;
                            case 3:
                                pb.Width = 225;
                                pb.Height = 210;
                                pb.Location = new Point(427, 244);
                                break;
                            case 4:
                                pb.Width = 258;
                                pb.Height = 244;
                                pb.Location = new Point(658, 210);
                                break;
                        }
                        break;
                    case 6:
                        switch (i)
                        {
                            case 0:
                                pb.Width = 255;
                                pb.Height = 226;
                                pb.Location = new Point(266, 12);
                                break;
                            case 1:
                                pb.Width = 225;
                                pb.Height = 225;
                                pb.Location = new Point(427, 12);
                                break;
                            case 2:
                                pb.Width = 258;
                                pb.Height = 226;
                                pb.Location = new Point(658, 12);
                                break;
                            case 3:
                                pb.Width = 225;
                                pb.Height = 210;
                                pb.Location = new Point(166, 244);
                                break;
                            case 4:
                                pb.Width = 225;
                                pb.Height = 210;
                                pb.Location = new Point(427, 244);
                                break;
                            case 5:
                                pb.Width = 258;
                                pb.Height = 210;
                                pb.Location = new Point(658, 244);
                                break;
                        }
                        break;
                    case 7:
                        switch (i)
                        {
                            case 0:
                                pb.Width = 255;
                                pb.Height = 226;
                                pb.Location = new Point(266, 12);
                                break;
                            case 1:
                                pb.Width = 225;
                                pb.Height = 225;
                                pb.Location = new Point(427, 12);
                                break;
                            case 2:
                                pb.Width = 258;
                                pb.Height = 226;
                                pb.Location = new Point(658, 12);
                                break;
                            case 3:
                                pb.Width = 181;
                                pb.Height = 210;
                                pb.Location = new Point(166, 244);
                                break;
                            case 4:
                                pb.Width = 188;
                                pb.Height = 210;
                                pb.Location = new Point(353, 244);
                                break;
                            case 5:
                                pb.Width = 182;
                                pb.Height = 210;
                                pb.Location = new Point(547, 210);
                                break;
                            case 6:
                                pb.Width = 181;
                                pb.Height = 210;
                                pb.Location = new Point(735, 243);
                                break;
                        }
                        break;
                    default:
                        ConcurrentPublicsDataManager concurrentPublicsManager = new ConcurrentPublicsDataManager(api);
                        WallPublicManager wallPublicManager = new WallPublicManager(api);
                        index_wall++;
                        loadPhotoFromPost(wallPublicManager.getPostWithPhoto(-concurrentPublicsManager.getIdPublic(listPublics.SelectedIndex), index_wall));
                        return;
                }
                panel1.Controls.Add(pb);

                _pb.Add(pb);
            }
        }

        public void reloadListPublics ()
        {
            StreamReader sr = new StreamReader(dataPath, Encoding.UTF8, true);
            String[] list = sr.ReadToEnd().Split('|');
            int c = 0;
            while (c < list.Length)
            {
                pub.Add(list[c].Split(',')[0]);
                c++;
            }
            c = 0;
            while (c < pub.Count)
            {
                listPublics.Items.Add(pub[c]);
                c++;
            }
            sr.Close();
        } 

        private void addPublics_Click(object sender, EventArgs e)
        {
            AddNewPublics addNewPublics = new AddNewPublics(api);
            addNewPublics.Show();
        }

        private void AutoMeme_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void listPublics_MouseClick(object sender, MouseEventArgs e)
        {
            if (listPublics.SelectedItem == null) return;
            ConcurrentPublicsDataManager concurrentPublicsManager = new ConcurrentPublicsDataManager(api);
            //WallPublicManager wallPublicManager = new WallPublicManager(api);
            index_wall = 0;
            loadPhotoFromPost(wallPublicManager.getPostWithPhoto(-concurrentPublicsManager.getIdPublic(listPublics.SelectedIndex), index_wall));
            _help1.Visible = false;
            reloadStatisticAboutPost();
            idpublic = -concurrentPublicsManager.getIdPublic(listPublics.SelectedIndex);


        }

        private void nextPost_Click(object sender, EventArgs e)
        {
            nextPost.BorderStyle = BorderStyle.Fixed3D;
            switchPost(true);
            nextPost.BorderStyle = BorderStyle.None;
        }

        private void backPost_Click(object sender, EventArgs e)
        {
            backPost.BorderStyle = BorderStyle.Fixed3D;
            switchPost(false);
            backPost.BorderStyle = BorderStyle.None;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            postMeme();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (intervalMinute.Text.Length == 0 && randomCB.Checked == false)
            {
                MessageBox.Show("Write interval h","error",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            postScheduleMeme();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CustomizeImage ci = new CustomizeImage(this);
            ci.Show();
            this.Hide();
        }

        private void YourPubBtn_Click(object sender, EventArgs e)
        {
            AddYourPublics addYourPublics = new AddYourPublics(api);
            addYourPublics.Show();
            this.Hide();
        }

        public void InitializeOwnPublic ()
        {
            if (!File.Exists(dataIdPath)) return;
            if (File.ReadAllText(dataIdPath) == String.Empty) return;
            id_own_public = int.Parse(File.ReadAllText(dataIdPath));
            var group = api.Groups.GetById(null, id_own_public.ToString(), null).FirstOrDefault();
            name_own_public = group.Name;
            subs_own_public = group.MembersCount.GetValueOrDefault();

            namePublicInfo.Text = name_own_public;
            subscribesInfo.Text = "subs - " + subs_own_public;
        }
    }
}
