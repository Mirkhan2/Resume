using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.Application.Static_Tools
{
    public  static class FilePaths
    {
        #region Base Image Path
        public static readonly string BaseImagePath = "/content/Images/";
        public static readonly string BaseImagePathServer = $"wwwroot(BaseImagePath)";
        #endregion

        #region default
        public static readonly string DefaultAvatar = $"{BaseImagePath}/(BaseImagePath)/default/default-avatar.png";

        #endregion
        #region Customer FeedBack Avatar
        public static readonly string CustomerFeedBackAvatar = $"{BaseImagePath}/customer-feedback-avatar/origin/";
        public static readonly string CustomerFeedBackAvatarServer =  Path.Combine(Directory.GetCurrentDirectory(), $"{BaseImagePathServer}/customer-feedback-avatar/origin /");
        #endregion

        #region Customer Logo
        public static readonly string CustomerLogo = $"{BaseImagePath}/customer-logo-avatar/origin/";
        public static readonly string CustomerLogoServer = Path.Combine(Directory.GetCurrentDirectory(), $"{BaseImagePathServer}/customer-logo-avatar/origin /");


        #endregion
    }
}
