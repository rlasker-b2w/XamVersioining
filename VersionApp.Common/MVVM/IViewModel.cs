using System;
using Xamarin.Forms;

namespace VersionApp.Common.MVVM
{
    public interface IViewModel
    {
        Page Page { get; set; }

        void Initialize();

        void OnPageAppearing(object sender, EventArgs e);

        void OnPageDisappearing(object sender, EventArgs e);
    }
}
