using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Soundy
{
    public class SoundsManager
    {
        public IReadOnlyList<StorageFile> Sounds { get; set; }

        public SoundsManager()
        {
            DeleteFiles();
        }

        public async void DeleteFiles()
        {
            //this.Sounds = await KnownFolders.VideosLibrary.GetFilesAsync();
            //foreach (var item in Sounds)
            //{
            //        Debug.WriteLine(item.Name);
            //    if (item.Name.Contains("record"))
            //    {
            //        await item.DeleteAsync();
            //    }
            //}
        }

    }
}
