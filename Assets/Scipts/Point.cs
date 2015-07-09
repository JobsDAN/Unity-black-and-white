using UnityEngine;
using UnityEngine.UI;
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
			Map.SetPoint(xPos, yPos);
		}

		Map.Player winner = Map.CheckWin (xPos, yPos);
		if (winner != Map.Player.None) {
			GameObject winTextObj = Instantiate (WinText);
			Transform tmp = winTextObj.transform.Find("Text");
			GameObject tmpObj = tmp.gameObject;
			Text winText = tmpObj.GetComponent<Text>();
			DontDestroyOnLoad (winTextObj);
			if (winner == Map.Player.Black)
				winText.text = "Черный победил";
			else
				winText.text = "Белый победил";
			Application.LoadLevel(3);
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
