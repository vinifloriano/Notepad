using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace BlocoDeNotas
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICommand AbrirArquivo { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainText;
        }
        string FileName = "";
        private void SalvarArquivo()
        {
            if (FileName != "")
            {
                File.WriteAllText(FileName, MainText.Text);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    FileName = saveFileDialog.FileName;
                    File.WriteAllText(saveFileDialog.FileName, MainText.Text);
                }
            }
        }
        private void SalvarComo_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FileName = saveFileDialog.FileName;
                File.WriteAllText(saveFileDialog.FileName, MainText.Text);
            }
                
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            if(FileName != "")
            {
                File.WriteAllText(FileName, MainText.Text);
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (saveFileDialog.ShowDialog() == true)
                {
                    FileName = saveFileDialog.FileName;
                    File.WriteAllText(saveFileDialog.FileName, MainText.Text);
                }
            }
        }

        private void Abrir_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == true)
            {
                MainText.Text = File.ReadAllText(op.FileName);
                FileName = op.FileName;
            }
        }
    }
}
