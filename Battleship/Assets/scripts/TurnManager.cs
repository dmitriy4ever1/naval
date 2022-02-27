using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public Text turnTxt;
    public Text statTxt;

    public string turn = "player";
    public  int playerTurns = 3;
    public  int aiTurns = 4;
    public static int turncount = 0;
    void Start()
    {
        turnTxt.text = "Player Turn";
        turnTxt.color = Color.blue;
    }

    // Update is called once per frame
    void UpdateTxt()
    {
        
    }
}
