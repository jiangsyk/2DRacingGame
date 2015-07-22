using UnityEngine;
using System.Collections;

/*
 * Description: SpawnController
 * Author:      JiangShu
 * Create Time: 2015/7/21 16:21:33
 */
public class SpawnController : MonoBehaviour
{
    const float respawnTimer = 1;

    public Vector3 currentTrackPosition;

    bool activeRespawnTimer = false;
    float respawnTimerCount = respawnTimer;

    void Start()
    {
        currentTrackPosition = transform.position;
    }
    void Update()
    {
        if(activeRespawnTimer)
        {
            respawnTimerCount -= Time.deltaTime;
        }
        if(respawnTimerCount < 0)
        {
            transform.position = currentTrackPosition;
            respawnTimerCount = respawnTimer;
            activeRespawnTimer = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("CheckPoint"))
        {
            currentTrackPosition = transform.position;
        }
        if(other.CompareTag("DeadZone"))
        {
            activeRespawnTimer = true;
        }
    
    }
}
