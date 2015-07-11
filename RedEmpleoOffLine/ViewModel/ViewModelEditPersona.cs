using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedEmpleoOffLine.Helpers;
using RedEmpleoOffLine.Model;
using RedEmpleoOffLine.View;

namespace RedEmpleoOffLine.ViewModel
{
    class ViewModelEditPersona : ViewModelMain
    {
        public RelayCommand ChangeTextCommand { get; set; }
        public RelayCommand NextExampleCommand { get; set; }

        string _TestText;
        public string TestText
        {
            get
            {
                return _TestText;
            }
            set
            {
                if (_TestText != value)
                {
                    _TestText = value;
                    RaisePropertyChanged("TestText");
                }
            }
        }

        //This ViewModel is just to duplicate the last, but showing binding in code behind
        public ViewModelEditPersona(string Identificacion )
        {
            NextExampleCommand = new RelayCommand(NextExample);
        }

        void ChangeText(object selectedItem)
        {
            //Setting the PUBLIC property 'TestText', so PropertyChanged event is fired
            if (selectedItem == null)
                TestText = "Please select a person";
            else
            {
                var person = selectedItem as Person;
                TestText = person.PrimerNombre + " " + person.PrimerApellido;
            }
        }

        void NextExample(object parameter)
        {
            var win = new MainWindow();
            win.Show();
            CloseWindow();
        }
    }
}
