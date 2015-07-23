using UnityEngine;
using System.Collections;

/*
 * Description: Projectle
 * Author:      JiangShu
 * Create Time: 2015/7/22 15:32:45
 */
public class Projectle : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 3);
    }
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
