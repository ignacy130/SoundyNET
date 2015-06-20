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
        private Track _track { get; set; }
        private MediaElement _playbackElement { get; set; }
        private int nowPlaying = 0;
        public TrackPlayingHelper(Track track, MediaElement playbackElement)
        {
            _track = track;
            _playbackElement = playbackElement;
            _playbackElement.MediaEnded +=_playbackElement_MediaEnded;
            _playbackElement.MediaFailed += _playbackElement_MediaFailed;
        }

        private void _playbackElement_MediaFailed(object sender, Windows.UI.Xaml.ExceptionRoutedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void _playbackElement_MediaEnded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            nowPlaying++;
            if (nowPlaying < _track.Sounds.Count)
            {
                var sound = _track.Sounds.Single(x => x.StepNumber == nowPlaying);
                _playbackElement.Source = new Uri(sound.FilePath, UriKind.RelativeOrAbsolute);

                _playbackElement.AutoPlay = true;
                _playbackElement.Play();
            }
        }



        public void playTrack() {
            if (_track.Sounds.Any())
            {
                var sound = _track.Sounds.OrderBy(x => x.StepNumber).First();
                _playbackElement.Source = new Uri(sound.FilePath, UriKind.RelativeOrAbsolute);

                _playbackElement.AutoPlay = true;
                _playbackElement.Play();
            }
        }

    }
}
