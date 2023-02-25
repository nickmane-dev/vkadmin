using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VkNet;
using VkNet.Model.RequestParams;

namespace VKAdmin.vkadm.Manager
{
    class WallPublicManager
    {

        VkApi api = new VkApi();
        VkNet.Model.WallGetObject get;
        bool isExistNow = false;
        public WallPublicManager (VkApi _api)
        {
            api = _api;
        } 

        public void getWallPublic (int id_public)
        {
            if (isExistNow)
            {
                if (get.WallPosts[0].OwnerId == id_public) return;
                var _get = api.Wall.Get(new WallGetParams
                {
                    OwnerId = id_public,
                    Count = 51,
                    Filter = VkNet.Enums.SafetyEnums.WallFilter.All

                });
                get = _get;
            } else
            {
                var _get = api.Wall.Get(new WallGetParams
                {
                    OwnerId = id_public,
                    Count = 51,
                    Filter = VkNet.Enums.SafetyEnums.WallFilter.All

                });
                get = _get;
            }
            isExistNow = true;

        }

        public String[] getPostWithPhoto(int id_public, int index_wall)
        {
            getWallPublic(id_public);

            String[] url = new string[get.WallPosts[index_wall].Attachments.Count];
            if (url.Length == 0) return null;

            for (int i = 0; i < get.WallPosts[index_wall].Attachments.Count; i++)
            {
                if ((get.WallPosts[index_wall].Attachments[i].Instance as VkNet.Model.Attachments.Video) != null ||
                    (get.WallPosts[index_wall].Attachments[i].Instance as VkNet.Model.Attachments.Document) != null ||
                    (get.WallPosts[index_wall].Attachments[i].Instance as VkNet.Model.Attachments.Photo) == null) return null;
                url[i] = (get.WallPosts[index_wall].Attachments[i].Instance as VkNet.Model.Attachments.Photo).Sizes[2].Url.ToString();
            }
            Clipboard.SetText(url[0]);
            return url;
        }

        public String[] getPostWithPhoto_fullHD(int id_public, int index_wall)
        {
            getWallPublic(id_public);

            String[] url = new string[get.WallPosts[index_wall].Attachments.Count];
            if (url.Length == 0) return null;

            for (int i = 0; i < get.WallPosts[index_wall].Attachments.Count; i++)
            {
                if ((get.WallPosts[index_wall].Attachments[i].Instance as VkNet.Model.Attachments.Video) != null ||
                    (get.WallPosts[index_wall].Attachments[i].Instance as VkNet.Model.Attachments.Document) != null) return null;
                url[i] = GetUrlOfBigPhoto(get.WallPosts[index_wall].Attachments[i].Instance as VkNet.Model.Attachments.Photo);
            }
            Clipboard.SetText(url[0]);
            return url;
        }

        public List<int> getPostStat (int index_wall)
        {
            List<int> stat = new List<int>();

            stat.Add(get.WallPosts[index_wall].Reposts.Count);
            stat.Add(get.WallPosts[index_wall].Comments.Count);
            stat.Add(get.WallPosts[index_wall].Likes.Count);

            return stat;
        }

        public static string GetUrlOfBigPhoto(VkNet.Model.Attachments.Photo photo)
        {
            if (photo == null)
                return null;
            if (photo.Photo2560 != null)
                return photo.Photo2560.AbsoluteUri;
            if (photo.Photo1280 != null)
                return photo.Photo1280.AbsoluteUri;
            if (photo.Photo807 != null)
                return photo.Photo807.AbsoluteUri;
            if (photo.Photo604 != null)
                return photo.Photo604.AbsoluteUri;
            if (photo.Photo130 != null)
                return photo.Photo130.AbsoluteUri;
            if (photo.Photo75 != null)
                return photo.Photo75.AbsoluteUri;
            if (photo.Sizes?.Count > 0)
            {
                var bigSize = photo.Sizes[0];
                for (int i = 0; i < photo.Sizes.Count; i++)
                {
                    var photoSize = photo.Sizes[i];
                    if (photoSize.Height > bigSize.Height && photoSize.Width > bigSize.Width)
                        bigSize = photoSize;
                }
                return bigSize.Url.ToString();
            }
            return null;
        }
    }
}
