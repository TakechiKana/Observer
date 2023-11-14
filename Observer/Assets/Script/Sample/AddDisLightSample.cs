using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDisLightSample : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.SetActive(!this.gameObject.activeSelf);

        }
    }
}
