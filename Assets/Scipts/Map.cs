using System.Collections;

public static class Map {
	//TODO: Change this constant on calculated value
	const int maxWidth = 18;
	const int maxHeight = 8;
	const int minWidth = 5;
	const int minHeight = 5;

	public enum Player {None, White, Black};
	private static Player[,] map;

	/* Map size */
	public static int Width { get; private set; }
	public static int Height { get; private set; } 

	/* Current player */
	public static Player currentPlayer { get; private set; }

	/* Set current player value on map.
	 * Parametres: x, y where must be placed player point
	 * Return: false if place busy, true if not.
	 */
	public static bool SetPoint(int x, int y) {
		if (map [x, y] != Player.None)
			return false;
		map [x, y] = currentPlayer;
		currentPlayer = OppositePlayer (currentPlayer);
		return true;
	}

	/* Get opposite player for p.
	 * Parametres: p -- player, for which we must find the opposite.
	 * Return: White -> Black, Black -> White, None -> None.
	 */
	private static Player OppositePlayer(Player p) {
		if (p == Player.None)
			return Player.None;
		if (p == Player.White)
			return Player.Black;
		return Player.White;
	}

	/* Set size and initialize map.
	 * Parameters: width and height of map
	 */
	public static void Init(int w, int h) {
		currentPlayer = Player.White;
		if (minWidth > w || w > maxWidth)
			w = minWidth;
		if (minHeight > h || h < minWidth)
			h = minHeight;
		Width = w;
		Height = h;
		map = new Player[w, h]; // Default it's array of None
	}

	/* Check map on win (horizontal and vertical, main and sucond diagonal). 
	 * Parameters: x(column), y(row) for check. 
	 * Return: player-winner index. Or 0, if nobody won.
	 */
	public static Player CheckWin(int x, int y) {
		Player player = map[x,y];
		if (CheckWinHorizontal(x,y) >= 5 || 
		    CheckWinVertical(x,y) >= 5 || 
		    CheckWinMainDiagonal(x,y) >= 5 ||
		    CheckWinSecDiagonal(x,y) >= 5)
			return player;
		return Player.None;
	}

	private static int CheckWinHorizontal(int x, int y) {
		Player player = map[x,y];
		int amount = 1;
		for (int i = x + 1; i < Width && map[i,y] == player; i++)
			amount++;
		for (int i = x - 1; i > 0 && map[i,y] == player; i--)
			amount++;
		return amount;
	}

	private static int CheckWinVertical (int x, int y) {
		Player player = map[x,y];
		int amount = 1;
		for (int i = y + 1; i < Height && map[x,i] == player; i++)
			amount++;
		for (int i = y - 1; i > 0 && map[x,i] == player; i--)
			amount++;
		return amount;
	}

	private static int CheckWinMainDiagonal (int x, int y) {
		Player player = map[x,y];
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

	private static int CheckWinSecDiagonal (int x, int y) {
		Player player = map[x,y];
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