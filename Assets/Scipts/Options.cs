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

	public void CheckWidth() {
		if (widthField.text == "")
			return;
		width = Int32.Parse(widthField.text);
		if (width < minWidth)
			widthField.text = minWidth.ToString();
		else if (width > maxWidth)
			widthField.text = maxWidth.ToString();
	}

	public void SetWidth() {
		if (widthField.text == "") {
			width = 8;
			widthField.text = width.ToString();
		}
	}

	public void CheckHeight() {
		if (heightField.text == "")
			return;
		height = Int32.Parse(heightField.text);
		if (height < minHeight)
			heightField.text = minHeight.ToString();
		else if (height > maxHeight)
			heightField.text = maxHeight.ToString();
	}
	
	public void SetHeight() {
		if (heightField.text == "") {
			height = 8;
			heightField.text = height.ToString();
		}
	}
}
