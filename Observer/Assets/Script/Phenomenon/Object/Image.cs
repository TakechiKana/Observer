using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Image : MonoBehaviour
{
    //�ύX��e�N�X�`��
    [SerializeField] Texture changeTex = default;
    //�����e�N�X�`��
    Texture startTex;
    //�I�u�W�F�N�g�̃}�e���A��
    Material material;
    //�ύX�̔���
    bool isChange = true;

    void Start()
    {
        //���g�̃}�e���A���̎擾
        material = this.GetComponent<MeshRenderer>().material;
        // �e�N�X�`���̎擾
        startTex = material.GetTexture("_MainTex");
    }

    void Update()
    {
        //���۔����t���O�������Ă��Ȃ���
        if (!this.GetComponent<ObjectTypeManager>().GetIsOutbreak())
        {
            //�ύX�t���O���I��
            if (isChange)
            {
                // �����e�N�X�`���ɖ߂�
                material.SetTexture("_MainTex", startTex);
                //�ύX�t���O������
                isChange = false;
            }
            return;
        }
        //���۔����t���O��ON�ł��ύX�ς̂Ƃ�
        if (isChange)
        {
            return;
        }
        // �e�N�X�`���̕ύX
        material.SetTexture("_MainTex", changeTex);
        //�ύX�t���O�𗧂Ă�
        isChange = true;
    }
}
