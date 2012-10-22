using UnityEngine;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public GUISkin standard;

//    private GameObject backGroundIns, loadingAnimatedIns = null;

	private static string sceneName = null;
	public static string SceneName {
		get{return sceneName;}
		set{sceneName = value;}
	}

//    private int countTex = 0;
	private AsyncOperation async;
	
	
	void Awake() {
		Resources.UnloadUnusedAssets();
	}
	
    IEnumerator Start()
    {
        async =  Application.LoadLevelAsync(sceneName);

        if (Application.isLoadingLevel) {
            while (!async.isDone) {
                yield return 0;
            }
        }
		
#if UNITY_IPHONE || UNITY_ANDROID
		async = Application.LoadLevelAsync(sceneName);
		
		if(Application.isLoadingLevel) {
			while(async.isDone == false) {
				yield return 0;
			}
		}
		
#endif	
    }

    void Update()
    {

    }

    void OnGUI()
    {
        GUI.depth = 0;
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3(Screen.width / Main.setWidth, Screen.height / Main.setHeight, 1));

        standard.textArea.fontSize = 24;			/// Can't Sizer on iOS.

        float process = async.progress * 100f;
        GUI.TextArea(new Rect(Main.setWidth / 2 - 150, Main.setHeight / 2 - 24, 300, 48), "Loading... "/** + process.ToString("F1") + " %" **/, standard.box);
    }
}