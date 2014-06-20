using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for SingleCell.xaml
    /// </summary>
    public partial class SingleCell : UserControl, INotifyPropertyChanged {
        public SingleCell() {
            if (valToBrush == null) {
                valToBrush = new Dictionary<int, Brush>();
                this.add(0, "#776e65");
                this.add(2, "#eee4da");
                this.add(4, "#ede0c8");
                this.add(8, "#f2b179");
                this.add(16, "#f59563");
                this.add(32, "#f67c5f");
                this.add(64, "#f65e3b");
                this.add(128, "#edcf72");
                this.add(256, "#990303");
                this.add(512, "#6BA5DE");
                this.add(1024, "#DCAD60");
                this.add(2048, "#B60022");
            }
            InitializeComponent();
        }

        private void add(int i, string hex) {
            valToBrush[i] = new SolidColorBrush() {
                Color = ((Color)ColorConverter.ConvertFromString(hex))
            };
        }

        private static Dictionary<int, Brush> valToBrush = null;
        public Brush CellBackground {
            get {
                if (!valToBrush.ContainsKey(this.Val)) {
                    return Brushes.LightBlue;
                }
                return valToBrush[this.Val]; 
            }
        }

        public Brush CellForeground {
            get {
                Color c;
                if (this.Val == 0 || this.Val == 2 || this.Val == 4) {
                    c = (Color)ColorConverter.ConvertFromString("#776e65");
                } else {
                    c = (Color)ColorConverter.ConvertFromString("#f9f6f2");
                }
                return new SolidColorBrush() {
                    Color = c
                };
            }
        }

        private int _Val;
        public int Val {
            get { return _Val; }
            set {
                _Val = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("CellBackground");
                NotifyPropertyChanged("CellForeground");
            }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion INotifyPropertyChanged Implementation
    }
}
