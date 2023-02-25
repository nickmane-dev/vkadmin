using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;

namespace VKAdmin.vkadm.Manager
{
    class ConcurrentPublicsDataManager
    {
        public VkApi api = new VkApi();
        public ConcurrentPublicsDataManager (VkApi _api)
        {
            api = _api;
        }

        public static string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/publics.db";

        public int getIdPublic (int index)
        {
            StreamReader streamReader = new StreamReader(dataPath, Encoding.UTF8, true);
            int id = int.Parse(streamReader.ReadToEnd().Split('|')[index].Split(',')[1]);
            return id;
        }

        public bool addLink (string _link)
        {
            String link = _link;
            if (link.Length > 100) return false;
            if (link.Contains("/"))
            {
                String[] link_arr = link.Split('/');
                if (link_arr[link_arr.Length - 1] != "")
                {
                    link = link_arr[link_arr.Length - 1];
                } else
                {
                    link = link_arr[link_arr.Length - 2];
                }
            }

            try
            {
                var group = api.Groups.GetById(null, link, null).FirstOrDefault();
                saveLink(group);

            } catch
            {
                return false;
            }

            return true;
        }

        public void saveLink (VkNet.Model.Group group)
        {
            using (StreamWriter sw = new StreamWriter(dataPath, true, Encoding.UTF8))
            {
                sw.WriteLine(group.Name + "," + group.Id + "|");
            }
        }

        public void removeLink (int index)
        {
            StreamReader sr = new StreamReader(dataPath, Encoding.UTF8, true);
            String[] list = sr.ReadToEnd().Split('|');
            sr.Close();

            File.Delete(dataPath); createData();

            StreamWriter sw = new StreamWriter(dataPath, true, Encoding.UTF8);          

            for (int i = 0; i < list.Length - 1; i++)
            {
                if (i != index)
                {
                    sw.WriteLine(list[i] + "|");
                }
            }

            sw.Close();

        }

        public void createData()
        {
            if (!File.Exists(dataPath))
            {
                File.Create(dataPath).Close();
            }
        }

    }
}
