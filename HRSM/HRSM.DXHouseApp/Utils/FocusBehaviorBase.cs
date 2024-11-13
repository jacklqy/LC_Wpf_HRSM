using DevExpress.Xpf.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace HRSM.DXHouseApp.Utils
{
        public class ComboBoxEditFocus : FocusBehaviorBase<ComboBoxEdit> { }
        public class TexEditFocus : FocusBehaviorBase<TextEdit> { }
        /// <summary>
        /// PasswordBoxEdit控件的焦点行为
        /// </summary>
        public class PasswordBoxFocus : FocusBehaviorBase<PasswordBoxEdit> { }
        public class FocusBehaviorBase<T> : Behavior<FrameworkElement> where T : Control
        {
                //定义一个附加属性IsFocused
                public static readonly DependencyProperty IsFocusedProperty = DependencyProperty.RegisterAttached(
                   "IsFocused", typeof(bool), typeof(FocusBehaviorBase<T>),
                   new PropertyMetadata(IsFocusedPropertyChanged));

                private static void IsFocusedPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
                {
                        var p = dependencyObject as T;
                        if (p == null) return;
                        if ((e.NewValue is bool ? (bool)e.NewValue : false))
                        {
                                p.Focus();
                        }
                }

                public static bool GetIsFocused(T p)
                {
                        return p.GetValue(IsFocusedProperty) is bool ? (bool)p.GetValue(IsFocusedProperty) : false;
                }

                public static void SetIsFocused(T p, bool value)
                {
                        p.SetValue(IsFocusedProperty, value);

                }
        }
     

}
