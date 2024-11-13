using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;


namespace HRSM.DXHouseApp.CRM
{
        /// <summary>
        /// Interaction logic for CustomerFollowUpLogInfoWindow.xaml
        /// </summary>
        public partial class CustomerFollowUpLogInfoWindow : ThemedWindow
        {
                public CustomerFollowUpLogInfoWindow()
                {
                        InitializeComponent();
                }

                private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
                {
                        this.DragMove();
                }
        }
}
