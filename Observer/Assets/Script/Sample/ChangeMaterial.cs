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
        // �e�N�X�`���̎擾
        texture = material.GetTexture("_MainTex");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (flag)
            {
                // �e�N�X�`���̕ύX
                material.SetTexture("_MainTex", tex);
                flag = false;
            }
            else
            {
                // �e�N�X�`���̕ύX
                material.SetTexture("_MainTex", texture);
                flag = true;
            }

        }
    }
}
