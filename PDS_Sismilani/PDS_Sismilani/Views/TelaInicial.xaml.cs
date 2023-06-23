﻿using System;
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
using System.Windows.Shapes;

namespace PDS_Sismilani.Views
{
    /// <summary>
    /// Lógica interna para TelaInicial.xaml
    /// </summary>
    public partial class TelaInicial : Window
    {
        public TelaInicial()
        {
            InitializeComponent();
        }

        private void btListarFuncionario_Click(object sender, RoutedEventArgs e)
        {
            ListarFuncionario form = new ListarFuncionario();
            form.ShowDialog();
        }

        private void btListarEstoque_Click(object sender, RoutedEventArgs e)
        {
            ListarEstoque form = new ListarEstoque();
            form.ShowDialog();
        }
    }
}
