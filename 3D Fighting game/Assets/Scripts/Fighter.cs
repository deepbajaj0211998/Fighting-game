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
    public int playerJumpPower = 50;

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
        if (Input.GetAxis("Horizontal") < -0.1)
        {
            animator.SetBool("WalkBack", true);
        }
        else
        {
            animator.SetBool("WalkBack", false);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetTrigger("rKick");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetTrigger("lKick");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetTrigger("lPunch");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("rPunch");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Health", lifePercent);
        if(player == PlayerType.Human)
        {
            UpdateHumanInput();
        }
        if(opponent != null)
        {
            animator.SetFloat("Opponent_Health", opponent.lifePercent);
        }
        else
        {
            animator.SetFloat("Opponent_Health", 1);
        }
    }

    public float lifePercent
    {
        get
        {
            return life / maxHealth;
        }
    }

    public Rigidbody body
    {
        get
        {
            return this.mybody;
        }
    }

}
