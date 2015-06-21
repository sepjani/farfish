using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelValues : MonoBehaviour {

    public Text text;

    int levelNum = 1;
    float milesGone = 0;

	// Use this for initialization
	void Start () {	    
	}
	
	// Update is called once per frame
	void Update () {
        milesGone += 10 * Time.deltaTime;
        text.text = Mathf.Round(milesGone) + "";
             
	}
}
