using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockBall : MonoBehaviour
{
    public bool isUnlocked;
    [SerializeField]private string key;

    private void Awake()
    {
        PlayerPrefs.SetInt("Billy", 1);
        PlayerPrefs.SetInt("Bart", 1);

        //if (PlayerPrefs.GetInt(key) == 0)
        //{
        //    isUnlocked = false;
        //}
        //else
        //{
        //    isUnlocked = true;
        //}
    }
    private void OnEnable()
    {
        if(PlayerPrefs.GetInt(key) == 0)
        {
            isUnlocked = false;
        }
        else
        {
            isUnlocked = true;
        }
    }
}
