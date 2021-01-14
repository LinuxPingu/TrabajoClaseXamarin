using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabajoClaseXamarin.ModelViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TrabajoClaseXamarin.Views.Partials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatInputBarView : ContentView
    {
        public ChatInputBarView()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.iOS)
            {
                this.SetBinding(HeightProperty, new Binding("Height",BindingMode.OneWay,null,null,null,chatTextInput));
            }
        }


        public void Handle_Completed(object sender,EventArgs e)
        {
            (this.Parent.BindingContext as MessageViewModel).SendTextCommand.Execute(null);
            chatTextInput.Focus();
            (this.Parent.Parent as ChatView).ScrollListCommand.Execute(null);
            chatTextInput.Text = "";
        }


    }
}