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

        public bool PieceMoved {
            get;
            private set;
        }

        private bool press(ref int val1, ref int val2) {
            if (val1 == 0 && val2 == 0) {
                return false;
            }
            if (val1 == 0) {
                val1 = val2;
                val2 = 0;
                this.PieceMoved = true;
                return true;
            }
            if (val1 == val2) {
                val1 = val1 + val2;
                val2 = 0;
                this.PieceMoved = true;
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
            for (int colIdx = 0; colIdx < s; colIdx++) {
                for (int y = 1; y < s; y++) {
                    for (int j = y; j >= 1; j--) {
                        var pressAgain = this.press(ref this[colIdx][j - 1], ref this[colIdx][j]);
                        if (!pressAgain) {
                            break;
                        }
                    }
                }
            }
        }

        public void Down() {
            for (int colIdx = 0; colIdx < s; colIdx++) {
                for (int y = s - 1; y >= 0; y--) {
                    for (int j = y; j < s - 1; j++) {
                        var pressAgain = this.press(ref this[colIdx][j + 1], ref this[colIdx][j]);
                        if (!pressAgain) {
                            break;
                        }
                    }
                }
            }
        }

        public List<int> GetAllValues() {
            return Enumerable.Range(0, s * s).Select(i => this.getCell(i)).ToList();
        }

        public string FormattedBoardString() {
            string toReturn = string.Empty;
            for (int i = 0; i < s * s; i++) {
                var x = i % s;
                var y = i / s;
                if (i % 4 == 0) {
                    toReturn += "\n";
                }
                toReturn += string.Format("{0} ", this.state[x][y]);
            }
            return toReturn.Trim(',');
        }

        private void init() {
            this.state = new int[s][];
            for (int i = 0; i < s; i++) {
                this.state[i] = new int[s];
            }
        }

        private const int s = 4;

        private int[][] state;

        private void setCell(int idx, int val) {
            var x = idx % s;
            var y = idx / s;
            this[x][y] = val;
        }

        private int getCell(int idx) {
            var x = idx % s;
            var y = idx / s;
            return this[x][y];
        }

        private static Random rand = new Random();

        private List<int> openIndices() {
            List<int> toReturn = new List<int>();
            for (int i = 0; i < s * s; i++) {
                var val = this.getCell(i);
                if (val == 0) {
                    toReturn.Add(i);
                }
            }
            return toReturn;
        }

        internal void AddCell() {
            this.PieceMoved = false;
            int val = 2;
            if (rand.NextDouble() < .1) {
                val = 4;
            }
            var emptyCells = this.openIndices();
            if (emptyCells.Count() == 0) {
                throw new Exception("Game over!");
            }

            var idx = rand.Next(0, emptyCells.Count());
            var idxToSet = emptyCells[idx];
            this.setCell(idxToSet, val);
        }

        private bool canMoveHorizontally() {
            for (int idx = 0; idx < s * s; idx++) {
                var x = idx % s;
                var y = idx / s;
                if (x == 3) {
                    continue;
                }
                if (this[x][y] == this[x + 1][y]) {
                    return true;
                }
            }
            return false;
        }

        private bool canMoveVertically() {
            for (int idx = 0; idx < s * s; idx++) {
                var x = idx % s;
                var y = idx / s;
                if (y == 3) {
                    continue;
                }
                if (this[x][y] == this[x][y + 1]) {
                    return true;
                }
            }
            return false;
        }

        internal bool GameOver() {
            if (this.openIndices().Count() != 0) {
                return false;
            }
            if (canMoveHorizontally() || this.canMoveVertically()) {
                return false;
            }
            return true;
            ///For each pair of cells, asser that they are not the same
        }
    }
}


