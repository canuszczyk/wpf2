using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var western = new Conference("WesternWesternWesternWesternWesternWesternWesternWesternWesternWestern")
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
                    new Team("Seattle Sounders FC") {Players = {new Player("Osvaldo Alonso"), new Player("Evan Brown")}},
                    new Team("Portland 2011"),
                    new Team("Vancouver 2011")
                }
            };

            var eastern = new Conference("EasternEastern")
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

            var league = new Collection<IConference>(); // { western, eastern };


            DataContext = new
            {
                WesternConference = western,
                EasternConference = eastern,
                League = league
            };

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // here
        }

    }

    public interface IConference
    {
        string Name { get; set; }
        ObservableCollection<Team> Teams { get; set; }
    }

    public class Conference : IConference
    {
        public Conference(string name)
        {
            Name = name;
            Teams = new ObservableCollection<Team>();
        }

        public string Name { get; set; }
        public ObservableCollection<Team> Teams { get; set; }
    }

    public interface ITeam
    {
        string Name { get; set; }
        ObservableCollection<IPlayer> Players { get; set; }
    }

    public interface IPlayer
    {
        string Name { get; }
    }

    public class Player : IPlayer
    {
        public string Name { get; set; }
        public Player(string name)
        {
            Name = name;
        }
    }

    public class Team : ITeam
    {
        public Team(string name)
        {
            Name = name;
            Players = new ObservableCollection<IPlayer>();
        }

        public string Name { get; set; }
        public ObservableCollection<IPlayer> Players { get; set; }
    }
}