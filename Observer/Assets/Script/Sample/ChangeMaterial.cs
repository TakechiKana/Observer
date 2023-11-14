using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    [SerializeField] Texture tex = default;
    Texture texture;
    Material material;
    bool flag = true;

    void Start()
    {
        material = this.GetComponent<MeshRenderer>().material;
        // テクスチャの取得
        texture = material.GetTexture("_MainTex");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flag)
            {
                // テクスチャの変更
                material.SetTexture("_MainTex", tex);
                flag = false;
            }
            else
            {
                // テクスチャの変更
                material.SetTexture("_MainTex", texture);
                flag = true;
            }

        }
    }
}
