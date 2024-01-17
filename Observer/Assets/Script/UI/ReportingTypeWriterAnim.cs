using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReportingTypeWriterAnim : MonoBehaviour
{
    [Header("レポートマネージャー")]
    [SerializeField] GameObject _repotManager = default;
    [Header("表示テキスト")]
    [SerializeField] string _displayText = default;
    //レポート中テキスト
    private TextMeshProUGUI _reportingText = default;
    //アニメーション回数上限（定数）
    private int DISPLAYTEXT_LENGTH_MAX = 0;

    void Start()
    {
        //TMP格納
        _reportingText = this.gameObject.GetComponent<TextMeshProUGUI>();
        //最大文字数の取得
        DISPLAYTEXT_LENGTH_MAX = _displayText.Length;
        //TMPに文字セット
        _reportingText.SetText(_displayText);
        //文字の表示数を設定
        _reportingText.maxVisibleCharacters = 0;
    }

    private void OnEnable()
    {
        StartCoroutine("ReportingAnimation");
    }

    private void OnDisable()
    {
        StopCoroutine("ReportingAnimation");
    }

    IEnumerator ReportingAnimation()
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j <= DISPLAYTEXT_LENGTH_MAX; j++)
            {
                //0.2秒待つ
                yield return new WaitForSeconds(0.1f);
                //表示文字数を設定する
                _reportingText.maxVisibleCharacters = j;
            }
        }
        //レポート内容が正しいか判定
        _repotManager.GetComponent<ReportProcess>().ReportJudge();
        //非アクティブにする
        this.gameObject.SetActive(false);
    }


}
