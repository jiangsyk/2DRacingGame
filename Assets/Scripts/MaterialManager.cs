using UnityEngine;
using System.Collections;

/*
 * Description: MaterialManager
 * Author:      JiangShu
 * Create Time: 2015/7/17 16:50:19
 */
public class MaterialManager : MonoBehaviour
{
    public int columns = 8;//列 x num
    public int rows = 8;//行 y num
    public int currentFrame = 0;
    void Start()
    {
        HandlerMaterial();
    }
    void Update()
    {

    }
    [ContextMenu("Handle Material")]
    public void HandlerMaterial()
    {
        Vector2 framePosition = new Vector2();
        framePosition.x = currentFrame % columns;
        framePosition.y = currentFrame / columns;
        renderer.sharedMaterial.SetTextureScale("_MainTex", new Vector2(1f / columns, 1f / rows));
        renderer.sharedMaterial.SetTextureOffset("_MainTex", new Vector2(framePosition.x / columns, 1 - (framePosition.y + 1) / rows));
    }
}
