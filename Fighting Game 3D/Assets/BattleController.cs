using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{

    public Fighter player;
    public Fighter player2;
    public int roundTime = 99;
    public float lastTimeUpdate = 0;
    public Text player1Win;
    public Text player2Win;
    public bool isGameOver;
    public HUDController hud;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver == false)
		{
            if (roundTime > 0 && Time.time - lastTimeUpdate > 1)
            {
                roundTime--;
                lastTimeUpdate = Time.time;
                if (roundTime == 0)
                {
                    expireTime();
                }
            }
        }
		if (player.lifePercent <= 0)
		{
            player2Win.gameObject.SetActive(true);
            isGameOver = true;
        }
        if (player2.lifePercent <= 0)
        {
            player1Win.gameObject.SetActive(true);
            isGameOver = true;
        }
    }

    void expireTime()
	{
        if(player.lifePercent > player2.lifePercent)
		{
            player2.life = 0;
		}
		else
		{
            player.life = 0;
		}
	}

}
