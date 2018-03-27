using TicTacToe.GameClasses;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TicTacToe.Screens
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WinningScreen : Page
    {
        public WinningScreen()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var gamers = (Gamers)e.Parameter;

            Screen.Background = gamers.BackgroundColor;

            if (gamers.WinnerName == "null" && gamers.LoserName == "null")
            {
                winner.Text = "We have no winner!";
                return;
            }

            if (gamers.isMultiPlayer == false)
            {
                if (gamers.WinnerName == gamers.OPlayerName )
                {
                    winner.Text = "You Lost";
                    return;
                }
                else
                {
                    winner.Text = "You Won!";
                    return;
                }
            }

            if (gamers.isMultiPlayer)
            {
                winner.Text = gamers.WinnerName + " won!\n" + gamers.LoserName + " lost!\n";
                return;
            }

        }

        private void GoToFirstScreen(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
