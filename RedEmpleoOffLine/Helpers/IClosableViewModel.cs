using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedEmpleoOffLine.Helpers
{
    interface IClosableViewModel
    {
        event EventHandler CloseWindowEvent;
    }
}
