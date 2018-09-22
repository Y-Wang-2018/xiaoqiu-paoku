using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test1 : MonoBehaviour {

    bool alive;
    GameObject ho;
    float vy;
    static int score;
    bool fly;
    Button bt;
    
    //CharacterController cc;
	// Use this for initialization
	void Start () {
        alive = true;
        ho = GameObject.Find("Hero");
        vy = 0;
        state = 0;
        vx = 0.12f;
        vz = 0.05f;
        score = 0;
        fly = false;
        bt = GameObject.Find("Button").GetComponent<Button>();
        bt.onClick.AddListener(delegate () {
            if (vz < 0.1f)
                vz = 0.2f;
            else
                vz = 0.05f;
        });

        //cc = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update () {
        if (alive)
        {
            if (Input.acceleration.x < 0.24)
            {
                state = 1;
            }
            else if (Input.acceleration.x > 0.24)
            {
                state = 2;
            }
            else
            {
                state = 0;
            }
            if (Input.touchCount == 1)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {

                    if (fly)
                    {
                        ho.transform.Translate(0, -5, 0);
                    }
                    else
                    {
                        ho.transform.Translate(0, 5, 0);
                    }
                    fly = !fly;
                }
            }
            moveforward();
            movehorizon();
        }
        else
            Application.Quit();
	}

    //横向运动
    int state;//0—水平静止 1-左移 2-右移
    float vx;//横向移动灵敏度
    void movehorizon()
    {
        if (state == 1&&ho.transform.position.x>125)
        {
            //cc.Move(new Vector3(-vx, 0, 0));
            ho.transform.Translate(new Vector3(-vx, 0, 0));
        }
        if (state == 2&&ho.transform.position.x<135)
        {
            //cc.Move(new Vector3(vx, 0, 0));
            ho.transform.Translate(new Vector3(vx, 0, 0));
        }
    }

    //向前移动
    float vz;//前进速度
    void moveforward()
    {
        //cc.Move(new Vector3(0, 0, vz));
        ho.transform.Translate(new Vector3(0, 0, vz));
    }

    //碰撞处理
    private void OnCollisionEnter(Collision collision)
    {
        alive = false;
    }
}
