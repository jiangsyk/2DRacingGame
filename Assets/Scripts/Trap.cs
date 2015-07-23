using UnityEngine;
using System.Collections;

/*
 * Description: Trap
 * Author:      JiangShu
 * Create Time: 2015/7/22 16:19:31
 */
public class Trap : MonoBehaviour
{
    public float damage = 3;
    void Start()
    {

    }
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            other.SendMessage("ApplyDamage", damage);
            Destroy(gameObject);
        }

    }
}
