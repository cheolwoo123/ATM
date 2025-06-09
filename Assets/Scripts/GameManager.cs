using System.IO;
using UnityEngine;

[System.Serializable]
public class UserData
{
    [Header("User Data")]
    public string ID = "qwe123";
    public string Password = "qwe123";
    public string UserName = "Name";
    public int Balance = 0; 
    public int Cash = 0;    

    public UserData(string userName, int cash, int balance, string id, string password)
    {
        ID = id;
        Password = password;
        UserName = userName;
        Cash = cash;
        Balance = balance;
    }
    public UserData() { }
}


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UserData userData;
   public string savePath;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);           
            if (File.Exists(savePath)) { 
            
               LoadUserData();
            }
        }
        else
        {
            Destroy(gameObject);
        }

        
    }

    private void Start()
    {
        //SaveUserData();
        LoadUserData();
       
    }
    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData);
        File.WriteAllText(savePath, json);
        Debug.Log(savePath);
    }

    public void LoadUserData()
    {

        Debug.Log(savePath);
        if (File.Exists(savePath))
        {
            Debug.Log(savePath);
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log(userData.ID);
        }
        else
        {

            userData = new UserData("", 0, 0,"","");
        }
    }

}
