using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Image Slider;
    [SerializeField] protected TMP_Text Points;
    [SerializeField] protected Player Player;

    protected void OnValueChanged(float value, float maxValue)
    {
        Slider.fillAmount = value / maxValue;
        Points.text = $"{value} / {maxValue}";
    }
}
