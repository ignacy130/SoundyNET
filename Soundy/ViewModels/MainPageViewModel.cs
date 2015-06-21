using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
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
        private INavigationService navigationService;
        public ObservableCollection<string> Friends { get; set; }
        public ObservableCollection<string> Soundies { get; set; }


        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.Friends = new ObservableCollection<string>() {"Jan", "Grzegorz", "Tomek" };
            this.Soundies = new ObservableCollection<string>() { "Birthday's", "Greetings", "Stronger" };

            this.Soundies = new ObservableCollection<string>() { "Soudn1", "Sound2" };
            SoundRecordingHelper.Instance._dispatcherTimer.Tick += _dispatcherTimer_Tick;
            
        }

        private async void getDBData() {
            //this.Friends = new ObservableCollection<User>( await Dao<User>.GetAll());
        }

        void _dispatcherTimer_Tick(object sender, object e)
        {
            this.navigationService.NavigateTo("RehearsePage");
        }

        public bool IsRecording { get; set; }

        public RelayCommand<bool> ToggleRecord{
            get
            {
                return new RelayCommand<bool>(
                    (obj) =>
                    {
                        SoundRecordingHelper.Instance.CaptureSound();
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
