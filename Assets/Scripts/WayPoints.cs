using UnityEngine;
using System.Collections;

/*
 * Description: WayPoints
 * Author:      JiangShu
 * Create Time: 2015/7/24 16:47:25
 */
public class WayPoints : MonoBehaviour
{
    public WayPoints next;
    void Start()
    {

    }
    void Update()
    {

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, Vector3.one);
        if (next)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, next.transform.position);
        }
    }
}
