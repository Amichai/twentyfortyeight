using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TwentyFortyEight {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.board = new BoardState();
            this.board.AddCell();
            this.board.AddCell();
            this.print();   
        }

        private void print() {
            //Debug.Print(this.board.FormattedBoardString() + "\n\n");
            this.root.Children.Clear();
            var vals = this.board.GetAllValues();
            for (int i = 0; i < vals.Count(); i++)
			{
                var x = i % 4;
                var y = i / 4;
                var cell = new SingleCell() { Val = vals[i] };
                this.root.Children.Add(cell);
                Grid.SetColumn(cell, x);
                Grid.SetRow(cell, y);

            }
        }

        public BoardState board { get; set; }

        private void Window_PreviewKeyDown_1(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Up:
                    this.board.Up();
                    break;
                case Key.Down:
                    this.board.Down();
                    break;
                case Key.Left:
                    this.board.Left();
                    break;
                case Key.Right:
                    this.board.Right();
                    break;
            }

            if (this.board.PieceMoved) {
                this.board.AddCell();
                this.print();
            }

            if (this.board.GameOver()) {
                this.Background = Brushes.Black;
                Debug.Print("GAME OVER!");
            }
        }
    }
}
