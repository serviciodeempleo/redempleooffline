using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedEmpleoOffLine.Helpers;
using RedEmpleoOffLine.Model;
using RedEmpleoOffLine.View;
using System.Threading;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace RedEmpleoOffLine.ViewModel
{
    class ViewModelAgregarPersona : ViewModelMain
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

        private ICommand lostFocusCommand;

        public ICommand LostFocusCommand
        {
            get
            {
                if (lostFocusCommand == null)
                {
                    lostFocusCommand = new RelayCommand(param => this.LostTextBoxFocus(), null);
                }
                return lostFocusCommand;
            }
        }

        private void LostTextBoxFocus()
        {
            // do your implementation            
        }
        //This ViewModel is just to duplicate the last, but showing binding in code behind
        public ViewModelAgregarPersona()
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
            string Usuario = Thread.CurrentPrincipal.Identity.Name;
            var win = new MainWindow();
            win.Show();
            CloseWindow();
        }
    }
}
