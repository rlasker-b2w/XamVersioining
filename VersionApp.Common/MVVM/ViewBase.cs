using System;
using System.Reflection;
using Xamarin.Forms;

namespace VersionApp.Common.MVVM
{
    public class ViewBase : ContentView
    {
        #region Constructors

        public ViewBase(IServiceLocator locator)
        {
            LoadViewModel(locator);
            Padding = 10;
        }

        #endregion

        #region Methods

        public void LoadViewModel(IServiceLocator locator)
        {
            locator = locator ?? ServiceLocator.GetLocator();

            //TODO: Triage | Add a more robust way to resolve vm type
            //It's a waste of memory to define these variable but otherwise this whole thing is very messy.
            //better to defer this to a type resolution service at some later date.
            Type typeName = GetType();
            string vmTypeName = $"{ typeName.Assembly.GetName().Name }.ViewModels.{ typeName.Name }Model";
            Type t = typeName.Assembly.GetType(vmTypeName);
            MethodInfo method = typeof(IServiceLocator).GetMethod(nameof(IServiceLocator.GetViewModel));
            MethodInfo generic = method.MakeGenericMethod(t);
            IViewModel vm = generic.Invoke(locator, null) as IViewModel;

            LayoutChanged += (s, e) => {
                vm.Page = FindParentPage(this);
                vm.Page.Appearing += vm.OnPageAppearing;
                vm.Page.Disappearing += vm.OnPageDisappearing;
                vm.Initialize();
            };

            BindingContext = vm;
            BindingContextChanged += (s, e) =>
            {
                if (BindingContext != vm)
                    BindingContext = vm;
            };
        }

        static Page FindParentPage(VisualElement element)
        {
            Page p = null;
            Element currentElement = element;
            while (p == null)
            {
                switch (currentElement.Parent)
                {
                    case null:
                        throw new Exception("Unable to find parent Page object");
                    case Page _p:
                        p = _p;
                        break;
                    default:
                        currentElement = currentElement.Parent;
                        break;
                }
            }
            return p;
        }

        #endregion
    }
}
