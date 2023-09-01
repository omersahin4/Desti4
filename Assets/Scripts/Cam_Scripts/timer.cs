using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public Text countdownText;
    public Slider timeSlider;

    private float countdownValue = 2f;
    private float currentTime = 2f;

    private bool isCountingDown = true;

    void Start()
    {
        timeSlider.minValue = 0f; // Slider minimum deðeri
        timeSlider.maxValue = countdownValue; // Slider maksimum deðeri
        currentTime = countdownValue; // Baþlangýçta slider ve süreyi ayarla
        UpdateCountdownText();
    }

    void Update()
    {
        if (isCountingDown && currentTime > 0)
        {
            currentTime -= Time.deltaTime; // Süreyi azalt
            timeSlider.value = currentTime; // Slider deðerini güncelle
            UpdateCountdownText();
        }
    }

    public void OnSliderValueChanged()
    {
        currentTime = timeSlider.value;
        UpdateCountdownText();
    }

    private void UpdateCountdownText()
    {
        countdownText.text = Mathf.CeilToInt(currentTime).ToString();

        if (currentTime <= 0)
        {
            isCountingDown = false;
        }
    }
}
