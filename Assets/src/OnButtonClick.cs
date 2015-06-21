using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[RequireComponent(typeof(Button))]
public class OnButtonClick : MonoBehaviour
{
	public KeyCode key;
	Button button;

	void Start ()
	{
		button = GetComponent<Button> ();
	}
	
	void Update ()
	{
		//Input.GetButtonDown ("Jump")
		if (Input.GetKeyDown (key) && button.onClick != null)
			button.onClick.Invoke ();
	}
}