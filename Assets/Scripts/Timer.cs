using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Slider))]
public class Timer : MonoBehaviour
{   
    [Header("Temporizador")]
    [SerializeField] private float _maxTime;
    private float _actuTime;

    private Slider _slider;
    private void Start()
    {
        _actuTime = 0f;
        _slider = GetComponent<Slider>();
        _slider.maxValue = _maxTime;
        _slider.value = _actuTime;
    }

    private void Update()
    {
        _actuTime += 1 * Time.deltaTime;
        _slider.value = _actuTime;

        if (_actuTime > _maxTime)
        {
            Debug.Log("O disco Voador");
            Debug.Log(_actuTime);
            _actuTime = 0f;
            _slider.value = _actuTime;
        }
    }
}
