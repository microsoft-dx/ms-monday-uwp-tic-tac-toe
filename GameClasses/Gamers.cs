using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace TicTacToe.GameClasses
{
    class Gamers
    {
        public bool isMultiPlayer { get; set; }

        public string XPlayerName { get; set; }
        public string OPlayerName { get; set; }

        public string WinnerName { get; set; }
        public string LoserName { get; set; }

        public Brush BackgroundColor { get; internal set; }
    }
}
