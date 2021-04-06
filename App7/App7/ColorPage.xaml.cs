using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorPage : ContentPage
    {

        private Color GetColorByName(string name, int transparency = 0)
        {
            foreach (NamedColor item in NamedColor.All)
                if (item.Name == ColorPicker.Items[ColorPicker.SelectedIndex])
                    return item.Color;
            return Color.Transparent;
        }

        Dictionary<string, Slider> sliders;
        public ColorPage()
        {
            InitializeComponent();
            sliders = new Dictionary<string, Slider>();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (sliders.Count == 0)
            {
                this.Resources["ChoosenColor"] = Color.Blue;
                sliders.Add("A", this.ColorA);
                sliders.Add("R", this.ColorR);
                sliders.Add("G", this.ColorG);
                sliders.Add("B", this.ColorB);
                Color CurCol = (Color)Resources["ChoosenColor"];
                sliders["R"].Value = CurCol.R * 255;
                sliders["G"].Value = CurCol.G * 255;
                sliders["B"].Value = CurCol.B * 255;
                sliders["A"].Value = CurCol.A * 255;
                foreach (var item in NamedColor.All)
                {
                    ColorPicker.Items.Add(item.Name);
                }
                ColorPicker.SelectedIndex = 0;
                ColorPicker.BackgroundColor = GetColorByName(ColorPicker.Items[ColorPicker.SelectedIndex]);
                ColorPicker.SelectedIndexChanged += picker_SelectedIndexChanged;
            }
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Color selectedColor = GetColorByName(ColorPicker.Items[ColorPicker.SelectedIndex]);
            ColorPicker.BackgroundColor = selectedColor;
            sliders["A"].Value = selectedColor.A * 255;
            sliders["R"].Value = selectedColor.R * 255;
            sliders["G"].Value = selectedColor.G * 255;
            sliders["B"].Value = selectedColor.B * 255;
        }
        private void Button_Accept_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void UpdateColors()
        {
            this.Resources["ChoosenColor"] = Color.FromRgba(
                (int)sliders["R"].Value,
                (int)sliders["G"].Value,
                (int)sliders["B"].Value,
                (int)sliders["A"].Value);
            this.Resources["OpositeColor"] = new OppositeColor((Color)(this.Resources["ChoosenColor"])).Color;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            UpdateColors();
        }
        private void Button_ShowAll_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.IsEnabled = false;

            var form = new AllColorsPage();
            Navigation.PushAsync(form);
            form.Disappearing += (send, ev) =>
            {
                button.IsEnabled = true;
            };
        }

    }
}