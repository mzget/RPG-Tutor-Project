using UnityEngine;
using System.Collections;

public class GUI_Manager : MonoBehaviour {

    public GUISkin mainInterfaceSkin;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / Main.setWidth, Screen.height / Main.setHeight, 1));

        GUI.BeginGroup(new Rect(0, 450, 100, 50), GUIContent.none, mainInterfaceSkin.box);
        {
            if (GUI.Button(new Rect(5, 5, 40, 40), GUIContent.none, mainInterfaceSkin.customStyles[0])) { 
                
            }
        }
        GUI.EndGroup();
    }
}
