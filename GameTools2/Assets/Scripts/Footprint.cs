using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour {

	[SerializeField] GameObject f_footprint; // I use a gameobject here to allow me to instantiate the particle effect I want for the footprint.
    private Animator f_animator;// Declaring a variable for the animator.
    private Transform f_rightTransform;// Two transforms for the right and left foot of the player model.
    private Transform f_leftTransform;

    public AudioSource Footstep;//Footstep sound effect.

    void Start()
    {
        f_animator = GetComponent<Animator>();// This line gets the animator attached to the gameobject this script is on.

        f_rightTransform = f_animator.GetBoneTransform(HumanBodyBones.RightFoot);//This is setting the positions of the transform variables to their positions on the player skeleton.
        f_leftTransform = f_animator.GetBoneTransform(HumanBodyBones.LeftFoot);
    }

    //These two functions are calling the events I made during the walk animation when the right and left foot touched the ground.
    public void MakeRFootprint()
    {
        Footstep.Play();//Plays the footstep sound effect.
        Instantiate(f_footprint, f_rightTransform.position, f_rightTransform.rotation);//This is spawning in the particle effect assigned to f_footprint at the foots position and rotation.
    }

    public void MakeLFootprint()
    {
        Footstep.Play();
        Instantiate(f_footprint, f_leftTransform.position, f_leftTransform.rotation);      
    }

}
