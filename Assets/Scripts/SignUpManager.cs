using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine;

public class SignUpManager : MonoBehaviour
{
    public TMP_InputField inputID;
    public TMP_InputField inputName;
    public TMP_InputField inputPW;
    public TMP_InputField inputPWConfirm;
    public Text errorText;
    public GameObject loginPanel;
    public GameObject signUpPanel;

    public void OnClickSignUp()
    {
        string id = inputID.text.Trim();
        string name = inputName.text.Trim();
        string pw = inputPW.text;
        string pwConfirm = inputPWConfirm.text;

       
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pw) || string.IsNullOrEmpty(pwConfirm))
        {
            
            return;
        }

       
        if (pw != pwConfirm)
        {
          
            return;
        }

        
        string savePath = Path.Combine(Application.persistentDataPath, id + ".json");
        GameManager.Instance.savePath = savePath;
            
        if (File.Exists(savePath))
        {
            return;
        }

    
        UserData newUser = new UserData(name, 0, 0, id, pw);
        string json = JsonUtility.ToJson(newUser);
        File.WriteAllText(savePath, json);
        GameManager.Instance.userData = newUser;
        GameManager.Instance.savePath = savePath;

        GameManager.Instance.SaveUserData();

        OnClickCancel();
    }

    public void OnClickCancel()
    {
        loginPanel.SetActive(true);
        signUpPanel.SetActive(false);
    }
}
