using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test2 : MonoBehaviour {

    float y0,y1;
    bool up;
    GameObject gobj;
	// Use this for initialization
	void Start () {
        gobj = GameObject.Find("obstacle_ud");
        y0 = gobj.transform.position.y;
        y1 = y0 + 8;
        up = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (up)
        {
            gobj.transform.Translate(0, 0.03f, 0);
        }
        else
        {
            gobj.transform.Translate(0, -0.03f, 0);
        }
        if (gobj.transform.position.y > y1 || gobj.transform.position.y < y0)
        {
            up = !up;
        }
	}
}
