using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmApp.ViewModels
{
    public class BaseViewModel
    {
        public RootViewModel Parent { get; set; }

        public BaseViewModel(RootViewModel vm)
        {
            Parent = vm;
        }
    }
}
