using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace WpfYieldReturnApp
{
    public partial class MainWindow : Window
    {
        private NumberGenerator _numberGenerator;

        public MainWindow()
        {
            InitializeComponent();
            _numberGenerator = new NumberGenerator();
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            NumbersListBox.Items.Clear(); 

            if (int.TryParse(StartTextBox.Text, out int start) && int.TryParse(EndTextBox.Text, out int end))
            {
                await GenerateNumbersAsync(start, end);
                MessageBox.Show("Number generation complete!");
            }
            else
            {
                MessageBox.Show("Please enter valid integer values for start and end.");
            }
        }

        private async Task GenerateNumbersAsync(int start, int end)
        {
            await Task.Run(() =>
            {
                foreach (var number in _numberGenerator.GenerateNumbers(start, end))
                {
                    // Update the UI on the main thread
                    Dispatcher.Invoke(() => NumbersListBox.Items.Add(number));
                }
            });
        }
    }
}