using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedEmpeloOffLine.Helpers
{
    interface IClosableViewModel
    {
        event EventHandler CloseWindowEvent;
    }
}
