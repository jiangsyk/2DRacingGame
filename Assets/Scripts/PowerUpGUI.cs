using UnityEngine;
using System.Collections;

/*
 * Description: PowerUpGUI
 * Author:      JiangShu
 * Create Time: 2015/7/23 16:01:32
 */
public class PowerUpGUI : MonoBehaviour
{
    UISprite sprite;
    PlayerProperties player;
    PlayerProperties.PlayerState nowState;

    void Start()
    {
        sprite = GetComponent<UISprite>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProperties>();
    }
    void Update()
    {
        if(nowState != player.playerState)
        {
            nowState = player.playerState;
            switch(nowState)
            {
                case PlayerProperties.PlayerState.CarNormal:
                    sprite.spriteName = "NoneGUI";
                    break;
                case PlayerProperties.PlayerState.CarProjectile:
                    sprite.spriteName = "ProjectileGUI";
                    break;
                case PlayerProperties.PlayerState.CarTrap:
                    sprite.spriteName = "TrapGUI";
                    break;
                case PlayerProperties.PlayerState.CarBoost:
                    sprite.spriteName = "BoostGUI";
                    break;
            }
        }
    }
}
