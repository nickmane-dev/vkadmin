using ImageProcessor.Imaging.Filters.Photo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using VkNet;
using VkNet.Model.Attachments;
using VkNet.Model.RequestParams;

namespace VKAdmin.vkadm.Manager
{
    class AutoPostManager
    {
        public VkApi api;
        module m = new module();
        public string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"/VKAdmin/cache/";

        public AutoPostManager (VkApi _api)
        {
            api = _api;
        }
        public void scheduleNewPost_Originamizer(String[] url, int min, int id_public)
        {
            downloadPhotos(url);
            // Получить адрес сервера для загрузки.
            var uploadServer = api.Photo.GetWallUploadServer(id_public);
            // Загрузить файл.
            var wc = new WebClient();
            var responseFile = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, dataPath + "0.jpg"));

            ReadOnlyCollection<Photo> photos = api.Photo.SaveWallPhoto(responseFile, null, (ulong)id_public);
            List<MediaAttachment> attachments = new List<MediaAttachment>();
            attachments.AddRange(photos);

            for (int i = 1; i < url.Length; i++)
            {
                responseFile = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, dataPath + i + ".jpg"));
                photos = api.Photo.SaveWallPhoto(responseFile, null, (ulong)id_public);
                attachments.AddRange(photos);
            }

            var getSchedulePosts = api.Wall.Get(new WallGetParams
            {
                OwnerId = -id_public,
                Filter = VkNet.Enums.SafetyEnums.WallFilter.Postponed
            });

            DateTime dateTime;
            if (getSchedulePosts.WallPosts.Count >= 1) { 
                dateTime = getSchedulePosts.WallPosts[getSchedulePosts.WallPosts.Count - 1].Date.Value;;
                dateTime = dateTime.AddMinutes(min);
                dateTime = dateTime.AddHours(1);
                if (dateTime.Hour == 0 || dateTime.Hour == 1 || dateTime.Hour == 2)
                    dateTime.AddHours(11);
            } else
            {
                dateTime = DateTime.Now;
                
                dateTime = dateTime.AddMinutes(min);
                dateTime = dateTime.AddHours(1);
                if (dateTime.Hour == 0 || dateTime.Hour == 1 || dateTime.Hour == 2)
                    dateTime.AddHours(11); 

                

                
            }

            var post = api.Wall.Post(new WallPostParams
            {
                OwnerId = -id_public,
                FriendsOnly = false,
                FromGroup = true,
                Attachments = attachments,
                Signed = true,
                PublishDate = dateTime
            }) ;
        }

        public void createNewPost_Originamizer (String[] url, int id_public)
        {
            downloadPhotos(url);
            // Получить адрес сервера для загрузки.
            var uploadServer = api.Photo.GetWallUploadServer(id_public);
            // Загрузить файл.
            var wc = new WebClient();
            var responseFile = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, dataPath + "0.jpg"));

            ReadOnlyCollection<Photo> photos = api.Photo.SaveWallPhoto(responseFile, null, (ulong)id_public);
            List<MediaAttachment> attachments = new List<MediaAttachment>();
            attachments.AddRange(photos);

            for (int i = 1; i < url.Length; i++)
            {
                responseFile = Encoding.ASCII.GetString(wc.UploadFile(uploadServer.UploadUrl, dataPath + i + ".jpg"));
                photos = api.Photo.SaveWallPhoto(responseFile, null, (ulong)id_public);
                attachments.AddRange(photos);
            }                                   

            var post = api.Wall.Post(new WallPostParams
            {
                OwnerId = -id_public,
                FriendsOnly = false,
                FromGroup = true,
                Attachments = attachments,
                Signed = true
            });            
        }

        public void downloadPhotos (String[] url)
        {
            DirectoryInfo v = new DirectoryInfo(dataPath);
            
            FileInfo[] files = new FileInfo[v.GetFiles().Length];
            files = v.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                files[i].Delete();
            }            

            OriginalImageManager imageManager = new OriginalImageManager();
            using (WebClient webClient = new WebClient())
            {
                for (int i = 0; i < url.Length; i++)
                {
                    var imageStream = webClient.OpenRead(url[i]);
                    {
                        Image img = Image.FromStream(imageStream);
                        img.Save(i + ".jpg"); // сохраняем                          
                        imageManager.getImage(i,Image.FromFile(i + ".jpg"));
                    }
                }
            }

        }



    }
}
