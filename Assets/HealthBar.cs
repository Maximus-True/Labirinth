using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private float _maximum;
    private float _current;
    private RectTransform _bar;

	// Use this for initialization
	void Start ()
    {
        _bar = transform.GetChild(0).GetComponent<RectTransform>();
        _maximum = _bar.sizeDelta.x;
        _current = _maximum;
	}

    public void SetValue(float percent)
    {
        if (percent >= 0)
        {
            _current = _maximum * percent / 100;
            _bar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, _current);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
