using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour {

	public int xPos;
	public int yPos;
	public Sprite WhitePoint;
	public Sprite BlackPoint;
	public GameObject Win;
	private bool active;

	// Use this for initialization
	void Start () {
		active = false;

	}

	int CheckWinHorizontal(int player) {
		int amount = 1;
		for (int i = xPos + 1; i < Board.wField && Board.map[i,yPos] == player; i++)
			amount++;
		for (int i = xPos - 1; i > 0 && Board.map[i,yPos] == player; i--)
			amount++;
		return amount;
	}

	int CheckWinVertical (int player) {
		int amount = 1;
		for (int i = yPos + 1; i < Board.hField && Board.map[xPos,i] == player; i++)
			amount++;
		for (int i = yPos - 1; i > 0 && Board.map[xPos,i] == player; i--)
			amount++;
		return amount;
	}

	int CheckWinMainDiagonal (int player) {
		int amount = 1;
		int i = xPos + 1;
		int j = yPos + 1;
		while (i < Board.wField && j < Board.hField && Board.map[i,j] == player) {
			amount++;
			i++;
			j++;
		}

		i = xPos - 1;
		j = yPos - 1;
		while (i > 0 && j > 0 && Board.map[i,j] == player) {
			amount++;
			i--;
			j--;
		}
		return amount;
	}

	int CheckWinSecDiagonal (int player) {
		int amount = 1;
		int i = xPos - 1;
		int j = yPos + 1;
		while (i > 0 && j < Board.hField && Board.map[i,j] == player) {
			amount++;
			i--;
			j++;
		}

		i = xPos + 1;
		j = yPos - 1;
		while (i < Board.wField && j > 0 && Board.map[i,j] == player) {
			amount++;
			i++;
			j--;
		}
		return amount;
	}

	bool CheckWin() {

		int player = Board.map[xPos,yPos];
		if (CheckWinHorizontal(player) >= 5)
			return true;
		if (CheckWinVertical(player) >= 5)
			return true;
		if (CheckWinMainDiagonal(player) >= 5)
			return true;
		if (CheckWinSecDiagonal(player) >= 5)
			return true;
		return false;
	}

	void OnMouseDown(){
		if (!active) {
			active = true;
			SpriteRenderer trigger = GetComponent <SpriteRenderer> ();
			if (Board.player == 1) {
				trigger.sprite = WhitePoint;
				Board.map[xPos, yPos] = Board.player; 
				Board.player = 2;
			} else {
				trigger.sprite = BlackPoint;
				Board.map[xPos, yPos] = Board.player;
				Board.player = 1;
			}
		}

		if (CheckWin ())
			Application.LoadLevel (1);
	}

	// Update is called once per frame
	void Update () {
	}
}
