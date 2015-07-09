using System.Collections;

public class Board {
	//TODO: Change this constant on calculated value
	const int maxWidth = 18;
	const int maxHeight = 8;
	const int minWidth = 5;
	const int minHeight = 5;

	private Game.Player[,] map;

	/* Map size */
	public int Width { get; private set; }
	public int Height { get; private set; } 
	
	/* Set current player value on map.
	 * Parametres: x, y where must be placed player point
	 * Return: false if place busy, true if not.
	 */
	public bool SetPoint(int x, int y) {
		if (map [x, y] != Game.Player.None)
			return false;
		map[x, y] = Game.currentPlayer;
		Game.ChangePlayer();
		return true;
	}

	/* Set size and initialize map.
	 * Parameters: width and height of map
	 */
	public Board(int w, int h) {
		if (minWidth > w || w > maxWidth)
			w = minWidth;
		if (minHeight > h || h < minWidth)
			h = minHeight;
		Width = w;
		Height = h;
		map = new Game.Player[w, h]; // Default it's array of None
	}

	/* Check map on win (horizontal and vertical, main and sucond diagonal). 
	 * Parameters: x(column), y(row) for check. 
	 * Return: player-winner index. Or 0, if nobody won.
	 */
	public Game.Player CheckWin(int x, int y) {
		Game.Player player = map[x,y];
		if (CheckWinHorizontal(x,y) >= 5 || 
		    CheckWinVertical(x,y) >= 5 || 
		    CheckWinMainDiagonal(x,y) >= 5 ||
		    CheckWinSecDiagonal(x,y) >= 5)
			return player;
		return Game.Player.None;
	}

	/* Next 4 functions help check board on win situation */
	private int CheckWinHorizontal(int x, int y) {
		Game.Player player = map[x,y];
		int amount = 1;
		for (int i = x + 1; i < Width && map[i,y] == player; i++)
			amount++;
		for (int i = x - 1; i > 0 && map[i,y] == player; i--)
			amount++;
		return amount;
	}

	private int CheckWinVertical (int x, int y) {
		Game.Player player = map[x,y];
		int amount = 1;
		for (int i = y + 1; i < Height && map[x,i] == player; i++)
			amount++;
		for (int i = y - 1; i > 0 && map[x,i] == player; i--)
			amount++;
		return amount;
	}

	private int CheckWinMainDiagonal (int x, int y) {
		Game.Player player = map[x,y];
		int amount = 1;
		int i = x + 1;
		int j = y + 1;
		while (i < Width && j < Height && map[i++,j++] == player)
			amount++;

		i = x - 1;
		j = y - 1;
		while (i > 0 && j > 0 && map[i--,j--] == player)
			amount++;
		return amount;
	}

	private int CheckWinSecDiagonal (int x, int y) {
		Game.Player player = map[x,y];
		int amount = 1; 
		int i = x - 1;
		int j = y + 1;
		while (i > 0 && j < Height && map[i--,j++] == player)
			amount++;

		i = x + 1; 
		j = y - 1;
		while (i < Width && j > 0 && map[i++,j--] == player)
			amount++;
		return amount;
	}
}