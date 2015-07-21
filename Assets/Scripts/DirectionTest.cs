using UnityEngine;
using System.Collections;
/*
 * Author:      JiangShu
 */
public class DirectionTest : MonoBehaviour {

    public Transform cube;
    float result;

	void Start () {
	
	}
	
	void Update () {
        Debug.DrawRay(transform.position, transform.up * 2);
        Debug.DrawRay(cube.position, cube.up * 2);
        result = Vector3.Dot(transform.up, cube.up);
	}

    void OnGUI()
    {
        GUILayout.Label(result.ToString(), GUILayout.Width(Screen.width));
        GUI.skin.label.fontSize = 60;
    }
}
