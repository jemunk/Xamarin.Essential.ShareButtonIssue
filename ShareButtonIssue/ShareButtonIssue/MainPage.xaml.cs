using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShareButtonIssue
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            EnableShareAction();
        }


        private void EnableShareAction()
        {
            var downloadToolbarItem = new ToolbarItem();
            downloadToolbarItem.IconImageSource = "share_apple_white";
            downloadToolbarItem.Text = "Share";
            downloadToolbarItem.Clicked += async (object sender, EventArgs e) =>
            {
                await ShareFile();
            };

            ToolbarItems.Add(downloadToolbarItem);
        }

        private static async Task ShareFile()
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = Path.Combine(path, "TestPDF.pdf");
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Pdf file",
                File = new ShareFile(file)
            });
        }
    }
}
