using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Bank bank;
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    // Update is called once per frame
    public void RewardGold()
    {
        if(bank == null) { return; }
        bank.Deposit(goldReward);
    }

    public void StealdGold()
    {
        if (bank == null) { return; }
        bank.Withdraw(goldPenalty);
    }
}
