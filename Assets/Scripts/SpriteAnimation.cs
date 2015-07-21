using UnityEngine;
using System.Collections;

/*
 * Description: SpriteAnimation
 * Author:      JiangShu
 * Create Time: 2015/7/21 14:50:05
 */
public class SpriteAnimation : MonoBehaviour
{
    PlayerMovement movement;
    Animator animator;

    int speedID;
    int directionID;
    int explosionID;


    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();

        speedID = Animator.StringToHash("Speed");
        directionID = Animator.StringToHash("Direction");
        explosionID = Animator.StringToHash("Explosion");

    }
    void Update()
    {
        animator.SetFloat(directionID, Input.GetAxis("Horizontal"));
        animator.SetFloat(speedID, movement.currentSpeed);
    }
    public void Explosion()
    {
        animator.SetTrigger(explosionID);
    }
}
