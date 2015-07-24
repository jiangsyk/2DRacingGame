using UnityEngine;
using System.Collections;

/*
 * Description: CheckPoint
 * Author:      JiangShu
 * Create Time: 2015/7/24 15:10:02
 */
public class CheckPoint : MonoBehaviour
{
    CheckPointController controller;
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<CheckPointController>();
    }
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(controller.checkPoints[controller.currentCheckPoint].Equals(transform))
            {
                if (controller.currentCheckPoint == 0)
                    controller.currentLap++;


                controller.currentCheckPoint++;
                print("checkPoint:" + controller.currentCheckPoint);
                if(controller.currentCheckPoint >= controller.checkPoints.Length)
                {
                    controller.currentCheckPoint = 0;
                }
            }
        }
    }
}
