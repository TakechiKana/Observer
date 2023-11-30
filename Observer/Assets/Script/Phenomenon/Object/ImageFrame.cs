using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFrame : MonoBehaviour
{
    //�ύX��e�N�X�`��
    [SerializeField] Texture changeTex = default;
    //�����e�N�X�`��
    Texture startTex = default;
    //�I�u�W�F�N�g�̃}�e���A��
    Material material = default;
    //�ύX�̔���
    bool isChange = true;
    //�q�I�u�W�F�N�g
    GameObject imageObject = default;

    void Start()
    {
        //�t�H�g�t���[���v���n�u�̎q�I�u�W�F�N�g���擾
        imageObject = transform.GetChild(0).gameObject;
        //�}�e���A���̎擾
        material = imageObject.GetComponent<MeshRenderer>().material;
        // �e�N�X�`���̎擾
        startTex = material.GetTexture("_BaseMap");
    }

    void Update()
    {        //���۔����t���O�������Ă��Ȃ���
        if (!this.GetComponent<ObjectTypeManager>().GetIsOutbreak())
        {
            //�ύX�t���O���I��
            if (isChange)
            {
                // �����e�N�X�`���ɖ߂�
                material.SetTexture("_BaseMap", startTex);
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
        material.SetTexture("_BaseMap", changeTex);
        //�ύX�t���O�𗧂Ă�
        isChange = true;
    }
}
