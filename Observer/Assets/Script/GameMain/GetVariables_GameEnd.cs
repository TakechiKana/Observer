using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetVariables_GameEnd : MonoBehaviour
{
    [Header("時間表示テキスト")][SerializeField]
    private TextMeshProUGUI _gameTimeText;
    [Header("時間表示テキスト")][SerializeField]
    private TextMeshProUGUI _reportedPhenomenonText;
    // Update is called once per frame
    void Update()
    {
        //見つけた異変
        string reportedObjCountString = "";
        reportedObjCountString = PhenomenonLists.GetReportedPhenomenonCount().ToString("00");
        reportedObjCountString += " out of ";
        reportedObjCountString += PhenomenonLists.GetAlreadyPhenomenonCount().ToString("00");
        _reportedPhenomenonText.text = reportedObjCountString;

        //ゲームタイム
        string gameTimeString = "";
        gameTimeString = GameTime.GetHour().ToString("00");
        gameTimeString += (" : ");
        gameTimeString += GameTime.GetMinute().ToString("00");
        _gameTimeText.text = gameTimeString;

    }
}
