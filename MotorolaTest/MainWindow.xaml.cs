using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace MotorolaTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindowViewModel)DataContext).SelectionMode = SelectMode.Normal;
            ((MainWindowViewModel)DataContext).ListCollection.Add(new Model(false, ""));
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveBlankItems();
            ((MainWindowViewModel)DataContext).SelectionMode = SelectMode.Edit;
        }

        private void MultiSelButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveBlankItems();
            ((MainWindowViewModel)DataContext).SelectionMode = SelectMode.MultiSelect;
        }

        private void ItemLB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Model> selectionList = new List<Model>();
            if (sender is ListBox)
            {
                ListBox lb = sender as ListBox;
                foreach(Model mod in lb.SelectedItems)
                {
                    selectionList.Add(mod);
                }
                ((MainWindowViewModel)DataContext).Selections = selectionList;
            }
        }

        private void ListBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is ListBox)
            {
                RemoveBlankItems();
            }
        }

        private void ListBoxTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox)
            {
                RemoveBlankItems();
            }
        }

        private void RemoveBlankItems()
        {
            Model mod = new Model(true, "");
            ((MainWindowViewModel)DataContext).ListCollection?.Remove(mod);
        }
    }
}
