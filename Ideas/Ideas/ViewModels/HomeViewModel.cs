using Ideas.Models;
using Ideas.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Ideas.Annotations;
using Xamarin.Forms;

namespace Ideas.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged 
    {
        ApiServices _apiServices = new ApiServices();
        private List<Idea> _ideas;

        public string AccessToken { get; set; }

        public List<Idea> Ideas
        {
            get { return _ideas; }
            set
            {
                _ideas = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetIdeasCommand
        {
            get
            {
                return new Command(async() =>
               {
                   Ideas = await _apiServices.GetIdeasAsync(AccessToken);
               });
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string 
            propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs
                (propertyName));
        }
    }
}
