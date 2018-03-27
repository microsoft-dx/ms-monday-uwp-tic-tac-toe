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
    public sealed partial class MultiPlayer : Page
    {
        private MultiPlayerGame TicTacToe { get; set; }
        private HumanPlayer XPlayer { get; set; }
        private HumanPlayer OPlayer { get; set; }
        Gamers gamers;
        private const string defaultName = "null";
        private const string defaultPlayer1Name = "Player 1";
        private const string defaultPlayer2Name = "Player 2";

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            gamers = (Gamers)e.Parameter;

            Multi.Background = gamers.BackgroundColor;
            gamers.isMultiPlayer = true;

        }


        public MultiPlayer()
        {
            XPlayer = new HumanPlayer(defaultPlayer1Name);
            OPlayer = new HumanPlayer(defaultPlayer2Name);
            TicTacToe = new MultiPlayerGame(XPlayer, OPlayer);

            this.InitializeComponent();
        }

        private void UpdateGameStatus(object sender, TappedRoutedEventArgs e)
        {

            if (TicTacToe.IsXTurn())
            {
                TicTacToe.InsertX(sender, e);
                CheckGameStatus();
            }

            else
                if (TicTacToe.Is0Turn())
            {
                TicTacToe.Insert0(sender, e);
                CheckGameStatus();
            }

        }

        private void CheckGameStatus()
        {
            TicTacToe.UpdateStatus();
            if (AbstractClasses.Game.isWonByXPlayer)
            {
                TicTacToe.Restart();

                gamers.WinnerName = gamers.XPlayerName;
                gamers.LoserName = gamers.OPlayerName;

                Frame.Navigate(typeof(WinningScreen), gamers);
            }
            else
           if (AbstractClasses.Game.isWonBy0Player)
            {
                TicTacToe.Restart();

                gamers.WinnerName = gamers.OPlayerName;
                gamers.LoserName = gamers.XPlayerName;

                Frame.Navigate(typeof(WinningScreen), gamers);
            }
            else
          if (TicTacToe.IsOver())
            {
                TicTacToe.Restart();

                gamers.WinnerName = defaultName;
                gamers.LoserName = defaultName;

                Frame.Navigate(typeof(WinningScreen), gamers);
            }
        }

        private bool Over()
        {
            if (TicTacToe.IsOver())
                return true;

            if (AbstractClasses.Game.isWonByXPlayer)
                return true;

            if (AbstractClasses.Game.isWonBy0Player)
                return true;

            return false;
        }
    }
}
