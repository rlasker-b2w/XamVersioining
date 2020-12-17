using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace VersionApp.Common.MVVM
{
    public abstract class ViewModelBase : LocatableBase, IViewModel
    {
        #region Constructors

        protected ViewModelBase(IServiceLocator locator) : base(locator)
        {
        }

        #endregion

        #region Properties

        protected bool IsInitialized { get; set; }

        public Page Page { get; set; }

        #endregion

        #region Methods

        public virtual void Initialize() { }

        public virtual void OnPageAppearing(object sender, EventArgs e)
        {
            if (!IsInitialized)
            {
                Initialize();
                IsInitialized = true;
            }
        }

        public virtual void OnPageDisappearing(object sender, EventArgs e)
        {
        }

        protected bool SetProperty<T>(
            ref T backingStore,
            T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion
    }
}
