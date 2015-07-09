using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	/* Object for fill board */
	public GameObject cell;
	/* I trust, that we delete this */
	public Sprite backSprite;
	/* Elecent contain information about player's points */
	public static Board Board;

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

	/* Create fild of cell */
	void FillMap() {
		float wBackSprite = (float)backSprite.bounds.size.x;
		float hBackSprite = (float)backSprite.bounds.size.y;
		float wCell = wBackSprite / Board.Width;
		float hCell = hBackSprite / Board.Height;
		float x0 = backSprite.bounds.min.x;
		float y0 = backSprite.bounds.min.y;
		for (int i = 0; i < Board.Width; i++)
			for (int j = 0; j < Board.Height; j++) {
				float x = i * wCell + wCell / 2; 
				float y = j * hCell + wCell / 2; 
				GameObject curCell = (GameObject)Instantiate (cell);
				curCell.transform.position = new Vector2 (x0 + x, y0 + y);
					
				var p = curCell.GetComponent <Point> ();
				p.x = i;
				p.y = j;
			}
	}

	void Start () {
		currentPlayer = Player.White;
		Board = new Board(8, 8);
		FillMap ();
	}
}
