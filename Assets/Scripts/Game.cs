using UnityEngine;
using System.Collections;

public static class Game {
	/* Elecent contain information about player's points */
	public static Board Board;
	/* Size of board */
	public static int Width = 8;
	public static int Height = 8;

	public enum Player {None, White, Black};
	/* Current player */
	public static Player currentPlayer { get; private set; }

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

	public static void ChangePlayer () {
		currentPlayer = OppositePlayer(currentPlayer);
	}

	public static void Start () {
		currentPlayer = Player.White;
		Board = new Board(Width, Height);
	}
}
