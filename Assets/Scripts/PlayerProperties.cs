using UnityEngine;
using System.Collections;

/*
 * Description: PlayerProperties
 * Author:      JiangShu
 * Create Time: 2015/7/22 10:08:24
 */
public class PlayerProperties : MonoBehaviour
{
    public enum PlayerState
    {
        CarDead = 0,
        CarNormal,
        CarProjectile,
        CarTrap,
        CarBoost
    }
    public PlayerState playerState = PlayerState.CarNormal;

    public GameObject projectile;
    public GameObject trap;
    public GameObject boost;

    public Transform projectilePos;
    public Transform trapPos;
    public Transform boostPos;

    public bool changeState = false;
    public bool canPickUp = true;

    public bool hasProjectile = false;
    public bool hasTrap = false;
    public bool hasBoost = false;

    public uint projectileSpeed = 350;

    void Start()
    {
        SetPlayerState();
    }
    void Update()
    {
        if(changeState)
        {
            SetPlayerState();
            changeState = false;
        }
        if(hasProjectile)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Projectile();
                Normal();
            }
        }
        if(hasTrap)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Trap();
                Normal();
            }
        }
        if(hasBoost)
        {

        }
    }
    void Projectile()
    {
        GameObject cloneProjectile = Instantiate(projectile, projectilePos.position, projectilePos.rotation) as GameObject;
        Vector3 fireProjectile = transform.up * projectileSpeed;
        cloneProjectile.rigidbody2D.AddForce(fireProjectile);
    }
    void Trap()
    {
       Instantiate(trap, trapPos.position, trapPos.rotation);
    }
    void Boost()
    {

    }
    void SetPlayerState()
    {
        switch(playerState)
        {
            case PlayerState.CarNormal:
                Reset();
                canPickUp = true;
                break;
            case PlayerState.CarProjectile:
                Reset();
                hasProjectile = true;
                break;
            case PlayerState.CarTrap:
                Reset();
                hasTrap = true;
                break;
            case PlayerState.CarBoost:
                Reset();
                hasBoost = true;
                break;
            case PlayerState.CarDead:
                Reset();
                break;
        }
    }
    void Reset()
    {
        hasProjectile = false;
        hasTrap = false;
        hasBoost = false;
        canPickUp = false;
    }
    void Normal()
    {
        playerState = PlayerState.CarNormal;
        changeState = true;
    }
}
