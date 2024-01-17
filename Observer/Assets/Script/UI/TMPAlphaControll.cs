using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMPAlphaControll : MonoBehaviour
{
    private TextMeshProUGUI _tmp = default;
    // Start is called before the first frame update
    void Start()
    {
        _tmp = this.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _tmp.color = new Color(1.0f, 1.0f, 1.0f, this.GetComponentInParent<Image>().color.a);
    }
}
