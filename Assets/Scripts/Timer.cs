using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{   
    [Header("Temporizador")]
    [SerializeField] private float _maxTime;
    [SerializeField]private Slider _slider;
    private float _actuTime;
    private bool _isCounting;

    public delegate void OnMaxTimeAchi();
    public OnMaxTimeAchi onMaxTimeAchi;
    
    private void Start()
    {
        _actuTime = 0f;
        _slider.maxValue = _maxTime;
        _slider.value = _actuTime;
        _isCounting = true;
    }

    private void Update()
    {
        if (_isCounting)
        {
            _actuTime += 1 * Time.deltaTime;
            _slider.value = _actuTime;

            if (_actuTime > _maxTime)
            {
                if (onMaxTimeAchi == null)
                    return;
                Stop();
            }
        }
    }

    public void RegisMaxTime(OnMaxTimeAchi method)
    {
        onMaxTimeAchi += method;
    }

    public void Stop()
    {
        _isCounting = false;

        if (onMaxTimeAchi != null)
        {
            onMaxTimeAchi();
        }
    }

    public void Zerar()
    {
        _actuTime = 0f;
        _slider.value = _actuTime;
        _isCounting = true;
    }
    
}
