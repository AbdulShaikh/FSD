using System;

namespace SudokuSolver {
	class SudokuPuzzle {
		public static bool SolveSudoku (int[, ] puzzle, int row, int col) {
			if (row < 9 && col < 9) {
				if (puzzle[row, col] != 0) {
					if ((col + 1) < 9) {
						return SolveSudoku (puzzle, row, col + 1);
					} else {
						if ((row + 1) < 9) {
							return SolveSudoku (puzzle, row + 1, 0);
						} else {
							return true;
						}
					}
				} else {
					for (int number = 0; number < 9; ++number) {
						if (IsAvailable (puzzle, row, col, number + 1)) {
							puzzle[row, col] = number + 1;

							if ((col + 1) < 9) {
								if (SolveSudoku (puzzle, row, col + 1)) {
									return true;
								} else {
									puzzle[row, col] = 0;
								}
							} else {
								if ((row + 1) < 9) {
									if (SolveSudoku (puzzle, row + 1, 0)) {
										return true;
									} else {
										puzzle[row, col] = 0;
									}
								} else {
									return true;
								}
							}
						}
					}
				}

				return false;
			} else {
				return true;
			}
		}
		private static bool IsAvailable (int[, ] puzzle, int row, int col, int num) {
			int rowStart = (row / 3) * 3;
			int colStart = (col / 3) * 3;

			for (int number = 0; number < 9; ++number) {
				if (puzzle[row, number] == num) {
					return false;
				}
				if (puzzle[number, col] == num) {
					return false;
				}
				if (puzzle[rowStart + (number % 3), colStart + (number / 3)] == num) {
					return false;
				}
			}
			return true;
		}

	}
}