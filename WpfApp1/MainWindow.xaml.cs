using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

//{"code":"3250547014115","product":{"_id":"3250547014115","_keywords":["sauce","et","forte","condiment","dijon","fine","point","vert","tv","moutarde","verre","epicerie","de","amora"],"abbreviated_product_name":"Amora mout.dij t.v 195g
////https://world.openfoodfacts.org/api/v0/product/3250547014115.json

namespace WpfApp1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _baseUrl = "https://world.openfoodfacts.org/api/v0/product/";
        private const long CODE_BARRE = 3250547014115;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void callOpenFood()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_baseUrl+CODE_BARRE+".json").Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;

                    // by calling .Result you are synchronously reading the result
                    string responseString = responseContent.ReadAsStringAsync().Result;
                    FoodProductDetails fpd = JsonConvert.DeserializeObject<FoodProductDetails>(responseString);
                    Console.WriteLine(responseString);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CallOpenFoodASynch();

        }

        private void CallOpenFoodASynch()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_baseUrl);
            //client.DefaultRequestHeaders.Add("appkey", "myapp_key");
            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(CODE_BARRE + ".json").Result;
            if (response.IsSuccessStatusCode)
            {
                FoodProductDetails ProductDetails = response.Content.ReadAsAsync<FoodProductDetails>().Result;
                //grdEmployee.ItemsSource = employees;
                //MainWindow.Mess("On a un retour");
                var t = response;
                var myList = new List<string>();

            }
            else
            {
                //MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

        private void MessageBox(string v)
        {
            throw new NotImplementedException();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            //Point GetMousePos() => _window.PointToScreen(Mouse.GetPosition(_window));
            Button button = sender as Button;
            button.Content = "Mouse Left";

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            //btn1.Content
            Button button = sender as Button;
            button.Content = "Mouse Entered";
        }
    }
}
