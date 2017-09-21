using System;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ClosingHandles.Data
{
    public static class Jokes
    {
        public static string FileName { get; set; }

        public static async Task Initialize()
        {
            StreamReader sr = new StreamReader (
                typeof(Jokes).GetTypeInfo().Assembly.GetManifestResourceStream ("ClosingHandles.Data.jokes.txt"));
            var data = await sr.ReadToEndAsync ();
#if __IOS__
            var folder = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments),
                                    "..", "Library");
            FileName = Path.Combine (folder, "jokes.txt");
#elif __ANDROID__
            FileName = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments),
                                        "jokes.txt");
#elif WINDOWS_UWP
            string folder = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            FileName = Path.Combine(folder, "jokes.txt");
#endif
            File.WriteAllText(FileName, data);
        }
    }
}

