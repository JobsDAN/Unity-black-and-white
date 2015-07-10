using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;


public class Options : MonoBehaviour {

	public InputField widthField;
	public InputField heightField;

	const int minWidth = 5;
	const int maxWidth = 18;
	const int minHeight = 5;
	const int maxHeight = 8;

	private int width;
	private int height;

	public void Back() {
		Application.LoadLevel(0);
	}

	public void SetWidth() {
		if (widthField.text == "") {
			Game.Width = 8;
			widthField.text = Game.Width.ToString ();
			return;
		}
		Game.Width = Int32.Parse(widthField.text);
		if (Game.Width < minWidth) {
			Game.Width = minWidth;
			widthField.text = minWidth.ToString ();
			return;
		}
		if (Game.Width > maxWidth) {
			Game.Width = maxWidth;
			widthField.text = maxWidth.ToString ();
		}
	}

	public void SetHeight() {
		if (heightField.text == "") {
			Game.Height = 8;
			heightField.text = Game.Height.ToString ();
			return;
		}
		Game.Height = Int32.Parse(heightField.text);
		if (Game.Height < minHeight) {
			Game.Height = minHeight;
			heightField.text = minHeight.ToString ();
			return;
		}
		if (Game.Height > maxHeight) {
			Game.Height = maxHeight;
			heightField.text = maxHeight.ToString ();
		}
	}

}
