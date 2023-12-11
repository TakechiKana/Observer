using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameClear_GetVariable : MonoBehaviour
{
    [Header("発見した以上の数表示テキスト")]
    [SerializeField]
    private TextMeshProUGUI _reportedPhenomenonText;
    void Update()
    {
        string anomaryString = "";
        anomaryString = PhenomenonLists.GetReportedPhenomenonCount().ToString("00");
        anomaryString += (" out of ");
        anomaryString += PhenomenonLists.GetAllPhenomenonCount().ToString("00");
        _reportedPhenomenonText.text = anomaryString;

    }
}
