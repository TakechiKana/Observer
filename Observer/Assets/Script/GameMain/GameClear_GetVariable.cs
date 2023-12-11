using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameClear_GetVariable : MonoBehaviour
{
    [Header("���������ȏ�̐��\���e�L�X�g")]
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
