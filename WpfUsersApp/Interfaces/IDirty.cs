using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfUsersApp.Interfaces
{
    public interface IDirty
    {
        void PropertyDirty(object sender, PropertyChangedEventArgs e);
    }
}
