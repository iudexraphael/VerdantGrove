using System;
using System.Collections.Generic;
using System.Text;

using System.Threading.Tasks;
using Xamarin.Forms;
using MvvmHelpers;

using TreeAwarenessFirebase.Services;
using TreeAwarenessFirebase.Model;
using System.Collections.ObjectModel;

namespace TreeAwarenessFirebase.ViewModel
{
   public class MessageViewModel : BaseViewModel
    {
        public int MessageID { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }

        public string Image { get; set; }

        private DBFirebase services;
        public Command AddMessageCommand { get; }
        public ObservableCollection<UserMessages> _messages = new ObservableCollection<UserMessages>();
        public ObservableCollection<UserMessages> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                OnPropertyChanged();
            }
        }

        public MessageViewModel()
        {
            services = new DBFirebase();
            Messages = services.getMessage();
            AddMessageCommand = new Command(async () => await addMessageAsync(MessageID, Username, Comment,
                Image));

        }
        public async Task addMessageAsync(int MessageID, string Username, string Comment, string Image)
        {
            await services.AddMessage(MessageID, Username, Comment, Image);
        }

    }
}