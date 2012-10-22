using UnityEngine;
using System.Collections;


[RequireComponent(typeof(GUITexture))]
public class PlayLogoMovie : MonoBehaviour {
	
#if UNITY_STANDALONE_WIN
	
    public MovieTexture logoMovie;
	public MovieTexture gameMovie;
	public AudioSource logoAudioObj;
    public AudioSource gameAudioObj;

    private float time;
    /// <summary>
    /// Static Prop.
    /// </summary>
    private static bool _playLogo = true;
    public static bool _PlayLogo {
        get { return _playLogo; }
        set { _playLogo = value; }
    }
	
#endif
	
	
	// Use this for initialization
	void Start () {
#if UNITY_STANDALONE_WIN
        if (_playLogo) 
            PlayLogo();
        else
			PlayMovie();
#endif
		
#if UNITY_IPHONE
		iPhoneUtils.PlayMovie("Movies/LogoVista3D.mp4", Color.black, iPhoneMovieControlMode.CancelOnTouch, iPhoneMovieScalingMode.AspectFill);
		
        if (!Application.isLoadingLevel) {
            LoadingScreen.SceneName = Manager.SceneNames.StartGame.ToString();
            Application.LoadLevelAsync(Manager.SceneNames.LoadingScene.ToString());
        }
#endif
	}

    void PlayMovie()
    {
#if UNITY_STANDALONE_WIN
        gameMovie.Play();
        gameAudioObj.Play();
        this.guiTexture.texture = gameMovie;
#endif
	}

    void PlayLogo() {	
#if UNITY_STANDALONE_WIN
        logoMovie.Play();
        logoAudioObj.Play();
#endif
	}

    void LoadGame() {
#if UNITY_STANDALONE_WIN
		
        logoMovie.Stop();
        gameMovie.Stop();	

        if (!Application.isLoadingLevel) {
            LoadingScreen.SceneName = Manager.SceneNames.StartGame.ToString();
            Application.LoadLevelAsync(Manager.SceneNames.LoadingScene.ToString());
        }

        Destroy(this.gameObject);	
		
#endif	
    }
	
	// Update is called once per frame
    void Update() {
#if UNITY_STANDALONE_WIN
		
        time += Time.deltaTime;
        if (time >= logoMovie.duration && _playLogo) {
			_playLogo  = false;
			time = 0f;
			PlayMovie();
        }
		
		if(time >= gameMovie.duration && !_playLogo){
            time = 0;
            LoadGame();
		}

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0)) {
            LoadGame();
        }
		
#endif
	}
}
