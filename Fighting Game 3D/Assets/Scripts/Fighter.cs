using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{

    public enum PlayerType
    {
        Human, AI
    }

    public static float maxHealth = 100f;
    public float life = maxHealth;
    public string fighterName;
    public Fighter opponent;
    public PlayerType player;
    public FighterState currentState = FighterState.Idle;
    protected Animator animator;
    private Rigidbody myBody;

    //Values For AI Player
    public float random;
    public float randomSetTime;

    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody>();
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
            if (opponent.attacking)
            {
                animator.SetBool("WalkBack", false);
                animator.SetBool("Block", true);
            }
            else
            {
                animator.SetBool("WalkBack", true);
                animator.SetBool("Block", false);
            }
        }
        else
        {
            animator.SetBool("WalkBack", false);
            animator.SetBool("Block", false);
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

    void UpdateAIInput()
    {
        animator.SetBool("Blocking", Blocking);
        animator.SetBool("Invulnerable", Invulnerable);
        animator.SetBool("enable", enabled);
        animator.SetBool("opponent.attacking", opponent.attacking);
        animator.SetFloat("DistanceToOpponent", GetDistanceToOpponent());
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Health", lifePercent);
        if(player == PlayerType.Human)
        {
            UpdateHumanInput();
        }
        else
        {
            UpdateAIInput();
        }
        if(opponent != null)
        {
            animator.SetFloat("Opponent_Health", opponent.lifePercent);
        }
        else
        {
            animator.SetFloat("Opponent_Health", 1);
        }
        if(life <= 0 && currentState != FighterState.KnockOut)
        {
            animator.SetTrigger("KnockOut");
            Body.constraints = RigidbodyConstraints.FreezeAll;
        }
        if(player == PlayerType.Human && currentState == FighterState.Win)
        {
            Body.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    float GetDistanceToOpponent()
    {
        return Mathf.Abs(transform.position.x - opponent.transform.position.x);
    }
    
    private bool Blocking
    {
        get
        {
            return currentState == FighterState.Defend;
        }
    }

    public bool attacking
    {
        get
        {
            return currentState == FighterState.Attack;
        }
    }

    public virtual void hurt (float damage)
    {
        if (!Invulnerable)
        {
            if (Blocking)
            {
                damage *= 0.2f;
            }
            if (life >= damage)
            {
                life -= damage;
            }
            else
            {
                life = 0;
            }
            if (life > 0)
            {
                animator.SetTrigger("TakeHit");
            }
        }
    }

    public bool Invulnerable
    {
        get
        {
            return currentState == FighterState.TakeHit
                || currentState == FighterState.Defend
                || currentState == FighterState.KnockOut;
        }
    }

    public float lifePercent
    {
        get
        {
            return life / maxHealth;
        }
    }

    public Rigidbody Body
    {
        get
        {
            return this.myBody;
        }
    }

}
