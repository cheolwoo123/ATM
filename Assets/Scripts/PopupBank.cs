using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupBank : MonoBehaviour
{
    public GameObject popupSignUp;
    public GameObject login;
    public GameObject popupBank;
    public GameObject deposit;
    public GameObject withdraw;
    public GameObject ATM;
    public GameObject givemeMoney;
    public GameObject koreaOK;
    public GameObject gOGOUI;
    public TMP_InputField inputFieldDeposit;
    public TMP_InputField inputFieldWithdraw;
    public UserUI userUI;
    // Start is called before the first frame update

   public void GOGOUI()
    {
        gOGOUI.SetActive(true);
        ATM.SetActive(false);
    }
    public void OpenPopupSignUp()
    {
        popupSignUp.SetActive(true);
    }
    public void OpenPopupBank()
    {
        login.SetActive(false);
        popupBank.SetActive(true);
    }
    public void OpenDeposit()
    {   
       ATM.SetActive(false);
        deposit.SetActive(true);
        withdraw.SetActive(false);
    }

    
    public void OpenWithdraw()
    {
        ATM.SetActive(false);
        deposit.SetActive(false);
        withdraw.SetActive(true);
    }

    
    public void CloseAll()
    {
        deposit.SetActive(false);
        withdraw.SetActive(false);
        popupBank.SetActive(true);
        koreaOK.SetActive(false);
        givemeMoney.SetActive(false);
        gOGOUI.SetActive(false);

    }

    public void DepositAmount(int amount)
    {
        var data = GameManager.Instance.userData;

        if (data.Cash >= amount)
        {
            data.Cash -= amount;
            data.Balance += amount;
            
        }
        else
        {
            givemeMoney.SetActive(true);
        }
        GameManager.Instance.SaveUserData();
        userUI.RefreshUI();
        
    }

    public void inputDepositAmount()
    {
        string input = inputFieldDeposit.text;
       
        if (int.TryParse(input, out int customAmount))
        {
            
            DepositAmount(customAmount);
        }
        else
        {
            koreaOK.SetActive(true);
        }

        inputFieldDeposit.text = ""; 
    }



    public void WithdrawAmount(int amount)
    {
        var data = GameManager.Instance.userData;

        if (data.Balance >= amount)
        {
            data.Balance -= amount;
            data.Cash += amount;
           
        }
        else
        {
            givemeMoney.SetActive(true);
        }
        GameManager.Instance.SaveUserData();
        userUI.RefreshUI();
       
    }
    public void inputWithdrawAmount()
    {
        string input = inputFieldWithdraw.text;
        
        if (int.TryParse(input, out int customAmount))
        {

            WithdrawAmount(customAmount);
        }
        else
        {
            koreaOK.SetActive(true);
        }

        inputFieldWithdraw.text = "";
    }



}
