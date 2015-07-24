using UnityEngine;
using System.Collections;

/*
 * Description: SpeedLapGUI
 * Author:      JiangShu
 * Create Time: 2015/7/23 17:00:37
 */
public class SpeedLapGUI : MonoBehaviour
{
    float speed;
    int lap;
    public UILabel speedLabel;
    public UILabel lapLabel;

    PlayerMovement movement;
    CheckPointController checkPointC;

    void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        checkPointC = GameObject.FindGameObjectWithTag("Player").GetComponent<CheckPointController>();
    }
    void Update()
    {
        speed = movement.currentSpeed * 10;
        speedLabel.text = Mathf.Round(speed).ToString();
        lapLabel.text = checkPointC.currentLap.ToString();

    }
}
