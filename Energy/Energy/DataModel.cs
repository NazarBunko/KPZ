using Energy.Serialization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Energy
{
    [DataContract]
    public class DataModel
    {
        [DataMember]
        public IEnumerable<User> Users { get; set; }
        [DataMember]
        public IEnumerable<Counter> Counters { get; set; }

        [DataMember]
        public IEnumerable<Report> Reports { get; set; }

        public DataModel()
        {
            Counters = new List<Counter>()
            {
                new Counter() { Name = "Residential Electric Meter", Description = "Electric meter for residential use", Count = 120, Status = MeterStatus.Enabled },
                new Counter() { Name = "Commercial Electric Meter", Description = "Electric meter for commercial buildings", Count = 250, Status = MeterStatus.Enabled },
                new Counter() { Name = "Industrial Electric Meter", Description = "High-capacity electric meter for industrial plants", Count = 500, Status = MeterStatus.Disabled }
            };

            Reports = new List<Report>
            {
                new Report { Name = "Monthly Report", Description = "Energy consumption for the month", Date = DateTime.Now.AddMonths(-1) },
                new Report { Name = "Quarterly Usage", Description = "Energy usage for the quarter", Date = DateTime.Now.AddMonths(-3) },
                new Report { Name = "Annual Summary", Description = "Energy consumption for the year", Date = DateTime.Now.AddYears(-1) }
            };

            Users = new List<User>
            {
                new User
                {
                    Name = "John Doe",
                    Description = "Residential user",
                    CounterNumber = "R2002"
                },
                new User
                {
                    Name = "Jane Smith",
                    Description = "Commercial user",
                    CounterNumber = "C4032"
                }
            };
        }


        public static string DataPath = "energy.dat";

        public static DataModel Load()
        {
            if (File.Exists(DataPath))
            {
                return DataSerializer.DeserializeItem(DataPath);
            }
            return new DataModel();
        }

        public void Save()
        {
            DataSerializer.SerializeData(DataPath, this);
        }
    }
}
