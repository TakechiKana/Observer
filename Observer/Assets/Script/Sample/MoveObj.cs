using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    //移動系オブジェクトの場合　オブジェクトの初期座標
    private Vector3 startPos = default;
    private Vector3 movePos = default;

    bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.gameObject.transform.position;
        movePos = this.gameObject.transform.GetChild(0).position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flag)
            {
                this.transform.position = movePos;
                flag = false;
            }
            else
            {
                this.transform.position = startPos;
                flag = true;
            }

        }
    }
}
