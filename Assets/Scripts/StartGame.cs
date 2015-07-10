using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {
	/* Size of camera with Size = 1*/
	private const float cameraWidth = 50.189f / 11f;
	private const float cameraHeight = 2f;
	public Camera camera;

	/* Object for fill board */
	public GameObject point;

	// Use this for initialization
	void Start () {
		Game.Start();
		FillMap ();
	}

	/* Create fild of cell */
	private void FillMap() {
		float cameraSize = camera.orthographicSize;
		float wCell = cameraWidth * cameraSize / Game.Board.Width;
		float hCell = cameraHeight * cameraSize / Game.Board.Height;
		float x0 = -cameraWidth * cameraSize / 2;
		float y0 = -cameraHeight * cameraSize / 2;
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
