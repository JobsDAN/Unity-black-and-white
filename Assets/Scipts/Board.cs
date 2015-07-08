using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
	public GameObject cell;

	void FillMap() {
		Renderer board = GetComponent <Renderer> ();
		float wBoard = (float)board.bounds.size.x;
		float hBoard = (float)board.bounds.size.y;
		float wCell = wBoard / Map.Width;
		float hCell = hBoard / Map.Height;
		float x0 = board.bounds.min.x;
		float y0 = board.bounds.min.y;
		for (int i = 0; i < Map.Width; i++)
			for (int j = 0; j < Map.Height; j++) {
				float x = i * wCell + wCell / 2;
				float y = j * hCell + hCell / 2;
				GameObject curCell = (GameObject)Instantiate (cell);
				curCell.transform.position = new Vector2 (x0 + x, y0 + y);
					
				var p = curCell.GetComponent <Point> ();
				p.xPos = i;
				p.yPos = j;
			}
	}
		// Use this for initialization
	void Start () {
		Map.Init(8, 8);
		FillMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
