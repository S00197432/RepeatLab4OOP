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
       public List<Activity> Activities = new List<Activity>();
        public ObservableCollection<Activity> SelectedActivities = new ObservableCollection<Activity>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TXTBX_DateConflict.Visibility = Visibility.Hidden;
            TXTBX_NoSelect.Visibility = Visibility.Hidden;

            var date1 = new DateTime(2021, 02, 02);
            var date2 = new DateTime(2021, 02, 02);
            var date3 = new DateTime(2021, 07, 09);
            var date4 = new DateTime(2021, 05, 10);

            Activity ACT1 = new Activity("Kayaking", date1, 10, "Paddling in a kayak", TypeOfActivity.Water);
            Activity ACT2 = new Activity("Parachuting", date2, 20, "Jump out of a plane", TypeOfActivity.Air);
            Activity ACT3 = new Activity("Mountain Biking", date3, 30, "Cycle around a mountain", TypeOfActivity.Land);
            Activity ACT4 = new Activity("Sailing", date4, 40, "like kayaking except bigger and with a sail", TypeOfActivity.Water);

            Activities.Add(ACT1);
            Activities.Add(ACT2);
            Activities.Add(ACT3);
            Activities.Add(ACT4);


            LBX_AllActivities.ItemsSource = Activities.OrderByDescending(DateTime => Guid.NewGuid()).ToList();
            LBX_SelectedActivities.ItemsSource = SelectedActivities;
        }
        //displaying the details of the selected activity
        private void LBX_AllActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {            
            Activity SelectedAct = LBX_AllActivities.SelectedItem as Activity;
            if(SelectedAct != null)
            {
                TXTBX_Description.Text = SelectedAct.Description;
                
            }
            
        }
        //adding the seleceted activity from the all activities list box to the selected list box
        private void BTN_AddActivity_Click(object sender, RoutedEventArgs e)
        {

            Activity SelectedAct = LBX_AllActivities.SelectedItem as Activity;
            if (SelectedAct != null)
            {
                SelectedActivities.Add(SelectedAct);

                Activities.Remove(SelectedAct);
                LBX_AllActivities.ItemsSource = Activities;
                
                TXTBX_NoSelect.Visibility = Visibility.Hidden;
            }
            else if (SelectedAct == null)
            {
                //if nothing is selected when the add button is clicked changes the visibility of the error message to visible
                TXTBX_NoSelect.Visibility = Visibility.Visible;

            }
            
        }
        //removes the selected activity from the selected activities list box and adds it back to the all activities list box
        private void BTN_RemoveActivity_Click(object sender, RoutedEventArgs e)
        {
            Activity SelectedAct = LBX_SelectedActivities.SelectedItem as Activity;
            if (SelectedAct != null)
            {
                SelectedActivities.Remove(SelectedAct);
                Activities.Add(SelectedAct);
               
                LBX_AllActivities.ItemsSource = Activities;
                LBX_SelectedActivities.ItemsSource = SelectedActivities;
                TXTBX_NoSelect.Visibility = Visibility.Hidden;
            }
            else if (SelectedAct == null)
            {
                //if nothing is selected when the remove button is clicked changes the visibility of the error message to visible
                TXTBX_NoSelect.Visibility = Visibility.Visible;

            }
        }

        private void RADBTN_All_Checked(object sender, RoutedEventArgs e)
        {  
            LBX_AllActivities.ItemsSource = Activities;
        }
        //only shows items that contain Land as their type
        private void RADBTN_Land_Checked(object sender, RoutedEventArgs e)
        {
            LBX_AllActivities.ItemsSource = Activities.FindAll((item => item.typeOfActivity == TypeOfActivity.Land));
        }

        private void TXTBX_TotalCost_MouseEnter(object sender, MouseEventArgs e)
        {
            decimal TCost;
            var first = SelectedActivities.First<Activity>();
            if (SelectedActivities != null)
            {
                TCost = first.Cost;
                TXTBX_TotalCost.Text = TCost.ToString();
                if (SelectedActivities.Count > 1)
                {
                    SelectedActivities.Move(0, 1);
                    var second = SelectedActivities.First<Activity>();
                    TCost += second.Cost;
                    TXTBX_TotalCost.Text = TCost.ToString();

                    if (SelectedActivities.Count > 2)
                    {
                        SelectedActivities.Move(0, 2);
                        SelectedActivities.Move(0, 1);
                        var third = SelectedActivities.First<Activity>();
                        TCost += third.Cost;
                        TXTBX_TotalCost.Text = TCost.ToString();

                        if (SelectedActivities.Count > 3)
                        {
                            SelectedActivities.Move(0, 3);
                            SelectedActivities.Move(0, 2);
                            SelectedActivities.Move(0, 1);
                            var fourth = SelectedActivities.First<Activity>();
                            TCost += fourth.Cost;
                            TXTBX_TotalCost.Text = TCost.ToString();

                        }
                    }
                }
            }
            
             
            
        }
        //only shows items that contain water as their type
        private void RADBTN_Water_Checked(object sender, RoutedEventArgs e)
        {

            LBX_AllActivities.ItemsSource = Activities.FindAll((item => item.typeOfActivity == TypeOfActivity.Water));
        }
        //only shows items that contain Air as their type
        private void RADBTN_Air_Checked(object sender, RoutedEventArgs e)
        {
            LBX_AllActivities.ItemsSource = Activities.FindAll((item => item.typeOfActivity == TypeOfActivity.Air));
        }
    }
}
