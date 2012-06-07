using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

namespace imgurdl
{
    public static class Log
    {
        private static LinkedList<ILog> LogReaders = new LinkedList<ILog>();
        private static LinkedList<string> LogContent = new LinkedList<string>();

        public static void WriteLine(string text, params object[] args)
        {
            var entry = string.Format("[{0}] {1}", DateTime.Now.ToString("HH:mm:ss"), string.Format(text, args));
            LogContent.AddLast(entry);

            foreach (var LogReader in LogReaders)
                LogReader.WriteLine(entry);
        }

        public static void AddReader(ILog LogReader)
        {
            LogReaders.AddLast(LogReader);
            lock (LogContent)
            {
                foreach (var LogLines in LogContent)
                    LogReader.WriteLine(LogLines);
            }
        }

        public static void RemoveReader(ILog LogReader)
        {
            LogReaders.Remove(LogReader);
        }
    }

    public class LogReader : ILog, INotifyPropertyChanged
    {
        public LogReader(string name, int maxLength = 1000000)
        {
            this.name = name;
            this.maxLength = maxLength;

            text = "";
        }

        private string name;
        private int maxLength;
        private string text;

        public override string ToString()
        {
            return name;
        }

        #region ILogReader

        public void WriteLine(string line)
        {
            text += line + Environment.NewLine;

            if (text.Length > maxLength)
            {
                text = text.Substring(maxLength / 10);

                int index = text.IndexOf(Environment.NewLine);
                if (index != -1)
                    text = text.Substring(index + 1);
            }

            OnPropertyChanged("Text");
        }

        public void Clear()
        {
            text = "";

            OnPropertyChanged("Text");
        }

        #endregion

        #region INotifyPropertyChanged

        protected void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public string Name
        {
            get { return name; }
        }

        public string Text
        {
            get { return text; }
        }

        #endregion
    }

    public interface ILog
    {
        void WriteLine(string line);
    }

    public class FileLogger : ILog
    {
        private StreamWriter sw;

        public FileLogger()
        {
            sw = new StreamWriter(Path.Combine(Settings.Instance.StoragePath, "log.txt"));
            sw.AutoFlush = true;
        }

        public void WriteLine(string line)
        {
            sw.WriteLine(line);
        }
    }
}
