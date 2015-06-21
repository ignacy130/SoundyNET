using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml;

namespace Soundy
{
    public class SoundRecordingHelper
    {
        public DispatcherTimer _dispatcherTimer = new DispatcherTimer();
        public MediaCapture _mediaCaptureManager;
        public bool _rawAudioSupported;
        public bool _recording;
        public bool _userRequestedRaw;
        private static SoundRecordingHelper instance;

        public static SoundRecordingHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SoundRecordingHelper();
                }
                return instance;
            }
        }

        private SoundRecordingHelper()
        {
            _dispatcherTimer.Tick += _dispatcherTimer_Tick;
            InitializeAudioRecording();
        }

        public StorageFile _recordStorageFile { get; private set; }

        public void _dispatcherTimer_Tick(object sender, object e)
        {
            StopTimer();
            _dispatcherTimer.Stop();
            _recording = false;
        }

        public void CaptureSound()
        {
            _dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            _dispatcherTimer.Start();
            CaptureAudio();
        }

        private async void CaptureAudio()
        {
            try
            {
                Debug.WriteLine("Starting record");
                String fileName = "record.m4a";

                _recordStorageFile = await KnownFolders.VideosLibrary.CreateFileAsync(fileName, CreationCollisionOption.GenerateUniqueName);

                Debug.WriteLine("Create record file successfully");

                MediaEncodingProfile recordProfile = MediaEncodingProfile.CreateM4a(AudioEncodingQuality.Auto);
                await _mediaCaptureManager.StartRecordToStorageFileAsync(recordProfile, this._recordStorageFile);

                Debug.WriteLine("Start Record successful");

                _recording = true;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to capture audio");
            }
        }

        private void failedToRec(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            //throw new NotImplementedException();
            Debug.WriteLine("Device failed to rec");
        }

        private void failedToRec(MediaCapture sender)
        {
            //throw new NotImplementedException();
            Debug.WriteLine("Device failed to rec2");
        }

        private async void InitializeAudioRecording()
        {
            _mediaCaptureManager = new MediaCapture();
            var settings = new MediaCaptureInitializationSettings();
            settings.StreamingCaptureMode = StreamingCaptureMode.Audio;
            settings.MediaCategory = MediaCategory.Other;
            settings.AudioProcessing = (_rawAudioSupported && _userRequestedRaw) ? AudioProcessing.Raw : AudioProcessing.Default;

            await _mediaCaptureManager.InitializeAsync(settings);

            Debug.WriteLine("Device initialised successfully");

            _mediaCaptureManager.RecordLimitationExceeded += new RecordLimitationExceededEventHandler(failedToRec);
            _mediaCaptureManager.Failed += new MediaCaptureFailedEventHandler(failedToRec);
        }
        private async void StopTimer()
        {
            Debug.WriteLine("Stopping recording");
            await _mediaCaptureManager.StopRecordAsync();
            Debug.WriteLine("Stop recording successful");
            _recording = false;
        }
    }
}
