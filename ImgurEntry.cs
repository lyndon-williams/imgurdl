using System;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace imgurdl
{
    public class ImgurEntry
    {
        public ImgurEntry(XElement elm)
        {
            this.Title = elm.Element("title").Value;
            this.Hash = elm.Element("hash").Value;
            this.Extension = elm.Element("ext").Value;
            this.Points = Convert.ToInt32(elm.Element("points").Value);
            this.NSFW = Convert.ToBoolean(elm.Element("nsfw").Value);
        }

        public string Title
        {
            get;
            private set;
        }

        public string Hash
        {
            get;
            private set;
        }

        public string Extension
        {
            get;
            private set;
        }

        public int Points
        {
            get;
            private set;
        }

        public bool NSFW
        {
            get;
            private set;
        }

        public string FileName
        {
            get { return Hash + Extension; }
        }

        public string FormattedName
        {
            get { return string.Format("{0} - {1}", Points, FileName); }
        }

        public string URL
        {
            get { return string.Format("http://i.imgur.com/{0}", FileName); }
        }

        public void Download(string storagepath, WebClient wc)
        {
            // TODO: Improve this code
            // Something that ensures it's downloaded and that it never gets stuck
            wc.DownloadFile(URL, Path.Combine(storagepath, FormattedName));
        }
    }
}
