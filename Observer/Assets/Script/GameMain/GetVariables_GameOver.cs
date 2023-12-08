using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetVariables_GameOver : MonoBehaviour
{
    [Header("時間表示テキスト")][SerializeField]
    private TextMeshProUGUI _gameTimeText;
    [Header("時間表示テキスト")][SerializeField]
    private TextMeshProUGUI _reportedPhenomenonText;
    // Update is called once per frame
    void Update()
    {
        string gameTimeString = "";
        gameTimeString = GameTime.GetHour().ToString("00");
        gameTimeString += (" : ");
        gameTimeString += GameTime.GetMinute().ToString("00");
        _gameTimeText.text = gameTimeString;

        string reportedObjCountString = "";
        reportedObjCountString = PhenomenonLists.GetReportedPhenomenonCount().ToString("00");
        _reportedPhenomenonText.text = reportedObjCountString;
    }
}
