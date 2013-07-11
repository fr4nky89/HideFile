using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HideFile
{
    /// <summary>
    /// Logique d'interaction pour Aboutbox.xaml
    /// </summary>
    public partial class Aboutbox : Window
    {
        public Aboutbox()
        {
            InitializeComponent();
            Assembly assem = Assembly.GetExecutingAssembly();
            AssemblyName assemName = assem.GetName();
            AppName.Text = assemName.Name;
            Version.Text = "Version: " + assemName.Version.Major + "." + assemName.Version.Minor;
            Author.Text = "Auteur: Fr4nky89";
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WebsiteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://mygeeknews.p.ht/");
            }
            catch {}
        }

    }
}
