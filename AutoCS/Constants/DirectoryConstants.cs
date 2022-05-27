using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoCS.Client.Constants
{
    class DirectoryConstants
    {
        public static readonly string WorkingPath = Application.StartupPath; // 일단은 윈폼프로그램이므로
        public static readonly DirectoryInfo ProfileDirectoryInfo = new DirectoryInfo(WorkingPath+@"\profile\");
        public static readonly DirectoryInfo ScriptDirectoryInfo = new DirectoryInfo(WorkingPath+@"\script\");
        public static readonly DirectoryInfo LibraryDirectoryInfo = new DirectoryInfo(WorkingPath+@"\library\");
        public static readonly string ScriptSubFix = ".js";
        public static void InitializeDirectory()
        {
            if (!ProfileDirectoryInfo.Exists)
            {
                ProfileDirectoryInfo.Create();
            }

            if (!ScriptDirectoryInfo.Exists)
            {
                ScriptDirectoryInfo.Create();
            }

            if (!LibraryDirectoryInfo.Exists)
            {
                LibraryDirectoryInfo.Create();
            }
        }

        public static string[] GetFilesNameFromPath(string path)
        {
            return GetFilesNameFromPath(new DirectoryInfo(path));
        }

        public static string[] GetFilesNameFromPath(DirectoryInfo directoryInfo)
        {
            var query = from file in directoryInfo.GetFiles()
                select file.Name;
            return query.ToArray();
        }
    }
}
