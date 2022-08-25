using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    public Fighter player1;
    public Fighter player2;
    public Text player1Tag;
    public Text player2Tag;
    public Scrollbar leftBar;
    public Scrollbar rightBar;
    public Text timerText;
    public BattleController battle;

    // Start is called before the first frame update
    void Start()
    {
        player1Tag.text = player1.fighterName;
        player2Tag.text = player2.fighterName;
    }

    // Update is called once per frame
    void Update()
    {
        if(leftBar.size > player1.lifePercent)
        {
            leftBar.size -= 0.01f;
        }
        if (rightBar.size > player2.lifePercent)
        {
            rightBar.size -= 0.01f;
        }
    }
}
