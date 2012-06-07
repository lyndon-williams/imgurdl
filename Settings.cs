using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace imgurdl
{
    [Serializable]
    public class Settings
    {
        public static Settings Instance = null;

        public Settings()
        {
            StoragePath = Environment.CurrentDirectory;
            Pages = 1000;
            SleepBetweenImages = 325;
            SleepBetweenPages = 100;
            Subreddits = new List<SubredditEntry>();
        }

        [XmlIgnore]
        [Browsable(false)]
        public string FileName { get; private set; }

        [Description("Where all your downloaded files are stored")]
        [EditorAttribute(typeof(System.Windows.Forms.Design.FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string StoragePath
        {
            get;
            set;
        }

        [Description("Max pages to scan through unless specificly set")]
        public int Pages
        {
            get;
            set;
        }

        [Description("Sleep between each image download")]
        public int SleepBetweenImages
        {
            get;
            set;
        }

        [Description("Sleep between each page scanned")]
        public int SleepBetweenPages
        {
            get;
            set;
        }

        public List<SubredditEntry> Subreddits { get; set; }

        public void Save()
        {
            var xs = new XmlSerializer(typeof(Settings));
            using (var sw = File.CreateText(FileName))
            {
                xs.Serialize(sw, this);
            }
        }

        public static Settings Load(string fileName)
        {
            Settings settings = null;
            if (File.Exists(fileName))
            {
                using (var fs = new FileStream(fileName, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(Settings));
                    settings = (Settings)serializer.Deserialize(fs);
                }
            }
            else
            {
                settings = new Settings() { FileName = fileName };
                settings.Save();
            }
            settings.FileName = fileName;
            return settings;
        }
    }
}
