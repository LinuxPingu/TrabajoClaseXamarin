using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrabajoClaseXamarin.ModelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabajoClaseXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatView : ContentPage
    {
     
        public ICommand ScrollListCommand { get; set; }
        public ChatView()
        {
            InitializeComponent();
            BindingContext = MessageViewModel.getInstance();
            ScrollListCommand = new Command(()=> {

                Device.BeginInvokeOnMainThread(()=> {

                    ChatList.ScrollTo((this.BindingContext as MessageViewModel).LstMsgs.Last(),ScrollToPosition.End,true);
                });
            
            });
        }
    }
}