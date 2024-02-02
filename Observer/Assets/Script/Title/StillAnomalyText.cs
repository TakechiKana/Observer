using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StillAnomalyText : MonoBehaviour
{
    //�t���O�}�l�[�W��
    //private GameObject _flagManager = default;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GetStillAnomaly", 0.1f);
    }

    void GetStillAnomaly()
    {
        string text = ("");
        text += ("�܂� ");
        text +=  PhenomenonLists.GetStillReportedAnomalyCount().ToString("00");
        text += (" ��Anomaly���̂����Ă��܂��B");
        this.gameObject.GetComponent<TextMeshProUGUI>().text = text;
    }
}
