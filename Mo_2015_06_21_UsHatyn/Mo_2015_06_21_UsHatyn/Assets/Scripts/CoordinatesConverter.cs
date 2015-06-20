using UnityEngine;
using System.Collections;

public class CoordinatesConverter : MonoBehaviour {

    float deltaXreal = 129.792190f - 129.763411f;
    float deltaYReal = 62.194677f - 62.198312f;
    float deltaXunity = 911f - (-3532f);
    float deltaYunity = -247f - 966f;
    float x0real = 129.763411f;
    float y0real = 62.198312f;
    float x0unity = -3532f;
    float y0unity = 966f;

    float ConvertXFromRealToUnity(float real)
    {
        float unity;
        unity = deltaXunity / deltaXreal * real + x0unity - deltaXunity / deltaXreal * x0real;
        return unity;
    }

    float ConvertYFromRealToUnity(float real)
    {
        float unity;
        unity = deltaYunity / deltaYReal * real + y0unity - deltaYunity / deltaYReal * y0real;
        return unity;
    }

	// Use this for initialization
	void Start () {
        Debug.Log(ConvertXFromRealToUnity(129.773247f).ToString());
        Debug.Log(ConvertYFromRealToUnity(62.201295f).ToString());
	
	}
	
	// Update is called once per frame
	void Update () {

        //0
        //62.198312, 129.763411
        //x=-3532 z=966

        //1
        //62.194677, 129.792190
        //x=911 z=-247
	}
}
