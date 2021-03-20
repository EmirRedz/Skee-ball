using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static int score;

    public TextMeshProUGUI totalTicketsMenuText;
    public static int totalTickets;

    private void Start()
    {
        totalTickets = PlayerPrefs.GetInt("TotalTickets", 0);
        SetTicketText(totalTicketsMenuText);

    }

    public void UseTickets(int Cost)
    {
        totalTickets -= Cost;
        PlayerPrefs.SetInt("TotalTickets", totalTickets);
        SetTicketText(totalTicketsMenuText);
    }

    public void SetTicketText(TextMeshProUGUI ticketText)
    {
        if (ticketText != null)
        {
            ticketText.text = totalTickets.ToString();
        }
    }
}
