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
            InitializeComponent();
        }

        public Brush CellBackground {
            get { return Brushes.LightBlue; }
        }

        private int _Val;
        public int Val {
            get { return _Val; }
            set {
                _Val = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Background");
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
