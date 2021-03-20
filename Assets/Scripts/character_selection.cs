using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class character_selection : MonoBehaviour
{
    [Header("NavigationButtons")]
    public string key;
    public TMP_Text ballName;
    public Button confirmButton;
    public Button leftButton;
    public Button rightButton;
    private GameObject[] characterList;
    [HideInInspector]public int index;

    public string activeBallName;
    // Start is called before the first frame update
    void Awake()
    {
        index = PlayerPrefs.GetInt(key);

        characterList = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }
        if (characterList[index])
        {
            characterList[index].SetActive(true);
            IsBallUnlocked(characterList[index]);
            activeBallName = characterList[index].name;
        }
    }

    private void Update()
    {
        //if(confirmButton == null)
        //{
        //    return;
        //}
        //else
        //{
        //    if(confirmButton != null)
        //    {
        //        if(PlayerPrefs.GetInt(characterList[index].GetComponent<PlanetLockedCheck>().key) == 0)
        //        {
        //            confirmButton.interactable = false;
        //        }
        //        else
        //        {
        //            confirmButton.interactable = true;
        //        }
        //    }
        //}
        if (ballName != null)
        {
            StartCoroutine(ActivateBallNames());
            ballName.text = characterList[index].name;
        }
    }

    public void ToggleLeft()
    {
        characterList[index].SetActive(false);
        index--;
        if (index < 0)
        {
            index = characterList.Length - 1;
        }

        characterList[index].SetActive(true);
        IsBallUnlocked(characterList[index]);
    }

    public void ToggleRight()
    {
        characterList[index].SetActive(false);
        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }
        characterList[index].SetActive(true);
        IsBallUnlocked(characterList[index]);
    }

    public void ConfirmButton()
    {
        PlayerPrefs.SetInt(key, index);
    }

    IEnumerator ActivateBallNames()
    {
        yield return new WaitForSeconds(2);
        ballName.gameObject.SetActive(true); 
    }

    private void IsBallUnlocked(GameObject currentBall)
    {
        if (currentBall.GetComponent<UnlockBall>() != null && currentBall.GetComponent<UnlockBall>().isUnlocked)
        {
            if (confirmButton != null)
            {
                confirmButton.interactable = true;
            }
        }
        else
        {
            if (confirmButton != null)
            {
                confirmButton.interactable = false;
            }
        }
    }
}
