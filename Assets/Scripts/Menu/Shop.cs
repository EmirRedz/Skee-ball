using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [Header("General")]
    public float timeBetweenBuyChecks = 0.25f;
    public TextMeshProUGUI shopTickets;
    private Score Tickets;

    [Header("Cost")]
    public int JoeCost;
    public int SargeCost;
    public int CowboyCost;
    public int ClownCost;
    public int PenelopeCost;

    [Header("UI Update")]
    public TextMeshProUGUI joePriceTag;
    public TextMeshProUGUI sargePriceTag;
    public TextMeshProUGUI cowboyPriceTag;
    public TextMeshProUGUI clownPriceTag;
    public TextMeshProUGUI penelopePriceTag;

    [Header("Buttons")]
    public Button joeButton;
    public Button sargeButton;
    public Button cowboyButton;
    public Button clownButton;
    public Button penelopeButton;

    [Header("Not enough tickets")]
    public GameObject noTicketsHolder;
    public GameObject buttonsHolder;

    private void Awake()
    {
        Tickets = GetComponent<Score>();
    }
    private void Start()
    {
        //CheckButtons();
        SetPriceTags();
        Tickets.SetTicketText(shopTickets);
    }

    #region Buy Buttons
    public void BuyJoe(string key)
    {
        if(Score.totalTickets < JoeCost)
        {
            NotEnoughTickets(true);
            return;
        }
        PlayerPrefs.SetInt(key, 1);
        Tickets.UseTickets(JoeCost);
    }

    public void BuySarge(string key)
    {
        if (Score.totalTickets < SargeCost)
        {
            NotEnoughTickets(true);
            return;
        }
        PlayerPrefs.SetInt(key, 1);
        Tickets.UseTickets(SargeCost);
    }

    public void BuyCowboy(string key)
    {
        if (Score.totalTickets < CowboyCost)
        {
            NotEnoughTickets(true);
            return;
        }
        PlayerPrefs.SetInt(key, 1);
        Tickets.UseTickets(CowboyCost);
    }

    public void BuyClown(string key)
    {
        if (Score.totalTickets < ClownCost)
        {
            NotEnoughTickets(true);
            return;
        }
        PlayerPrefs.SetInt(key, 1);
        Tickets.UseTickets(ClownCost);
    }

    public void BuyPenelope(string key)
    {
        if (Score.totalTickets < PenelopeCost)
        {
            NotEnoughTickets(true);
            return;
        }
        PlayerPrefs.SetInt(key, 1);
        Tickets.UseTickets(PenelopeCost);
    }
    #endregion

    public void NotEnoughTickets(bool isActive)
    {
        noTicketsHolder.SetActive(isActive);
        buttonsHolder.SetActive(!isActive);
    }

    private void SetPriceTags()
    {
        joePriceTag.text = JoeCost.ToString();
        sargePriceTag.text = SargeCost.ToString();
        cowboyPriceTag.text = CowboyCost.ToString();
        clownPriceTag.text = ClownCost.ToString();
        penelopePriceTag.text = PenelopeCost.ToString();
    }

    private void CheckButtons()
    {
        StartCoroutine("Joe", joeButton);
        StartCoroutine("Sarge", sargeButton);
        StartCoroutine("Cowboy", cowboyButton);
        StartCoroutine("Clown", clownButton);
        StartCoroutine("Penelope", penelopeButton);

    }

    IEnumerator CheckIfBought(string key,Button buyButton)
    {
        while (buyButton.interactable)
        {
            if(PlayerPrefs.GetInt(key) == 1)
            {
                buyButton.interactable = false;
            }
            else
            {
                buyButton.interactable = true;
            }
            yield return new WaitForSeconds(timeBetweenBuyChecks);
        }
        yield return null;
    }
}
