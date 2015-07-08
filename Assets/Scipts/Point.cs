using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {
	public int xPos;
	public int yPos;
	public Sprite WhitePoint;
	public Sprite BlackPoint;
	public GameObject WinText;
	private bool active;

	// Use this for initialization
	void Start () {
		active = false;
	}

	void OnMouseDown(){
		if (!active) {
			active = true;
			SpriteRenderer trigger = GetComponent <SpriteRenderer> ();
			if (Map.currentPlayer == Map.Player.White)
				trigger.sprite = WhitePoint;
			else
				trigger.sprite = BlackPoint;

			Map.SetPoint (xPos, yPos);
		}
		if (Map.CheckWin(xPos, yPos))
			Application.LoadLevel (3);
	}

	// Update is called once per frame
	void Update () {
	}
}
