using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
namespace HideFile
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string imagePath;
        private string zipPath;
        private string secretImagePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileButton_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.FileName = "Image"; // Default file name
            ofd.DefaultExt = ".png"; // Default file extension
            ofd.Filter = "Fichiers compressés (*.zip)|*.zip|Tous les fichiers (*.*)|*.*"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = ofd.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                FilePath.Text = ofd.FileName;
            }
        }

        private void FolderButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.CommonPictures;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                FolderPath.Text = fbd.SelectedPath;

        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.FileName = "Image"; // Default file name
            ofd.DefaultExt = ".png"; // Default file extension
            ofd.Filter = "Images (*.png, *.jpg, *.jpeg, *.gif)|*.png; *.jpg; *.jpeg; *.gif|Tous les fichiers (*.*)|*.*"; // Filter files by extension
            ofd.Multiselect = false;
            ofd.Title = "Choisissez un fichier...";

            // Show open file dialog box
            Nullable<bool> result = ofd.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                ImagePath.Text = ofd.FileName;
                string[] filename = ofd.FileName.Split('\\');
                ImageName.Text = "secret_" + filename[filename.Length - 1] ;
                for (int i = 0; i < (filename.Length - 1); i++ )
                {
                    FolderPath.Text += filename[i] + "\\";
                }
                    
                    
            }
        }

        private void ValidationButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
