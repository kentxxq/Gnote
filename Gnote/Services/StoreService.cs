using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gnote.Interfaces;
using Windows.Storage;

namespace Gnote.Services
{
    internal class StoreService : IStore
    {
        // 默认数据目录
        private readonly string DefaultDataPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + Path.DirectorySeparatorChar + "GNote";
        //private readonly string DefaultDataPath = @"d:\test_code\gnote";

        public string GetDataPath()
        {
            return ApplicationData.Current.LocalSettings.Values.ContainsKey("DataPath")
                ? ApplicationData.Current.LocalSettings.Values["DataPath"].ToString()
                : DefaultDataPath;
        }

        public string GetNotePath()
        {
            return GetDataPath() + Path.DirectorySeparatorChar + "notes";
        }
    }
}
