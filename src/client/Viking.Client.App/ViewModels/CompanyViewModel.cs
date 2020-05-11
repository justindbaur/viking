using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Viking.Entities;

namespace Viking.Client.App.ViewModels
{
    public class CompanyViewModel : BindableBase
    {

        private string name;
        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }


    }
}
