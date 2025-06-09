using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;

public class LoginManager : MonoBehaviour
{
    public TMP_InputField ID;
    public TMP_InputField PW;
    public GameObject error;


    public void Login()
    {
        string inputID = ID.text;
        string inputPW = PW.text;
        PopupBank popup = FindObjectOfType<PopupBank>();

        string path = Path.Combine(Application.persistentDataPath, inputID + ".json");

        if (!File.Exists(path))
        {
            error.SetActive(true);
        }


        string json = File.ReadAllText(path);
        UserData loadedUser = JsonUtility.FromJson<UserData>(json);

        if (loadedUser.Password == inputPW)
        {
            GameManager.Instance.userData = loadedUser;
            GameManager.Instance.savePath = Path.Combine(Application.persistentDataPath, inputID + ".json");
            popup.OpenPopupBank();

        }
        else
        {

            error.SetActive(true);
        }

    }

    public void Onerror()
    {
        error.SetActive(false);
    }


}
