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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace TreeViewStepByStep
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

            var western = new Conference("Western")
            {
                Teams =
                {
                    new Team("Club Deportivo Chivas USA"),
                    new Team("Colorado Rapids"),
                    new Team("FC Dallas"),
                    new Team("Houston Dynamo"),
                    new Team("Los Angeles Galaxy"),
                    new Team("Real Salt Lake"),
                    new Team("San Jose Earthquakes"),
                    new Team("Seattle Sounders FC") { Players = { "Osvaldo Alonso", "Evan Brown" }},
                    new Team("Portland 2011"),
                    new Team("Vancouver 2011")
                }
            };

            var eastern = new Conference("Eastern")
            {
                Teams =
                {
                    new Team("Chicago Fire"),
                    new Team("Columbus Crew"),
                    new Team("D.C. United"),
                    new Team("Kansas City Wizards"),
                    new Team("New York Red Bulls"),
                    new Team("New England Revolution"),
                    new Team("Toronto FC"),
                    new Team("Philadelphia Union 2010")
                }
            };

            var league = new Collection<Conference>() { western, eastern };


            DataContext = new
            {
                WesternConference = western,
                EasternConference = eastern,
                League = league
            };
        }
    }

    public class Conference
    {
        public Conference(string name)
        {
            Name = name;
            Teams = new ObservableCollection<Team>();
        }

        public string Name { get; private set; }
        public ObservableCollection<Team> Teams { get; private set; }
    }

    public class Team
    {
        public Team(string name)
        {
            Name = name;
            Players = new ObservableCollection<string>();
        }

        public string Name { get; private set; }
        public ObservableCollection<string> Players { get; private set; }
    }


}
