using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfUsersApp
{
    public static class ViewModelLocator
    {
        private static bool IsInDesignerMode(DependencyObject d) => DesignerProperties.GetIsInDesignMode(d);

        public static bool GetAutoWireViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoWireViewModelProperty, value);
        }

        public static readonly DependencyProperty AutoWireViewModelProperty = DependencyProperty
                                                            .RegisterAttached("AutoWireViewModel",
                                                                                typeof(bool),
                                                                                typeof(ViewModelLocator),
                                                                                new PropertyMetadata(false, AutoWireViewChanged));

        private static void AutoWireViewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (IsInDesignerMode(d)) return;

            string viewModelTypeName = $"{d.GetType().FullName}Model";
            Type viewModelType = Type.GetType(viewModelTypeName);

            var viewModel = Activator.CreateInstance(viewModelType);
            ((FrameworkElement)d).DataContext = viewModel;
        }
    }
}
