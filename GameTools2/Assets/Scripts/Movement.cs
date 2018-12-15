using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Animator c_anim;//Declarign my variable for the animator.
    
    public Transform BulletSpawn;//The transform position where the bullet will spawn from the gun.
    public GameObject Bullet;//This is used to store the Bullet prefab.
    public Transform Enemy;//This is for the location of the enemy object.
    public AudioSource FireEffect;//Sound Effect for the gun shooting.
     
    private float BulletSpeed = 10000;//This float affects the speed of the bullet.
    public float health = 30f;//This si the health value for the player and is affected by the zombie script.

    void Start ()
    {
        c_anim = GetComponent<Animator>();//Assigning the animator component on the game object to the animator varible. 
    }
	
	void Update ()
    {
        
        float move = Input.GetAxis("Vertical");//This is so that the W and S keys move the character and play its respected animations.
        c_anim.SetFloat("forward", move);//This affects the float parameter named forward in the animator controller.
        float strafe = Input.GetAxis("Horizontal");//This is so that the A and D keys turn the character and play its respected animations.
        c_anim.SetFloat("strafe", strafe);//This affects the float parameter named strafe in the animator controller.
        bool crouch = Input.GetKey(KeyCode.C);//This is so that the C key allows the player to crouch and play its respected animation.
        c_anim.SetBool("crouched", crouch);//This affects the bool parameter named crouched in the animator controller.
        bool aim = Input.GetMouseButton(1);//When the player presses left click the bool shoot is set to true.
        c_anim.SetBool("aiming", aim);
        bool run = Input.GetKey(KeyCode.LeftShift);
        c_anim.SetBool("running", run);
        bool jump = Input.GetKey(KeyCode.Space);
        c_anim.SetBool("jumping", jump);
        

        if (Input.GetMouseButtonDown(0) && c_anim.GetBool("aiming") == true && run == false)//When the player presses left click the bool shoot is set to true.        
        {
            Debug.Log("shooting");
            c_anim.SetBool("shoot", true); //This affects the bool parameter named shoot in the animator controller.
        }
        else
        {
            c_anim.SetBool("shoot", false); 
        }
  
        if (health <= 0)//If the player takes enough damage to reduce their health to 0 it plays the die animation adn destroys the gameobject.
        {
            bool die = true;
            c_anim.SetBool("die", die);
            Destroy(gameObject, 3f);
        }

    }

    public void ActiveShoot()//This function is to shoot a bullet from the gun and is called during the shoot animation when the character pulls the trigger.
    {
        GameObject Shoot;//This line is declaring a gameobject to be used to assign the spawning in of the bullet and assigning a rigidbody to the bullet.
        Rigidbody BulletPhys;//This line is declaring a rigidbody to apply physics to the bullet.
        Shoot = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as GameObject;//Assigning the spawning of the bullet to the shoot game object.
        FireEffect.Play();//This is playing the Gun Shot sound effect.
        BulletPhys = Shoot.GetComponent<Rigidbody>();//This line is assinging the rigidbody component to the variable BulletPhys.
        BulletPhys.AddForce(transform.forward * BulletSpeed);//This is shooting the bullet forward at the predefined speed.
        Destroy(Shoot, 1f);//After 1 second the bullet is destroyed.
    }
}
