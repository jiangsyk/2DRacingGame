using UnityEngine;
using System.Collections;

/*
 * Description: HealthController
 * Author:      JiangShu
 * Create Time: 2015/7/23 15:39:20
 */
public class HealthController : MonoBehaviour
{

    UISprite healthSprite;
    DamageController playerHealth;
    float nowHp;

    void Start()
    {
        healthSprite = GetComponent<UISprite>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<DamageController>();

        nowHp = playerHealth.health;
        RefreshSprite();
    }
    void Update()
    {
        if (nowHp != playerHealth.health)
        {
            nowHp = playerHealth.health;
            RefreshSprite();
        }
    }

    void RefreshSprite()
    {
        int id = (int)nowHp;
        if (id < 0) id = 0;
        healthSprite.spriteName = "hp_" + id;
    }
}
