using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;

    int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] int targetGold = 200;

    [SerializeField] TextMeshProUGUI displayBalance;

    [SerializeField] TextMeshProUGUI targetGoldText;



    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    private void Update()
    {
        NextLevel();
    }

    public void NextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if(currentBalance >= targetGold)
        {
            SceneManager.LoadScene(currentScene.buildIndex + 1);
        }
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displayBalance.text = "Gold : " + currentBalance.ToString();
        targetGoldText.text = "Target Gold : " + targetGold.ToString();
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
