using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Windows.Input;
using WpfTaskProject.Classes;

namespace WpfTaskProject.ViewModel
{
    public class MainViewModel : ViewModelBase {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel() {
            personalInfoCollection = new ObservableCollection<PersonalInfo>();
            if(IsInDesignMode) {
                WindowTitle = "Sample (Design)";
            }
            else {
                WindowTitle = "Sample";
                //testFill();
            }
            personalInfoCollection.ToList().ForEach((field) => {
                field.PropertyChanged += (s, e) => {
                    ChangesMade = true;
                };
            });
            personalInfoCollection.CollectionChanged += (s, e) => {
                ChangesMade = true;
                personalInfoCollection.ToList().ForEach((field) => {
                    field.PropertyChanged += (se, ee) => {
                        ChangesMade = true;
                    };
                });
            };
            loadCommand = new RelayCommand(loadedEvent);
            saveCommand = new RelayCommand(saveTable);
        }
        public ICommand loadCommand { get; set; }
        public ICommand saveCommand { get; set; }
       
        public void saveTable() {
            using(FileStream stream = new FileStream(dbPath, FileMode.Truncate)) {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<PersonalInfo>));
                serializer.Serialize(stream, personalInfoCollection);
                ChangesMade = false;
            }
        }

        public void loadedEvent() {
            dbPath = string.Format(@"C:\Users\{0}\database.xml", Environment.UserName);
            personalInfoCollection.Clear();
            if(File.Exists(dbPath)) {
                XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<PersonalInfo>));
                using(FileStream stream = new FileStream(dbPath, FileMode.Open)) {
                    try {
                        foreach(var x in (ObservableCollection<PersonalInfo>) serializer.Deserialize(stream)) {
                            personalInfoCollection.Add(x);
                        }
                    }
                    catch(InvalidOperationException ex) {
                    }
                }
            }
            else {
                File.Create(dbPath);
            }
            ChangesMade = false;
        }

        public string dbPath;

        public void testFill() {
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