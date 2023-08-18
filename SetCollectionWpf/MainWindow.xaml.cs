using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using SetCollectionLibrary;

namespace SetCollectionWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //set objects
        CustomSetCollection<string> namesByHobby = new CustomSetCollection<string>();
        CustomSetCollection<string> namesByGender = new CustomSetCollection<string>();
        CustomSetCollection<string> namesByUnion = new CustomSetCollection<string>();
        CustomSetCollection<string> namesByIntersection = new CustomSetCollection<string>();
        CustomSetCollection<string> namesByDifference = new CustomSetCollection<string>();
        CustomSetCollection<string> namesBySymmetricDifference = new CustomSetCollection<string>();

        //local variables to identify user choise
        static string currentHobby = string.Empty;
        static string currentGender = string.Empty;
        static string currentOperation = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            //add gender options to first dropdown list / male,female
            propGender.Items.Add("Male");
            propGender.Items.Add("Female");

            //add operations to second dropdown list
            cmbOperations.Items.Add("Union");
            cmbOperations.Items.Add("Intersection");
            cmbOperations.Items.Add("Difference");
            cmbOperations.Items.Add("SymmetricDifference");

            //add other options to third dropdown list - reading, driving, cooking
            propHobby.Items.Add("Reading");
            propHobby.Items.Add("Driving");
            propHobby.Items.Add("Cooking");

        }

        /// <summary>
        /// Handles event for gender option choice and prints respective names in ListBox.
        /// </summary>
        private void propGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //assign local variable of gender option
            string gender = propGender.SelectedValue.ToString();

            //if it matches the previous option, nothing will change
            if (gender.Equals(currentGender))
                return;
            //if user choice for 
            else
            {
                namesByGender.Clear();
                lst1.Items.Clear();
                foreach (var person in SampleData.Current.People)
                {
                    if (person.Gender == gender)
                    {
                        namesByGender.Add(person.Name);
                        lst1.Items.Add(person.Name);
                        currentGender = gender;
                    }
                }
            }
            lstEvalResult.Items.Clear();
        }

        private void cmbOperations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!currentOperation.Equals(cmbOperations.SelectedValue.ToString()))
            {
                currentOperation = cmbOperations.SelectedValue.ToString();
                namesByUnion.Clear();
                namesByIntersection.Clear();
                namesByDifference.Clear();
                namesBySymmetricDifference.Clear();
                
                lstEvalResult.Items.Clear();   
            }
        }

        private void propHobby_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string hobby = propHobby.SelectedValue.ToString();

            if (hobby.Equals(currentHobby))
                return;
            else
            {
                namesByHobby.Clear();
                lst2.Items.Clear();
                foreach (var person in SampleData.Current.People)
                {
                    if (person.Hobby == hobby)
                    {
                        namesByHobby.Add(person.Name);
                        lst2.Items.Add(person.Name);
                        currentHobby = hobby;
                    }
                }
            }
            lstEvalResult.Items.Clear();
        }

        private void btnEval_Click(object sender, RoutedEventArgs e)
        {
            lstEvalResult.Items.Clear();
            switch (currentOperation)
            {
                case "Union":
                    namesByUnion = namesByGender.Union(namesByHobby);
                    foreach (var item in namesByUnion)
                        lstEvalResult.Items.Add(item);
                    break;
                case "Intersection":
                    namesByIntersection = namesByGender.Intersection(namesByHobby);
                    foreach (var item in namesByIntersection)
                        lstEvalResult.Items.Add(item);
                    break;
                case "Difference":
                    namesByDifference = namesByGender.Difference(namesByHobby);
                    foreach(var item in namesByDifference)
                        lstEvalResult.Items.Add(item);
                    break;
                case "SymmetricDifference":
                    namesBySymmetricDifference = namesByGender.SymmetricDifference(namesByHobby);
                    foreach(var item in namesBySymmetricDifference)
                        lstEvalResult.Items.Add(item);
                    break;
                default:
                    break;
            }
        }
    }
}
