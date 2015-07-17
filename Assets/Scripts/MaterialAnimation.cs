using UnityEngine;
using System.Collections;

/*
 * Description: MaterialAnimation
 * Author:      JiangShu
 * Create Time: 2015/7/17 17:00:50
 */
[RequireComponent(typeof(MaterialManager))]
public class MaterialAnimation : MonoBehaviour
{
    public int min;
    public int max;
    public int fps = 5;

    float timer;
    MaterialManager manager;
    void Start()
    {
        manager = GetComponent<MaterialManager>();
        manager.currentFrame = min;
        manager.HandlerMaterial();
        ResetTimer();
    }
    void Update()
    {
        if (manager == null) return;
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            ResetTimer();
            manager.currentFrame++;
            if(manager.currentFrame > max)
            {
                manager.currentFrame = min;
            }
            manager.HandlerMaterial();
        }
    }
    void ResetTimer()
    {
        timer = 1f / fps;
    }
}
