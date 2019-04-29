using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnStudy.ViewModels
{
    public class AddMovieInput : FormFileUploadInput
    {
        public string MovieName { get; set; }

        public string MovieDesc { get; set; }

        public string MovieUrl
        {
            get
            {
                var url = "";
                if (FileListInfo != null && FileListInfo.Count > 0)
                {
                    FileListInfo.ForEach(item => url += item.WebUrl + ";");
                }
                return url;
            }
        }

        public override string SetFileSavePath(string Key)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = path + @"Movies\" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + @"\";
            return path;
        }
        public override string SetWebUrlPath(string Key)
        {
            var path = @"/";
            path = path + @"Movies/" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + @"/";
            return path;
        }
    }
}