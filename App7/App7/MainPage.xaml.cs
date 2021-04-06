using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;


namespace App7
{
    public class Notes
    {
        public string Text { get; set; }
        public int Id { get; private set; }
        private static int globalId = 0;

        public Notes()
        {
            Id = ++globalId;
        }
    }

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {


        public ICommand TapCommand
        {
            get
            {
                return new Command<string>((x) => ExecuteAction(x));
            }
        }
        public void ExecuteAction(string x)
        {
            Console.WriteLine($"!{x}");
        }


        public MainPage()
        {
            InitializeComponent();
            BindableLayout.SetItemsSource(Col1, Instance.marks1);
            BindableLayout.SetItemsSource(Col2, Instance.marks2);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.IsEnabled = false;

            var form = new Page1();
            Navigation.PushAsync(form);
            form.Disappearing += (send, ev) =>
            {
                button.IsEnabled = true;
            };
        }
        private void Button_Col1_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.IsEnabled = false;

            var form = new ColorPage();
            Navigation.PushAsync(form);
            form.Disappearing += (send, ev) =>
            {
                button.IsEnabled = true;
                this.Resources["GradientColor1"] = (Color)form.Resources["ChoosenColor"];
                button.TextColor = new OppositeColor((Color)form.Resources["ChoosenColor"]).Color;
            };
        }
        private void Button_Col2_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.IsEnabled = false;

            var form = new ColorPage();
            Navigation.PushAsync(form);
            form.Disappearing += (send, ev) =>
            {
                button.IsEnabled = true;
                this.Resources["GradientColor2"] = (Color)form.Resources["ChoosenColor"];
                button.TextColor = new OppositeColor((Color)form.Resources["ChoosenColor"]).Color;
            };
        }

        private void Col1_SizeChanged(object sender, EventArgs e)
        {
            Instance.l1 = Col1.Height;
        }

        private void Col2_SizeChanged(object sender, EventArgs e)
        {
            Instance.l2 = Col2.Height;
        }
    }
}
