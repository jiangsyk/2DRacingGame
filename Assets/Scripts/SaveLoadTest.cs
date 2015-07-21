using UnityEngine;
using System.Collections;

/*
 * Description: SaveLoadTest
 * Author:      JiangShu
 * Create Time: 2015/7/20 10:12:16
 */
public class SaveLoadTest : MonoBehaviour
{
    public Texture texture;
    void Start()
    {

    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
            Save();
        if (Input.GetKeyDown(KeyCode.L))
            Load();
    }
    void Save()
    {
        using(ES2Writer writer = ES2Writer.Create("SaveTest/00.sav"))
        {
            int i = 0;
            GameObject map = GameObject.Find("Map");
            MaterialManager[] mapQuads = map.GetComponentsInChildren<MaterialManager>();
            foreach(MaterialManager mm in mapQuads)
            {
                writer.Write<Transform>(mm.transform, "transform" + i);
                writer.Write<int>(mm.currentFrame, "frame" + i);
                i++;
            }
            writer.Save();
            print("Save Complete!");
        }
    }
    void Load()
    {
        using(ES2Reader reader = ES2Reader.Create("SaveTest/00.sav"))
        {
            GameObject parent = GameObject.Find("Map");
            if (parent == null)
                parent = new GameObject("Map");
            int i = 0;
            while(reader.TagExists("transform" + i))
            {
                GameObject quad = GameObject.CreatePrimitive(PrimitiveType.Quad);
                quad.renderer.material.mainTexture = texture;
                quad.renderer.material.shader = Shader.Find("Unlit/Transparent");
                quad.transform.parent = parent.transform;
                reader.Read<Transform>("transform" + i, quad.transform);
                MaterialManager mm = quad.AddComponent<MaterialManager>();
                mm.currentFrame = reader.Read<int>("frame" + i);
                i++;
            }
            print("Load Complete!");
        }
    }
}
