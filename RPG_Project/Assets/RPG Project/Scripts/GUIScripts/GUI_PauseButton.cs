using UnityEngine;
using System.Collections;

public class GUI_PauseButton: MonoBehaviour {
	
	private PauseGameBeh pauseGameBeh;
	
	// Use this for initialization
	void Start () {
		pauseGameBeh = GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseGameBeh>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		pauseGameBeh.SetPauseGame(true);
		Instantiate(Resources.Load("GUI_Options", typeof(GameObject)));
	}
}
