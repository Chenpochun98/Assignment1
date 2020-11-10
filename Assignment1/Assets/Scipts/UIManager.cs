using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text pointsText;
    [SerializeField] private GameObject wintext;
 
    public void UpdateScoreDisplay(int currentScore)
    {
        pointsText.text = "Points: " + currentScore.ToString();
    }

    public void winDisplay(int currentScore)
    {
        if (currentScore == 90)
        {
            wintext.SetActive(true);
        }
    }
}
