using UnityEngine;
using UnityEngine.UI;

public class clickcounter : MonoBehaviour
{
    public Slider slider;
    public Text clickCountText;

    private int currentValue = 0;
    private int maxClicks = 10;
    private int clickCount = 0;

    private void Start()
    {
        slider.value = 0;
        UpdateClickCountText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickCount < maxClicks)
        {
            currentValue++;
            clickCount++;
            UpdateSliderValue();
            UpdateClickCountText();
        }
    }

    private void UpdateSliderValue()
    {
        float normalizedValue = Mathf.Clamp01((float)currentValue / maxClicks);
        slider.value = normalizedValue * slider.maxValue;
    }

    private void UpdateClickCountText()
    {
        clickCountText.text = "Clicks: " + clickCount.ToString();
    }
}
