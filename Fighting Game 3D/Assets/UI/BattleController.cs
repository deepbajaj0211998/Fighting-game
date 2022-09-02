using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{

    public Fighter player1;
    public Fighter player2;
    public int roundTime = 99;
    public float LastTimeUpdate = 0;
    public Text player1Win;
    public Text player2Win;
    public bool isGameOver;
    public HUDController hud;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
