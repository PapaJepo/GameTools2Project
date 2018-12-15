using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

    private enum NPCState { CHASE, PATROL};
    private NPCState z_NPCState;
    private int z_CurrentWaypoint;

    Animator z_anim;//Declaring a variable for the animator.
    public Shader Passive;
    public Shader Active;
    Renderer renderchange;
         
    public float speed;//Declaring float to be used for the enemies speed.
    public float health = 10f;//Setting the Health value for the enemy.
    public float damage = 10f;//Setting how much damage the enemy can deal.

    public Transform player;//This is taking in a public transform of the player so that the enemy know where the player is.
    public GameObject Player;//This is taking in the player object so taht it can access its components such as health and its animator.
    public GameObject Blood;//used to store the blood particle effect.
    public AudioSource Bite,Death,Moan;//This is adding in a bite and death sound effect to the zombie.
    public Transform BloodEffect;//Used to spawn in blood effect.
    public Transform[] z_Waypoints;
    
    private NavMeshAgent z_navMeshAgent;
    [SerializeField] bool z_PlayerNear;
    
    void Start ()
    {
        renderchange = GetComponent<Renderer>();
        z_NPCState = NPCState.PATROL;
        z_navMeshAgent = GetComponent<NavMeshAgent>();
        z_anim = GetComponent<Animator>();//Assigning the animator variable to the objects animator component. 
        z_CurrentWaypoint = 0;
        AnimationFloat();
    }
	
	
	void Update ()
    {
        CheckPlayer();
       // Debug.Log(health);//This is for checking the Health of the enemy in the console when testing.
        float step = speed * Time.deltaTime;//This is so the speed is affected by the seconds in game not the frames.
        float dist = Vector3.Distance(player.position, transform.position);//Here I'm assigning a float variable to be asigned the value of the distance between the players position and the obejct this zmobie script is attached to,
       
        //if(dist < 60 && dist >2)//If the player gets close enough to the enemy this if statement wll trigger.
        //{
           // transform.LookAt(player);//The zombie will look towards the player.
           // transform.position = Vector3.MoveTowards(transform.position, player.position, step);//This is moving the zombie towards the position of the player.
            //bool walk = true;
           // z_anim.SetBool("PlayerClose", walk);//This is telling the animator to start the zombies wlak animation.

            if (dist<3&&z_PlayerNear==true)//Once the zombie gets close to the player it will run this if statement which plays an attack animation and stops the zombie from moving.
            {
                //walk = false;
                z_anim.SetFloat("forward", 0);
                bool attack = true;
                z_anim.SetBool("Attack", attack);
            }   
       // }
       // else//If the player is not close to the zombie he stands idle.
       // {
           //bool walk = false;
          // z_anim.SetBool("PlayerClose", walk);
       // }*/

        switch(z_NPCState)
        {
            case NPCState.CHASE:
                Chase();
                break;
            case NPCState.PATROL:
                Patrol();
                break;
            default:
                break;
        }

        if (health <= 0)//If the player shoots the zombie.
        {
            
            z_anim.SetFloat("forward", 0);
            Instantiate(Blood, BloodEffect);//Spawns in the blood effect.
            bool walk = false;
            z_anim.SetBool("PlayerClose", walk);//Stop any walking animation.
            bool attack = false;
            z_anim.SetBool("Attack", attack);//Stop any attack animation.
            bool die = true;
            z_anim.SetBool("Die", die);//Play the death animation.
            Destroy(gameObject, 3f);//After 3 seconds destory the gameobject the zombie script is attached to.
        }
    }

    public void AttackHit()//This is a event made during the zombie attack animation when it hits the player.
    {
        Bite.Play();//PLays the attack sound effect.
        GameObject.Find("player").GetComponent<Movement>().health -= damage;//This line finds the player object and the movement script attached to it and deals damage to the health value in movement.
        Animator c_anim = Player.GetComponent<Animator>();//This is assigning the animator of the player object to a variable.
        c_anim.SetTrigger("Damage");//This is telling the players animation controller to play the damage animation when he is it.
    }

    public void DeathSound()
    {
        Death.Play();//Play the death sound.
    }

    void CheckPlayer()
    {
        if (z_NPCState == NPCState.PATROL && z_PlayerNear == true)
        {
            z_NPCState = NPCState.CHASE;
            AnimationFloat();
            return;
        }
        if(z_NPCState == NPCState.CHASE && z_PlayerNear == false)
        {
            z_NPCState = NPCState.PATROL;
            AnimationFloat();
        }
    }

    void Chase()
    {
        renderchange.material.shader = Active;
        z_navMeshAgent.SetDestination(Player.transform.position);
    }

    void Patrol()
    {
        renderchange.material.shader = Passive;
        UpdateWaypoints();
        z_navMeshAgent.SetDestination(z_Waypoints[z_CurrentWaypoint].position);
    }

    void UpdateWaypoints()
    {
        if(Vector3.Distance(z_Waypoints[z_CurrentWaypoint].position,this.transform.position) < 3)
        {
            z_CurrentWaypoint = (z_CurrentWaypoint + 1) % z_Waypoints.Length;
        }
    }

    void AnimationFloat()
    {
        if(z_NPCState == NPCState.CHASE)
        {
            z_anim.SetFloat("forward", 2);
        }
        else
        {
            z_anim.SetFloat("forward", 1);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            z_PlayerNear = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            z_PlayerNear = false;
        }
    }
}
