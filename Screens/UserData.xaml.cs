using TicTacToe.GameClasses;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TicTacToe.Screens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserData : Page
    {
        const string defaultName = "human player";
        const string defaultComputerPlayerName = "computer player";

        Gamers gamers = new Gamers();
        GameType typeOfGame;

        public UserData()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            typeOfGame = (GameType)e.Parameter;

            if (typeOfGame.isMultiPlayer)
                CreateMultiPlayerEnviroment();

            gamers.BackgroundColor = new SolidColorBrush(Colors.LightSkyBlue);
        }

        private void StartTheGame(object sender, TappedRoutedEventArgs e)
        {
            var nextPage = typeOfGame.isMultiPlayer ?
                typeof(GamePlay.MultiPlayer) : typeof(GamePlay.SinglePlayer);

            gamers.XPlayerName = user1NameInput.Text;
            gamers.OPlayerName = user2NameInput.Text;

            Frame.Navigate(nextPage, gamers);
        }

        private void CreateMultiPlayerEnviroment()
        {
            user2NameInput.Visibility = Visibility.Visible;
            textBoxForPlayer2.Visibility = Visibility.Visible;

        }

        private void GoBack(object sender, TappedRoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void SelectCoral(object sender, TappedRoutedEventArgs e)
        {
            Board.Background = new SolidColorBrush(Colors.Coral);
            gamers.BackgroundColor = Board.Background;
        }

        private void SelectViolet(object sender, TappedRoutedEventArgs e)
        {
            Board.Background = new SolidColorBrush(Colors.Violet);
            gamers.BackgroundColor = Board.Background;
        }

        private void SelectGreen(object sender, TappedRoutedEventArgs e)
        {
            Board.Background = new SolidColorBrush(Colors.Green);
            gamers.BackgroundColor = Board.Background;
        }
    }
}
