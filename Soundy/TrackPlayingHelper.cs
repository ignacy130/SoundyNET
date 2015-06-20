using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Soundy
{
    public class TrackPlayingHelper
    {
        // first define Cancellation Token Source - I've made it global so that CancelButton has acces to it
        private CancellationTokenSource cts = new CancellationTokenSource();
        private enum Problem { Ok, Cancelled, Other }; // results of my Task

        public TrackPlayingHelper(Track track, MediaElement playbackElement)
        {
            HttpClient httpc = new HttpClient();

            foreach (var item in track.Sounds)
            {
                httpc = new HttpClient();
                httpc.BaseAddress = new Uri(item.FilePath);
                //var res = httpc.GetAsync();

            }
        }



    }
}
