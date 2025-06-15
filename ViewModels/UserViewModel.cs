using ScrumMaui.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScrumMaui.ViewModels
{
    public class UserViewModel : IQueryAttributable, INotifyPropertyChanged
    {
        public User userParam { get; set; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            userParam = query["user"] as User;
            OnPropertyChanged("userParam");
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
