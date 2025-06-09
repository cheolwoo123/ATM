
    using System.IO;
using UnityEngine;
using TMPro;

public class RemittanceManager : MonoBehaviour
{
    public TMP_InputField targetIDInput;
    public TMP_InputField amountInput;
    public GameObject error1;
    public GameObject error2;
    public GameObject error3;

    public void OnClickRemittance()
    {
        string targetID = targetIDInput.text.Trim();
        string amounts = amountInput.text.Trim();

     
        if (string.IsNullOrEmpty(targetID) || string.IsNullOrEmpty(amounts))
        {
            OpenErrorIDamount();
            return;
        }

       
        if (!int.TryParse(amounts, out int amount) || amount <= 0)
        {
            CloseErroramount();
            return;
        }

   
        UserData userData = GameManager.Instance.userData;

        if (userData.Balance < amount)
        {
            CloseErroramount();
            return;
        }   

       
        string targetPath = Path.Combine(Application.persistentDataPath, targetID + ".json");

        if (!File.Exists(targetPath))
        {
            OpenErrorId();
            return;
        }

  
        string targetJson = File.ReadAllText(targetPath);
        UserData targetData = JsonUtility.FromJson<UserData>(targetJson);

      
        userData.Balance -= amount;
        targetData.Balance += amount;

   
        File.WriteAllText(targetPath, JsonUtility.ToJson(targetData)); // 상대방 저장
        GameManager.Instance.SaveUserData(); // 내 정보 저장

       
        targetIDInput.text = "";
        amountInput.text = "";
    }

    public void OpenErrorIDamount()
    {
        error1.SetActive(true);
    }
    public void CloseErroramount()
    {
        error2.SetActive(true);
    }
    public void OpenErrorId()
    {
        error3.SetActive(true);
    }

}
