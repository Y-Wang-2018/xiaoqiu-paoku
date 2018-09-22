using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test3 : MonoBehaviour {

    float x0, x1;
    bool rig;
    GameObject gobj;
    // Use this for initialization
    void Start()
    {
        gobj = GameObject.Find("obstacle_lr");
        x0 = gobj.transform.position.x;
        x1 = x0 + 4;
        rig = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rig)
        {
            gobj.transform.Translate(0.03f, 0, 0);
        }
        else
        {
            gobj.transform.Translate(-0.03f, 0, 0);
        }
        if (gobj.transform.position.x > x1 || gobj.transform.position.x < x0)
        {
            rig = !rig;
        }
    }
}
