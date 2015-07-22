using UnityEngine;
using System.Collections;

/*
 * Description: PowerUp
 * Author:      JiangShu
 * Create Time: 2015/7/22 10:08:09
 */
public class PowerUp : MonoBehaviour
{
    public enum PowerType
    {
        projectile = 0,
        Trap,
        Boost
    }

    public PowerType powerUpType = PowerType.projectile;
    private GameObject playerGameObject;
    private PlayerProperties playerProperties;

    public float respawnTimer = 10;
    void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerProperties = playerGameObject.GetComponent<PlayerProperties>();
    }

    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") && playerProperties.canPickUp)
        {
            ApplyPowerUp();
            SetEnabled(false);
            Invoke("Active", respawnTimer);
        }
    }
    void Active()
    {
        SetEnabled(true);
    }
    void SetEnabled(bool value)
    {
        collider2D.enabled = value;
        renderer.enabled = value;
    }
    void ApplyPowerUp()
    {
        switch(powerUpType)
        {
            case PowerType.projectile:
                playerProperties.playerState = PlayerProperties.PlayerState.CarProjectile;
                break;
            case PowerType.Trap:
                playerProperties.playerState = PlayerProperties.PlayerState.CarTrap;
                break;
            case PowerType.Boost:
                playerProperties.playerState = PlayerProperties.PlayerState.CarBoost;
                break;
                
        }
        playerProperties.changeState = true;
    }

}
