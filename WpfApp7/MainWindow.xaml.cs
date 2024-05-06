using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp7
{
    public partial class MainWindow : Window
    {
        private List<string> AllItems = new List<string> { "Apple", "Banana", "Orange", "Carrot", "Broccoli" };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            IEnumerable<string> filteredItems = AllItems.Where(item => item.ToLower().Contains(searchText));

            if (filteredItems.Any())
            {
                SuggestionListBox.ItemsSource = filteredItems;
                SuggestionListBox.Visibility = Visibility.Visible;
            }
            else
            {
                SuggestionListBox.Visibility = Visibility.Collapsed;
            }
        }

        private void SuggestionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SuggestionListBox.SelectedItem != null)
            {
                string selectedText = SuggestionListBox.SelectedItem.ToString();
                // Burada seçilen öneriyi işleyebilirsiniz.
                MessageBox.Show("Selected item: " + selectedText);
            }
        }

    }
}