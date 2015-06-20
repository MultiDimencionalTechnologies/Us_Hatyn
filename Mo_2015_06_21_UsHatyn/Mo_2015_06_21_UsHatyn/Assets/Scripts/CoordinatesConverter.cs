using UnityEngine;
using System.Collections;

public class CoordinatesConverter : MonoBehaviour {

    static float deltaXreal = 129.792190f - 129.763411f;
    static float deltaYReal = 62.194677f - 62.198312f;
    static float deltaXunity = 911f - (-3532f);
    static float deltaYunity = -247f - 966f;
    static float x0real = 129.763411f;
    static float y0real = 62.198312f;
    static float x0unity = -3532f;
    static float y0unity = 966f;

    public static float ConvertXFromRealToUnity(float real)
    {
        float unity;
        unity = deltaXunity / deltaXreal * real + x0unity - deltaXunity / deltaXreal * x0real;
        return unity;
    }

    public static float ConvertYFromRealToUnity(float real)
    {
        float unity;
        unity = deltaYunity / deltaYReal * real + y0unity - deltaYunity / deltaYReal * y0real;
        return unity;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
