using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {
	
	public GUISkin mainInterfaceSkin;

    public enum GUIState { none = 0, showCharacters, };
    public GUIState guiState = GUIState.none;
    public enum SceneName { none = 0, MainMenuScreen, LoadingScreen, Scene_1, };
    public SceneName sceneName = SceneName.none;
    public static float setWidth = 800F;
    public static float setHeight = 500F;
    
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / setWidth, Screen.height / setHeight, 1));

        GUI.Box(new Rect(0, 450, 600, 50), "No commercial purpose, Made for tutorial only.", mainInterfaceSkin.box);
		
		GUI.BeginGroup(new Rect(600, 0, 200, 500), GUIContent.none, mainInterfaceSkin.box);
		{
//			if(GUI.Button(new Rect(0, 0, 200, 60), new GUIContent("?"))) {
//                if(guiState != GUIState.showCharacters) {
//                    guiState = GUIState.showCharacters;
//                }
//            }
//            else if (GUI.Button(new Rect(0, 60, 200, 60), new GUIContent(""))) {
//				Screen.SetResolution(800,450,false);
//            }
//            else if (GUI.Button(new Rect(0, 120, 200, 60), new GUIContent(""))) {
//				Screen.SetResolution(1280,720,false);
//            }
            if(GUI.Button(new Rect(0,400,200,50),"Test")) {
                if(!Application.isLoadingLevel) {
                    LoadingScreen.SceneName = SceneName.Scene_1.ToString();
                    Application.LoadLevel(SceneName.LoadingScreen.ToString());
                }
            }
            else if (GUI.Button(new Rect(0, 450, 200, 50), "Toggle Screen")) {
                Screen.fullScreen = !Screen.fullScreen;
            }
		}
		GUI.EndGroup();

        // Decide to Call Fuction.
        if (guiState == GUIState.showCharacters) {
            ShowCharaterLists();
        }
	}

    void ShowCharaterLists() { 
        
    }
}
