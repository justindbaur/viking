using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viking.Client.App.ViewModels
{
    public class PurchaseOrderViewModel : BindableBase
    {

		private string poNum;

		public string PONum
		{
			get => poNum;
			set => Set(ref poNum, value);
		}
    }
}
