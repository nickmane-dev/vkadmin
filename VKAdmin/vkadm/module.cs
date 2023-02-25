using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VKAdmin.vkadm.Forms;
using VkNet;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VKAdmin.vkadm
{
    class module
    {

        public VkApi api = new VkApi();

        public VkApi GetVkApi ()
        {
            return api;
        }

        public Boolean tryEntry(string _accessToken)
        {
            try
            {
                api.Authorize(new ApiAuthParams()
                {
                    AccessToken = _accessToken
                });
            } catch
            {
                return false;
            }

            //sendMessage();

            return true;
        }

        public void sendMessage()
        {
            api.Messages.SendAsync(new MessagesSendParams
            {

                UserId = 229102651, // Тут  вообще  должен быть id  ведь у меня в списке 20+ друзей и тогда куда мне их id вписывать ? 
                Message = "пишет ботик",
                RandomId = new Random().Next()

            });
        }
    }
}
