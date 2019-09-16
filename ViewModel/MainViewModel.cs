using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfTaskProject.Classes;

namespace WpfTaskProject.ViewModel
{
    public class MainViewModel : ViewModelBase {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel() {
            if(IsInDesignMode) {
                WindowTitle = "Sample (Design)";
            }
            else {
                WindowTitle = "Sample";
                testFill();
            }
            personalInfoCollection.ToList().ForEach((field) => {
                field.PropertyChanged += (s, e) => {
                    ChangesMade = true;
                };
            });
        }

        public ICommand LoadedCommand { get; private set; }

        public void testCommand() {
            MessageBox.Show("Changed");
        }


        public void testFill() {
            personalInfoCollection = new ObservableCollection<PersonalInfo>();
            PersonalInfo test = new PersonalInfo();
            test.PhoneNumber = "535501994";
            test.FirstName = "Dawid";
            test.LastName = "Stachowiak";
            test.DateOfBirth = Convert.ToDateTime("28-07-1994");
            test.PropertyChanged += (s, e) => {
                //testCommand();
            };
            PersonalInfo test2 = new PersonalInfo();
            test2.PhoneNumber = "5355019945123";
            test2.FirstName = "Daw123id";
            test2.LastName = "Stacho123wiak";
            test2.DateOfBirth = Convert.ToDateTime("28-05-1994");
            test2.PropertyChanged += (s, e) => {
                //testCommand();
            };

            personalInfoCollection.Add(test);
            personalInfoCollection.Add(test2);
        }

        public void ChangeButtonEnable() {
            ChangesMade = true;
        }

        public bool ChangesMade { get; private set; }
        public string WindowTitle { get; private set; }
        public ObservableCollection<PersonalInfo> personalInfoCollection { get; set; }
    }
}