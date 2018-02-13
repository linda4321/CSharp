using System;
//usings that are not used
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lab01.Annotations;

namespace Lab01
{
    internal class SendDateModelView : INotifyPropertyChanged
    {
        private DateTime _dateOfBirth = DateTime.Today;
        private RelayCommand _sendDate;
        private readonly Action<bool> _showLoaderAction;
        //closeAction is never used

        internal SendDateModelView(Action<bool> showLoader)
        {
            _showLoaderAction = showLoader;
        }

        public User User
        {
            get { return CurrentUser.CurrUser; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {

                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand SendDate
        {
            get
            {
                return _sendDate ?? (_sendDate = new RelayCommand(SendDateImpl));
            }
        }

        private async void SendDateImpl(object o)
        {
            User newUser = null;

            _showLoaderAction.Invoke(true);
            await Task.Run(() =>
            {
                newUser = new User(_dateOfBirth);
                Thread.Sleep(2000);
            });
            //It is better to perform this check in constructor of User
            if (newUser.Age < 0 || newUser.Age > 135)
                MessageBox.Show("Error! Your age must be from 0 to 135");

            else
            {
                CurrentUser.CurrUser = newUser;
                OnPropertyChanged("User");
                if (IsBirthday(CurrentUser.CurrUser.DateOfBirth))
                    MessageBox.Show("Happy birhday, buddy! Now you're closer to your death than year ago)");
            }
            _showLoaderAction.Invoke(false);
        }

        private bool IsBirthday(DateTime birthdayDate)
        {
            return DateTime.Today.Month.Equals(birthdayDate.Month) && DateTime.Today.Day.Equals(birthdayDate.Day);
        }

        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
