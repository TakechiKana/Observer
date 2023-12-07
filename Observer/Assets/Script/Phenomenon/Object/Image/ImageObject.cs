using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageObject : MonoBehaviour
{
    //変更後テクスチャ
    [SerializeField] Texture changeTex = default;
    //初期テクスチャ
    Texture startTex = default;
    //オブジェクトのマテリアル
    Material material = default;
    //変更の判定
    bool isChange = true;

    void Start()
    {
        //マテリアルの取得
        material = this.GetComponent<MeshRenderer>().material;
        // テクスチャの取得
        startTex = material.GetTexture("_BaseMap");
    }

    void Update()
    {        //現象発生フラグが立っていない時
        if (!this.GetComponent<ObjectTypeManager>().GetIsOutbreak())
        {
            //変更フラグがオン
            if (isChange)
            {
                // 初期テクスチャに戻す
                material.SetTexture("_BaseMap", startTex);
                //変更フラグを消す
                isChange = false;
            }
            return;
        }
        //現象発生フラグがONでも変更済のとき
        if (isChange)
        {
            return;
        }
        // テクスチャの変更
        material.SetTexture("_BaseMap", changeTex);
        //変更フラグを立てる
        isChange = true;
    }
}
