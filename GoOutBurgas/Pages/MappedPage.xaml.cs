using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoOutBurgas.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MappedPage : TabbedPage
    {
        public MappedPage()
        {
            global::Microsoft.Maui.Controls.Xaml.Extensions.LoadFromXaml(this, typeof(MappedPage));
            //InitializeComponent();
        }
    }
}