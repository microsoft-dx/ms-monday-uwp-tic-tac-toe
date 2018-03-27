using TicTacToe.GameClasses;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TicTacToe
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GameType typeOfGame = new GameType();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void StartSinglePlayerGame(object sender, TappedRoutedEventArgs e)
        {
            typeOfGame.isSinglePlayer = true;
            typeOfGame.isMultiPlayer = false;

            Frame.Navigate(typeof(Screens.UserData), typeOfGame);
        }

        private void StartMultiPlayerGame(object sender, TappedRoutedEventArgs e)
        {
            typeOfGame.isSinglePlayer = false;
            typeOfGame.isMultiPlayer = true;

            Frame.Navigate(typeof(Screens.UserData), typeOfGame);
        }
    }
}
