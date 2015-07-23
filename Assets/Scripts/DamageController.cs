using UnityEngine;
using System.Collections;

/*
 * Description: DamageController
 * Author:      JiangShu
 * Create Time: 2015/7/23 15:16:49
 */
public class DamageController : MonoBehaviour
{
    public float health = 3;
    void Start()
    {

    }
    void Update()
    {

    }
    public void ApplyDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
