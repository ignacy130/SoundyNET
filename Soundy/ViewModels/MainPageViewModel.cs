using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Soundy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundy.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<string> Friends { get; set; }
        public ObservableCollection<string> Soundies { get; set; }
        private SoundRecordingHelper soundRecordingHelper = new SoundRecordingHelper();


        public MainPageViewModel()
        {
            this.Friends = new ObservableCollection<string>(){"Jan", "Tomek"};
            this.Soundies = new ObservableCollection<string>() { "Soudn1", "Sound2" };
        }

        public bool IsRecording { get; set; }


        public RelayCommand<bool> ToggleRecord{
            get
            {
                return new RelayCommand<bool>(
                    (obj) =>
                    {
                        soundRecordingHelper.CaptureSound();
                        this.IsRecording = !this.IsRecording;
                        if(this.IsRecording)
                        {

                        }
                        RaisePropertyChanged("IsRecording");
                    });
            }
    }
    }
}
