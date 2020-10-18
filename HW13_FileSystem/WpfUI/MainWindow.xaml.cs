using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace WpfUI
{
    /// <summary>
    ///     Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private static readonly OpenFileDialog OpenFileDialog = new OpenFileDialog();

        public MainWindow()
        {
            InitializeComponent();
            InitFileDialog();
        }

        private void InitFileDialog()
        {
            OpenFileDialog.Filter = "Text files(*.txt)|*.txt";
            OpenFileDialog.FileOk += _openFileDialog_FileOk;
        }

        private void _openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            ReadFile();
        }

        private async void ReadFile()
        {
            try
            {
                string result;
                using (var stream = new FileStream(OpenFileDialog.FileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        result = await reader.ReadToEndAsync();
                    }
                }

                txtBox.Text = result;
                txtBox.IsEnabled = true;
                txtBox.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK);
            }
        }

        private async void WriteFile()
        {
            txtBox.IsEnabled = false;
            try
            {
                using (var stream = new FileStream(OpenFileDialog.FileName, FileMode.Create))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        await writer.WriteAsync(txtBox.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK);
            }

            txtBox.IsEnabled = true;
        }

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog.ShowDialog();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            txtBox.IsEnabled = false;
            txtBox.Visibility = Visibility.Hidden;
            txtBox.Text = "";
            OpenFileDialog.Reset();
            InitFileDialog();
        }

        private void txtBox_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            BodyText.Visibility = txtBox.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(OpenFileDialog.FileName)) return;
            WriteFile();
        }
    }
}