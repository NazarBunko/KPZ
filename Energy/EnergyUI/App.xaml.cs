using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using Energy;
using EnergyUI.Base;
using EnergyUI.ViewModels;
using EnergyUI;

namespace EnergyUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private DataModel _model;
        private DataViewModel _viewModel;
        private IMapper _mapper;
        public App()
        {
            _mapper = new Mapping().RegisterMap();

            _model = DataModel.Load();
            _viewModel = _mapper.Map<DataModel, DataViewModel>(_model);
            var window = new MainWindow() { DataContext = _viewModel };
            window.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            try
            {
                _model = _mapper.Map<DataViewModel, DataModel>(_viewModel);
                _model.Save();
            }
            catch (Exception exception)
            {
                base.OnExit(e);
                throw;
            }
        }
    }
}
