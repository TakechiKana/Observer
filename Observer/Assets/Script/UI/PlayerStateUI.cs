using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateUI : MonoBehaviour
{
    //UIのRectTransform
    private RectTransform _rectTransform = default;
    //UIのマテリアル
    private Material _material = default;
    //リスクレベルによるサイズ(高さ)と波形の速度設定用定数
    //Danger
    private const float DANGER_HIGHT = 100;
    private const float DANGER_SPEED = 500;
    //High
    private const float HIGH_HIGHT = 80;
    private const float HIGH_SPEED = 70;
    //Middle
    private const float MIDDLE_HIGHT = 50;
    private const float MIDDLE_SPEED = 50;
    //Low
    private const float LOW_HIGHT = 30;
    private const float LOW_SPEED = 30;
    //None
    private const float NONE_HIGHT = 30;
    private const float NONE_SPEED = 20;
    ////数値間の距離
    //private Vector3 _distance = default;
    ////計算用のフラグ
    //private bool _calcFlag = false;

    void Start()
    {
        //RectTransformコンポーネント取得
        _rectTransform = transform.GetChild(0).GetComponent<RectTransform>();
        //マテリアル
        _material = transform.GetChild(0).GetComponent<Image>().material;
        //サイズとスピードの設定
        SetNoneLevel();
    }

    /// <summary>
    /// 異常なし
    /// </summary>
    public void SetNoneLevel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, NONE_HIGHT);
        _material.SetFloat("_OffsetTime", NONE_SPEED);
    }
    /// <summary>
    /// 低レベル
    /// </summary>
    public void SetLowLevel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, LOW_HIGHT);
        _material.SetFloat("_OffsetTime", LOW_SPEED);
    }
    /// <summary>
    /// 中レベル
    /// </summary>
    public void SetMiddleLevel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, MIDDLE_HIGHT);
        _material.SetFloat("_OffsetTime", MIDDLE_SPEED);
    }
    /// <summary>
    /// 高レベル
    /// </summary>
    public void SetHighLevel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, HIGH_HIGHT);
        _material.SetFloat("_OffsetTime", HIGH_SPEED);
    }
    /// <summary>
    /// 危険レベル
    /// </summary>
    public void SetDanderLevel()
    {
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, DANGER_HIGHT);
        _material.SetFloat("_OffsetTime", DANGER_SPEED);
    }
}
