﻿using QuanLiKhachSan.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLiKhachSan.View
{
    /// <summary>
    /// Interaction logic for LeTan_Layout.xaml
    /// </summary>
    public partial class LeTan_Layout : Window
    {
        public LeTan_Layout()
        {

            InitializeComponent();
            this.DataContext = new LeTanLayoutViewModel();
        }

    }
}
