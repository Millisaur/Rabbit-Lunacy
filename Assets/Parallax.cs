using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cam;
    public float relativeMove = .3f;
    public bool lockY = false;
    public bool boss = false;
    public bool check = false;
    
    private CameraSwitcher cameraSwitcher;

    void Start()
    {
        cameraSwitcher = GameObject.Find("SceneChange").GetComponent<CameraSwitcher>();
    }

    void Update()
    {
        if(!cameraSwitcher.boss)
        {
            if(lockY)
            {
                transform.position = new Vector2(cam.position.x * relativeMove, transform.position.y);
            }
            else
            {
                transform.position = new Vector2(cam.position.x * relativeMove, cam.position.y * relativeMove);
            }
        }
        else if (!check)
        {
            check = true;
            transform.position = new Vector2(cam.position.x * relativeMove, transform.position.y);
        }
    }
}
