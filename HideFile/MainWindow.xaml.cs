using System;
using System.Windows;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

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
                ImageName.Text = "secret_" + System.IO.Path.GetFileName(ofd.FileName);
                FolderPath.Text += System.IO.Path.GetDirectoryName(ofd.FileName);
                
                    
                    
            }
        }

        private void ValidationButton_Click(object sender, RoutedEventArgs e)
        {
            imagePath = ImagePath.Text;
            secretImagePath = FolderPath.Text + "\\" + ImageName.Text;
            zipPath = FilePath.Text;

            //Ecriture d'octets dans le fichier
            var bw = new BinaryWriter(File.Create(secretImagePath));
            bw.Write(File.ReadAllBytes(imagePath));
            bw.Write(File.ReadAllBytes(zipPath));
            bw.Close();

            if (LaunchFolderView(secretImagePath) == false)
                System.Windows.MessageBox.Show("erreur dans la création du fichier ");

        }

        private bool LaunchFolderView(string Filename)
        {
            bool result = false;

            // Check the file exists
            if (File.Exists(Filename))
            {
                // Check the folder we get from the file exists
                // this function would just get "C:\Hello" from
                // an input of "C:\Hello\World.txt"
                string folder = System.IO.Path.GetDirectoryName(Filename);

                // Check the folder exists
                if (Directory.Exists(folder))
                {
                    try
                    {
                        // Start a new process for explorer
                        // in this location     
                        ProcessStartInfo psi = new ProcessStartInfo();
                        psi.FileName = "explorer";
                        psi.Arguments = "/select," + Filename;
                        psi.UseShellExecute = true;

                        Process newProcess = new Process();
                        newProcess.StartInfo = psi;
                        newProcess.Start();

                        // No error
                        result = true;
                    }
                    catch (Exception exception)
                    {
                        throw new Exception("Error in 'LaunchFolderView'.", exception);
                    }
                }
            }

            return result;
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            new Aboutbox().ShowDialog();
        }

    }
}
