using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace DemoConcurrentDictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel _viewModel;
        private ConcurrentDictionaryTest cdt;

        string SummaryData = "";

        public MainWindow()
        {
            InitializeComponent();
            cdt = new ConcurrentDictionaryTest();
            _viewModel = new ViewModel();
            DataContext = _viewModel;
            
            Task.Run(() => Loop());
        }

        private void Loop()
        {
            SummaryData = cdt.GetSummaryID.ToString();

            int counter = 1;
            while (true)
            {
                _viewModel.StringFromDictionary = cdt.GetRootID.ToString();
                string displayText = SummaryData + $" ({counter++})";
                _viewModel.StringFromSummary = displayText;
                Thread.Sleep(100);
            }
        }
    }
}
