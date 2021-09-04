﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NetScrape.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        ///     Event to notify the property change.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Notify the property change for the given property.
        /// </summary>
        /// <param name="propertyName">Changed property name</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
