using Newtonsoft.Json;
using System.Net.Http;
using System.Windows;

namespace ClientApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

        }

        private async void Button_Click_1(object sender, RoutedEventArgs e) {
            var client = new HttpClient();
            var url = "http://localhost:5000/developers/";
            var data = JsonConvert.SerializeObject(new {
                Name = "John",
                Message = this.msg.Text
            });
            var content = new StringContent(data);
            var res = await client.PostAsync(url, content);
            var str = await res.Content.ReadAsStringAsync();
            dynamic msg = JsonConvert.DeserializeObject(str);
            var sc = msg.StatusCode;
            var r = msg.Result;
            var op = msg.OperationTime;
            MessageBox.Show($"{sc} {r} {op}");
        }
    }
}
