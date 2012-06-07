using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace imgurdl
{
    public class Subreddit
    {
        public Subreddit(SubredditEntry entry)
        {
            this.Name = entry.Name;
            this.Type = "/";
            this.NSFW = entry.NSFW;
            this.MinPage = entry.MinPage;
            this.MaxPage = entry.MaxPage;
            this.CurrentPage = 0;
        }

        private List<string> existingFiles;
        private Thread _worker;
        private bool areWeDone = false;

        public string Name
        {
            get;
            private set;
        }

        public string Type
        {
            get;
            set;
        }

        public NSFWFilter NSFW
        {
            get;
            private set;
        }

        public int MinPage
        {
            get;
            private set;
        }

        public int MaxPage
        {
            get;
            private set;
        }

        public int CurrentPage
        {
            get;
            private set;
        }       

        public string URL
        {
            get { return string.Format("http://imgur.com/r/{0}{1}page/{2}.xml", Name, Type, CurrentPage); }
        }

        public int Total
        {
            get;
            private set;
        }

        public int Downloaded
        {
            get;
            private set;
        }

        public int Skipped
        {
            get;
            private set;
        }

        public bool Done
        {
            get { return areWeDone || (_worker == null || !_worker.IsAlive); }
        }

        public void Download(string storagePath)
        {
            // TODO: Improve this code
            _worker = new Thread(() =>
            {
                var wc = new WebClient();
                var dir = Path.Combine(storagePath, Name);
                Directory.CreateDirectory(dir);
                areWeDone = false;
                this.CurrentPage = this.MinPage;
                for (int i = this.CurrentPage; i < (this.MaxPage == 0 ? Settings.Instance.Pages : this.MaxPage); i++)
                {
                    try
                    {
                        var req = WebRequest.Create(URL) as HttpWebRequest;
                        var file = XElement.Load(req.GetResponse().GetResponseStream());
                        var allImages = file.Descendants("item").Select(x => new ImgurEntry(x));
                        if (allImages == null || allImages.Count() == 0)
                        {
                            areWeDone = true;
                            break;
                        }
                        Total += allImages.Count();
                        foreach (var img in allImages)
                        {
                            if (FileAlreadyExists(dir, img))
                            {
                                Skipped++;
                                continue;
                            }

                            if (this.NSFW == NSFWFilter.All || (img.NSFW && this.NSFW == NSFWFilter.OnlyNSFW) || (!img.NSFW && this.NSFW == NSFWFilter.NoNSFW))
                            {
                                try
                                {
                                    Log.WriteLine("[{0}] Downloading '{1}' as '{2}' with {3} points", this.Name, img.Title, img.FormattedName, img.Points);
                                    img.Download(dir, wc);
                                    Downloaded++;
                                    Thread.Sleep(Settings.Instance.SleepBetweenImages);
                                }
                                catch { Skipped++; }
                            }
                            else { Skipped++; }
                        }
                    }
                    catch (XmlException e)
                    {
                        Log.WriteLine("Please report this invalid XML to the Imgur staff:\n{0}\nFrom link: {1}", e.Message, this.URL);
                    }
                    catch (WebException e)
                    {
                        Log.WriteLine("An error occured in the program, please notify the developer with this:\n{0}\nLink: {1}", e.Message, this.URL);
                    }
                    CurrentPage = i;

                    if (areWeDone)
                        break;

                    Thread.Sleep(Settings.Instance.SleepBetweenPages);
                }

                CurrentPage = 0;
            });
            _worker.Start();
        }

        public void Stop()
        {
            if (_worker != null)
                _worker.Abort();
            _worker = null;
        }

        private bool FileAlreadyExists(string dir, ImgurEntry img)
        {
            if (existingFiles == null)
                existingFiles = Directory.GetFiles(dir).ToList();
            for (var i = 0; i < existingFiles.Count; i++)
            {
                var file = existingFiles[i];
                if (file.EndsWith(img.FormattedName)) // No problem, file name is the same
                    return true;

                if (file.EndsWith(img.FileName)) // Problem, upvotes has probably changed
                {
                    try
                    {
                        var newFile = Path.Combine(dir, img.FormattedName);
                        File.Move(file, newFile);
                        existingFiles[i] = newFile;
                        Log.WriteLine("[{0}] Renamed existing file '{1}' to '{2}'", this.Name, file, newFile);
                    }
                    catch { }
                    return true;
                }
            }

            return false;
        }
    }

    [Serializable]
    public class SubredditEntry
    {
        public SubredditEntry()
        {
            this.Name = string.Empty;
            this.MinPage = 0;
            this.MaxPage = 0;
            this.NSFW = NSFWFilter.All;
        }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public int MinPage { get; set; }

        [XmlAttribute]
        public int MaxPage { get; set; }

        [XmlAttribute]
        public NSFWFilter NSFW { get; set; }
    }

    public enum NSFWFilter
    {
        All,
        NoNSFW,
        OnlyNSFW
    }
}
