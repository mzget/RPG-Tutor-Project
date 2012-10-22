using UnityEngine;
using System.Collections;

public class SaveGame : MonoBehaviour
{	
    // Use this for initialization
    void Start()
    {

    }

    public static void Save()  {
        //PlayerPrefs.SetString(StorageManage.SaveSlot + "username", StorageManage.Username);
        //PlayerPrefs.SetInt(StorageManage.SaveSlot + "score", StorageManage.Score);
        //PlayerPrefs.SetInt(StorageManage.SaveSlot + "character", StorageManage.CharacterId);
        //PlayerPrefs.SetInt(StorageManage.SaveSlot + "car", StorageManage.CarId);
        //PlayerPrefs.SetInt(StorageManage.SaveSlot + "pipe", StorageManage.ActivePipe);
        //PlayerPrefs.SetInt(StorageManage.SaveSlot + "bumper", StorageManage.ActiveBumper);
        //PlayerPrefs.SetInt(StorageManage.SaveSlot + "spoiler", StorageManage.ActiveSpoiler);
    }

    void OnApplicationQuit() {
        Save();

        //Application.CancelQuit();

        //if (!Application.isLoadingLevel)
        //{
        //    Application.LoadLevelAsync("LoadingScene");
        //    LoadingScreen.SceneName = Main.SceneNames.StartGame.ToString();
        //}
    }
}
