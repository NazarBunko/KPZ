using AutoMapper;
using Energy;
using EnergyUI.ViewModel;
using EnergyUI.ViewModels;
using System.Diagnostics.Metrics;

namespace EnergyUI.Base
{
    public class Mapping
    {
        public Mapper RegisterMap()
        {
            return new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataModel, DataViewModel>();
                cfg.CreateMap<DataViewModel, DataModel>();

                cfg.CreateMap<ReportViewModel, Report>();
                cfg.CreateMap<Report, ReportViewModel>();

                cfg.CreateMap<UserViewModel, User>();
                cfg.CreateMap<User, UserViewModel>();

                cfg.CreateMap<CounterViewModel, Counter>();
                cfg.CreateMap<Counter, CounterViewModel>();
            }));
        }
    }
}
