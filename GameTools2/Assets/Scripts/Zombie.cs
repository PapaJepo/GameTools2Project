using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    Animator z_anim;//Declaring a variable for the animator.
    
    public float speed;//Declaring float to be used for the enemies speed.
    public float health = 10f;//Setting the Health value for the enemy.
    public float damage = 10f;//Setting how much damage the enemy can deal.

    public Transform player;//This is taking in a public transform of the player so that the enemy know where the player is.
    public GameObject Player;//This is taking in the player object so taht it can access its components such as health and its animator.
    public GameObject Blood;//used to store the blood particle effect.
    public AudioSource Bite,Death,Moan;//This is adding in a bite and death sound effect to the zombie.
    public Transform BloodEffect;//Used to spawn in blood effect.
    
    void Start ()
    {
        z_anim = GetComponent<Animator>();//Assigning the animator variable to the objects animator component. 
    }
	
	
	void Update ()
    {
        Debug.Log(health);//This is for checking the Health of teh enemy in the console when testing.
        float step = speed * Time.deltaTime;//This is so the speed is affected by the seconds in game not the frames.
        float dist = Vector3.Distance(player.position, transform.position);//Here I'm assigning a float variable to be asigned the value of the distance between the players position and the obejct this zmobie script is attached to,
       
        if(dist < 60 && dist >2)//If the player gets close enough to the enemy this if statement wll trigger.
        {
            transform.LookAt(player);//The zombie will look towards the player.
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);//This is moving the zombie towards the position of the player.
            bool walk = true;
            z_anim.SetBool("PlayerClose", walk);//This is telling the animator to start the zombies wlak animation.

            if (dist<3)//Once the zombie gets close to the player it will run this if statement which plays an attack animation and stops the zombie from moving.
            {
                walk = false;
                z_anim.SetBool("PlayerClose", walk);
                bool attack = true;
                z_anim.SetBool("Attack", attack);
            }   
        }
        else//If the player is not close to the zombie he stands idle.
        {
           bool walk = false;
           z_anim.SetBool("PlayerClose", walk);
        }

        if (health <= 0)//If the player shoots the zombie.
        {
            Instantiate(Blood, BloodEffect);//Spawns in the blood effect.
            bool walk = false;
            z_anim.SetBool("PlayerClose", walk);//Stop any wlaking animation.
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
}
