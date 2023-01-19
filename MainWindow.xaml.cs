using System;
using System.Collections.Generic;
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

namespace Prog_122_W23_L4_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] firstNames = { "Will", "Hannah", "Anne" , "Will" };
        string[] lastNames = { "Cram", "Angel", "Nguyen", "Cram" };
        int[] grades = { 57, 101, 110, 57 };

        // Keyword List<T>
        // T = Generic
        List<string> firstNamesList = new List<string> { "Will", "Hannah", "Anne", "Will" };
        List<string> lastNamesList;
        List<int> gradesList;

        List<StackPanel> panels = new List<StackPanel>();

        string[] newFirstNames;
        public MainWindow()
        {
            InitializeComponent();
            lastNamesList = lastNames.ToList();
            gradesList = grades.ToList();

            panels.Add(spAddStudent);
            panels.Add(spInsert);
            panels.Add(spRemoveStudent);
            panels.Add(spRemoveAt);


            HidePanels();

            panels[0].Visibility = Visibility.Visible;

            DisplayFromList();
  
        } // MainWindow

        /// <summary>
        /// Hides all Panels
        /// </summary>
        public void HidePanels()
        {
            for (int i = 0; i < panels.Count; i++)
            {
                panels[i].Visibility = Visibility.Hidden;

            }
        } 

        public void DisplayFromList()
        {
            runDisplay.Text = "";

            for (int i = 0; i < firstNamesList.Count; i++)
            {

                FormatString(i);
                
            }
        }

        public void FormatString(int i)
        {
            //string fName = firstNamesList[i];
            //string lName = lastNamesList[i];
            //string grade = gradesList[i];


            runDisplay.Text += $"{i} - {firstNamesList[i]} {lastNamesList[i]} - {gradesList[i]} \n";
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            int grade = int.Parse(txtGrade.Text);

            // To add to a list

            firstNamesList.Add(fName);
            lastNamesList.Add(lName);
            gradesList.Add(grade);

            DisplayFromList();

        } // btnAddStudent_Click

        public void AnnoyingLargerArrayExample()
        {
            runDisplay.Text = firstNames.Length + "\n";

            newFirstNames = new string[firstNames.Length * 3];

            for (int i = 0; i < firstNames.Length; i++)
            {
                newFirstNames[i] = firstNames[i];
            }

            firstNames = newFirstNames;

            runDisplay.Text += firstNames.Length + "";
        }
        public void DisplayStudents()
        {

            runDisplay.Text = "";
            for (int i = 0; i < firstNames.Length; i++)
            {

                

                // First Name Last Name - Grade
                runDisplay.Text += $"{firstNames[i]} {lastNames[i]} - {grades[i]}\n";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            int grade = int.Parse(txtGrade.Text);
            int index = int.Parse(txtInsertAt.Text);

            // To add to a list

            firstNamesList.Insert(index, fName);
            lastNamesList.Insert(index, lName);
            gradesList.Insert(index, grade);

            DisplayFromList();
        }

        private void btnRemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            string fName = txtRemoveName.Text;

            //bool wasRemoved = firstNamesList.Remove(fName);
            

            while(firstNamesList.Contains(fName))
            {
                firstNamesList.Remove(fName);
            }


            //if (wasRemoved)
            //{
            //    MessageBox.Show(fName + " was removed from the list");
            //}
            //else
            //{
            //    MessageBox.Show("That name was not on the list");

            //}
            runDisplay.Text = "";
            foreach (string name in firstNamesList)
            {
                runDisplay.Text += name + "\n";
            }
        }

        private void btnRemoveAt_Click(object sender, RoutedEventArgs e)
        {
            int index = int.Parse(txtRemoveAt.Text);


            if(index < firstNamesList.Count)
            {
                firstNamesList.RemoveAt(index);
                lastNamesList.RemoveAt(index);
                gradesList.RemoveAt(index);
            }

  

            DisplayFromList();


        }

        private void btnRemovePanel_Click(object sender, RoutedEventArgs e)
        {
            HidePanels();
            panels[0].Visibility = Visibility.Visible;

        }

        private void btnRemoveAtPanel_Click(object sender, RoutedEventArgs e)
        {
            HidePanels();

            panels[1].Visibility = Visibility.Visible;
        }

        private void btnAddStudentPanel_Click(object sender, RoutedEventArgs e)
        {
            HidePanels();

            panels[2].Visibility = Visibility.Visible;

        }

        private void btnInsertPanel_Click(object sender, RoutedEventArgs e)
        {
            HidePanels();

            panels[3].Visibility = Visibility.Visible;

        }
    } // class

} // namespace
