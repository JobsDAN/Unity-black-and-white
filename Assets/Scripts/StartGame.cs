using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	/* Object for fill board */
	public GameObject point;
	/* I trust, that we delete this */
	public Sprite backSprite;

	// Use this for initialization
	void Start () {
		Game.Start();
		FillMap ();
	}

	/* Create fild of cell */
	private void FillMap() {
		float wBackSprite = (float)backSprite.bounds.size.x;
		float hBackSprite = (float)backSprite.bounds.size.y;
		float wCell = wBackSprite / Game.Board.Width;
		float hCell = hBackSprite / Game.Board.Height;
		float x0 = backSprite.bounds.min.x;
		float y0 = backSprite.bounds.min.y;
		for (int i = 0; i < Game.Board.Width; i++)
			for (int j = 0; j < Game.Board.Height; j++) {
			float x = i * wCell + wCell / 2; 
			float y = j * hCell + hCell / 2; 
			GameObject curCell = (GameObject)Instantiate (point);
			curCell.transform.position = new Vector2 (x0 + x, y0 + y);

			var p = curCell.GetComponent <Point> ();
			p.x = i;
			p.y = j;
		}
	}

}
