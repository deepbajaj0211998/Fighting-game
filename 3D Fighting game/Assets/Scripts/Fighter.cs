using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{

    public enum PlayerType
    {
        Human, AI
    };

    public static float maxHealth = 100f;
    public float life = maxHealth;
    public string fighterName;
    public Fighter opponent;
    public PlayerType player;
    protected Animator animator;
    private Rigidbody mybody;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void UpdateHumanInput()
    {
        if(Input.GetAxis("Horizontal") > 0.1)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
