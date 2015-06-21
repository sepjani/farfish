using UnityEngine;
#if UNITY_EDITOR   
using UnityEditor;
#endif
using System.Collections;

public class PauseManager : MonoBehaviour
{
	public GameObject endPanel;
	public GameObject pausePanel;
  
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Pause ();
		}
	
	}
	public void StartGame ()
	{
		Debug.Log ("start");
		Time.timeScale = 1;
		Application.LoadLevel ("GameplayScene");
	}

	public void GoHomeScreen ()
	{
		Time.timeScale = 1;
		Application.LoadLevel ("StartScene");
	}

	public void Pause ()
	{
		pausePanel.SetActive (!pausePanel.activeSelf);
		Time.timeScale = Time.timeScale == 0 ? 1 : 0;
	}
	public void Restart ()
	{
		Time.timeScale = 1;
		Application.LoadLevel (Application.loadedLevel);
	}
    
	public void Quit ()
	{
		#if UNITY_EDITOR            
		EditorApplication.isPlaying = false;
		#else
            Application.Quit();
		#endif
	}


}
