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
using System.Linq;
using System.IO;
using Microsoft.Win32;
using TKIW_RunBuilder.Models;
using TKIW_RunBuilder.ViewModels;

namespace TKIW_RunBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel();
            InitializeComponent();
            
        }

        private void ComboBox_DropDownClosed(object sender, System.EventArgs e)
        {
            // Commit edit after the dropdown closes so the user can still interact with the popup
            if (sender is ComboBox cb)
            {
                var dg = FindParent<DataGrid>(cb);
                if (dg != null && !dg.IsReadOnly)
                {
                    dg.CommitEdit(DataGridEditingUnit.Cell, true);
                    dg.CommitEdit(DataGridEditingUnit.Row, true);
                }
            }
        }

        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            var parent = System.Windows.Media.VisualTreeHelper.GetParent(child);
            while (parent != null)
            {
                if (parent is T typed)
                    return typed;
                parent = System.Windows.Media.VisualTreeHelper.GetParent(parent);
            }
            return null;
        }

        private void Preset_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                e.NewItem = vm.CreateNewPreset();
            }
        }

        private void Template_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                e.NewItem = vm.CreateNewTemplate();
            }
        }

        private void ExportFlagData_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                var (exported, error) = vm.ExportTemplate();
                if (!exported)
                {
                    if (error != null)
                        MessageBox.Show($"Export failed: {error}", "Export Flag Data", MessageBoxButton.OK, MessageBoxImage.Error);
                    // else user cancelled - do nothing
                }
                else
                {
                    MessageBox.Show("Export completed.", "Export Flag Data", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ExportUnitData_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                var (exported, error) = vm.ExportUnit();
                if (!exported)
                {
                    if (error != null)
                        MessageBox.Show($"Export failed: {error}", "Export Flag Data", MessageBoxButton.OK, MessageBoxImage.Error);
                    // else user cancelled - do nothing
                }
                else
                {
                    MessageBox.Show("Export completed.", "Export Flag Data", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ImportFlagData_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                var (count, error) = vm.TemplateImport();
                if (error != null)
                {
                    MessageBox.Show($"Import failed: {error}", "Import Flag Data", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (count == 0)
                {
                    // user cancelled or file empty
                }
                else
                {
                    MessageBox.Show($"Imported {count} templates.", "Import Flag Data", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ImportUnitData_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is MainWindowViewModel vm)
            {
                var (count, error) = vm.UnitImport();
                if (error != null)
                {
                    MessageBox.Show($"Import failed: {error}", "Import Flag Data", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else if (count == 0)
                {
                    // user cancelled or file empty
                }
                else
                {
                    MessageBox.Show($"Imported {count} templates.", "Import Flag Data", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        
    }
}