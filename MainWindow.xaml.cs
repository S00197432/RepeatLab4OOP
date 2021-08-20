using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RepeatLab4OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Activity> Activities = new ObservableCollection<Activity>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var date1 = new DateTime(2021, 02, 02);
            var date2 = new DateTime(2021, 03, 15);
            var date3 = new DateTime(2021, 07, 09);
            var date4 = new DateTime(2021, 05, 10);

            Activity ACT1 = new Activity("Kayaking", date1, 10, "Paddling in a kayak", TypeOfActivity.Water);
            Activity ACT2 = new Activity("Parachuting", date2, 50, "Jump out of a plane", TypeOfActivity.Air);
            Activity ACT3 = new Activity("Mountain Biking", date3, 60, "Cycle around a mountain", TypeOfActivity.Land);
            Activity ACT4 = new Activity("Sailing", date4, 1, "like kayaking except bigger and with a sail", TypeOfActivity.Water);

            Activities.Add(ACT1);
            Activities.Add(ACT2);
            Activities.Add(ACT3);
            Activities.Add(ACT4);


            LBX_AllActivities.ItemsSource = Activities.OrderByDescending(DateTime => Guid.NewGuid()).ToList();

        }

        private void LBX_AllActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Activity SelectedAct = LBX_AllActivities.SelectedItem as Activity;
            if(SelectedAct == LBX_AllActivities.SelectedItem)
            {
                TXTBX_Description.Text = SelectedAct.Description;
                TXTBX_TotalCost.Text = SelectedAct.Cost.ToString();
            }
        }
    }
}
