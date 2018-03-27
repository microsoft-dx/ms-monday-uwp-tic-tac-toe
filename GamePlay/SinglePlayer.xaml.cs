using TicTacToe.GameClasses;
using TicTacToe.PlayerClasses;
using TicTacToe.Screens;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TicTacToe.GamePlay
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SinglePlayer : Page
    {

        private SinglePlayerGame TicTacToe { get; set; }
        private HumanPlayer HumanPlayer { get; set; }
        private ComputerPlayer ComputerPlayer { get; set; }
        private string WinnerName { get; set; }
        private string HumanPlayerName { get; set; }
        private string defaultComputerPlayerName = "computer player";
        private string defaultHumanPlayerName = "human player";
        Gamers gamers;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gamers = (Gamers)e.Parameter;
            var humanPlayerName = gamers.XPlayerName;
            HumanPlayerName = humanPlayerName;
            Single.Background = gamers.BackgroundColor;
        }

        public SinglePlayer()
        {
            ComputerPlayer = new ComputerPlayer(defaultComputerPlayerName);
            HumanPlayer = new HumanPlayer(defaultHumanPlayerName);
            TicTacToe = new SinglePlayerGame(Single, HumanPlayer, ComputerPlayer);

            this.InitializeComponent();
        }


        private void UpdateGameStatus(object sender, TappedRoutedEventArgs e)
        {

            bool gameOver = false;

            if (HumanPlayer.Name == defaultHumanPlayerName)
                HumanPlayer.Name = HumanPlayerName;

            TicTacToe.UpdateStatus();

            if (AbstractClasses.Game.isWonByXPlayer)
            {
                TicTacToe.Restart();

                gamers.WinnerName = TicTacToe.HumanPlayer.Name;
                gamers.XPlayerName = TicTacToe.HumanPlayer.Name;
                gamers.LoserName = TicTacToe.ComputerPlayer.Name;
                gamers.OPlayerName = TicTacToe.ComputerPlayer.Name;

                gameOver = true;
            }

            else

           if (TicTacToe.IsOver() || AbstractClasses.Game.isWonBy0Player)
            {
                TicTacToe.Restart();

                gamers.WinnerName = TicTacToe.ComputerPlayer.Name;
                gamers.XPlayerName = TicTacToe.ComputerPlayer.Name;
                gamers.LoserName = TicTacToe.HumanPlayer.Name;
                gamers.OPlayerName = TicTacToe.HumanPlayer.Name;

                gameOver = true;
            }

            else
                TicTacToe.MakeMove(sender, e, Single);

            if (gameOver)
                Frame.Navigate(typeof(WinningScreen), gamers);

        }

    }
}
