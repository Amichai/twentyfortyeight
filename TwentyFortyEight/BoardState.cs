using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFortyEight {
    public class BoardState {
        public BoardState() {
            this.init();
        }

        public string GetStateString() {
            string toReturn = string.Empty;
            for (int i = 0; i < s * s; i++) {
                var x = i % s;
                var y = i / s;
                toReturn += string.Format("{0},", this.state[x][y]);
            }
            return toReturn.Trim(',');
        }

        /// <summary>
        /// "x,y,val"
        /// </summary>
        public static BoardState Load(string stateString) {
            var toReturn = new BoardState();
            var vals = stateString.Split(',').Select(i => i.Trim()).Select(i => int.Parse(i)).ToList();
            for (int i = 0; i < vals.Count; i++) {
                var x = i % s;
                var y = i / s;
                toReturn.state[x][y] = vals[i];
            }
            return toReturn;
        }

        private int rowCount(int rowIdx) {
            int count = 0;
            for (int i = 0; i < s; i++) {
                if (this.state[i][rowIdx] != 0) {
                    count++;
                }
            }
            return count;
        }

        private int colCount(int colIdx) {
            int count = 0;
            for (int i = 0; i < s; i++) {
                if (this.state[colIdx][i] != 0) {
                    count++;
                }
            }
            return count;
        }

        public int[] this[int i] {
            get {
                return this.state[i];
            }
            set {
                this.state[i] = value;
            }
        }

        private bool press(ref int val1, ref int val2) {
            if (val1 == 0 && val2 == 0) {
                return false;
            }
            if (val1 == 0) {
                val1 = val2;
                val2 = 0;
                return true;
            }
            if (val1 == val2) {
                val1 = val1 + val2;
                val2 = 0;
                return false;
            }
            return false;
        }

        public void Left() {
            for (int rowIdx = 0; rowIdx < s; rowIdx++) {
                for (int x = 1; x < s; x++) {
                    for (int j = x; j >= 1; j--) {
                        var pressAgain = this.press(ref this[j - 1][rowIdx], ref this[j][rowIdx]);
                        if (!pressAgain) {
                            break;
                        }
                    }
                }
            }
        }

        public void Right() {
            for (int rowIdx = 0; rowIdx < s; rowIdx++) {
                for (int x = s - 1; x >= 0; x--) {
                    for (int j = x; j < s - 1; j++) {
                        var pressAgain = this.press(ref this[j + 1][rowIdx], ref this[j][rowIdx]);
                        if (!pressAgain) {
                            break;
                        }
                    }
                }
            }
        }

        public void Up() {
            throw new Exception();
        }

        public void Down() {
            throw new Exception();
        }

        private void init() {
            this.state = new int[s][];
            for (int i = 0; i < s; i++) {
                this.state[i] = new int[s];
            }
        }

        private const int s = 4;

        private int[][] state;
    }
}


