using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserUI : MonoBehaviour
{

    public Text userName;
    public Text balance;
    public Text cashText;
    public TextMeshProUGUI ID;
    public TextMeshProUGUI PW;
    UserData data ;


     void Start()
    {
        data = GameManager.Instance.userData;
    }
    void Update()
    {
       
        RefreshUI();
    }
    public void RefreshUI()
    {
        data = GameManager.Instance.userData;
        userName.text = $"{data.UserName}";
        balance.text = $"{data.Balance}";
        cashText.text = $"{data.Cash}";
        ID.text = $"{data.ID}";
            PW.text = $"{data.Password}";
       






    }
    
}
