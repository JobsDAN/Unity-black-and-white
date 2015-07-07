using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {
	static public short player;
	static public int wField;
	static public int hField;
	static public int[,] map;

	public GameObject cell;

	void InitMap() {
		map = new int[wField, hField];
		for (int i = 0; i < wField; i++)
			for (int j = 0; j < hField; j++) 
				map [i, j] = 0;
	}
	void FillMap() {
		Renderer board = GetComponent <Renderer> ();
		float wBoard = (float)board.bounds.size.x;
		float hBoard = (float)board.bounds.size.y;
		float wCell = wBoard / wField;
		float hCell = hBoard / hField;
		float x0 = board.bounds.min.x;
		float y0 = board.bounds.min.y;
		for (int i = 0; i < wField; i++)
			for (int j = 0; j < hField; j++) {
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
		wField = 8;
		hField = 8;
		player = 1;
		InitMap ();
		FillMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
