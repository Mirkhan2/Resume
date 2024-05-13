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
        #region Base Image Paths
        public static readonly string BaseImagePath = "/content/images/";
        public static readonly string BaseImagePathServer = $"wwwroot{BaseImagePath}";
        #endregion

        #region default
        public static readonly string DefaultAvatar = $"{BaseImagePath}/default/default-avatar.png";
        #endregion


        #region Customer Feedback Avatar
        public static readonly string CustomerFeedbackAvatar = $"{BaseImagePath}/customer-feedback-avatar/origin/";
        public static readonly string CustomerFeedbackAvatarServer = Path.Combine(Directory.GetCurrentDirectory(), $"{BaseImagePathServer}/customer-feedback-avatar/origin/");
        #endregion


        #region Customer Logo
        public static readonly string CustomerLogo = $"{BaseImagePath}/customer-logo/origin/";
        public static readonly string CustomerLogoServer = Path.Combine(Directory.GetCurrentDirectory(), $"{BaseImagePathServer}/customer-logo/origin/");
        #endregion


        #region Portfolio
        public static readonly string Portfolio = $"{BaseImagePath}/portfolio/origin/";
        public static readonly string PortfolioServer = Path.Combine(Directory.GetCurrentDirectory(), $"{BaseImagePathServer}/portfolio/origin/");
        #endregion


        #region Avatar
        public static readonly string Avatar = $"{BaseImagePath}/avatar/origin/";
        public static readonly string AvatarServer = Path.Combine(Directory.GetCurrentDirectory(), $"{BaseImagePathServer}/avatar/origin/");
        #endregion


        #region Resume
        public static readonly string Resume = $"{BaseImagePath}/resume/origin/";
        public static readonly string ResumeServer = Path.Combine(Directory.GetCurrentDirectory(), $"{BaseImagePathServer}/resume/origin/");
        #endregion
    }
}
