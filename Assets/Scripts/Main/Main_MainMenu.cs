using UnityEngine;
using System.Collections;

public class Main_MainMenu : MonoBehaviour
{
	
	public int selectedText = 0, numberOfTexts;
	
	public GameObject[] menu = new GameObject[2];

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		CheckInput();
		ResetAllColors();
		ColorSelected();
	}
	
	void CheckInput()
	{
		if (Input.GetKeyDown(KeyCode.DownArrow) ) ++selectedText;
		if (Input.GetKeyDown(KeyCode.UpArrow) ) --selectedText;
		
		selectedText += numberOfTexts;
		selectedText %= numberOfTexts;
		
		if (Input.GetKeyDown(KeyCode.Return) )
		{
			Debug.Log("selectedText: " + selectedText);
			if (selectedText == 0) Application.LoadLevel("Stage") ;
			else if (selectedText == 1) Application.Quit() ;
		}
	}
	
	void ResetAllColors()
	{
		for (int i = 0; i < numberOfTexts; i++)
		{
			menu[i].renderer.material.color = new Color(1.0f, 1.0f, 1.0f);
		}
	}
	
	void ColorSelected()
	{
			menu[selectedText].renderer.material.color = new Color(1.0f, 0.0f, 0.0f);
	}
}
