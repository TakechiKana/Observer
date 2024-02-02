using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetVariables_GameEnd : MonoBehaviour
{
    [Header("���ԕ\���e�L�X�g")][SerializeField]
    private TextMeshProUGUI _gameTimeText;
    [Header("���ԕ\���e�L�X�g")][SerializeField]
    private TextMeshProUGUI _reportedPhenomenonText;
    // Update is called once per frame
    void Update()
    {
        //�������ٕ�
        string reportedObjCountString = "";
        reportedObjCountString = PhenomenonLists.GetReportedPhenomenonCount().ToString("00");
        reportedObjCountString += " out of ";
        reportedObjCountString += PhenomenonLists.GetAlreadyPhenomenonCount().ToString("00");
        _reportedPhenomenonText.text = reportedObjCountString;

        //�Q�[���^�C��
        string gameTimeString = "";
        gameTimeString = GameTime.GetHour().ToString("00");
        gameTimeString += (" : ");
        gameTimeString += GameTime.GetMinute().ToString("00");
        _gameTimeText.text = gameTimeString;

    }
}
