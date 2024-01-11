using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField] private float totalTime = 60f;
    private float _currentTime;

    [SerializeField] private GameObject sliderGo;
    [SerializeField] private GameObject donePanel;
    private Slider _slider;
    private void Start()
    {
        _slider = sliderGo.GetComponent<Slider>();
        _currentTime = totalTime;
        UpdateTimerBar();
    }
    private void Update()
    {
        if (_currentTime>0f)
        {
            _currentTime -= Time.deltaTime;
            UpdateTimerBar();
        }
        else
        {
            gameObject.SetActive(false);
            donePanel.SetActive(true);
        }
    }

    private void UpdateTimerBar()
    {
        var normalizedTime = _currentTime / totalTime;
        _slider.value = Mathf.Lerp(1f, 0f, normalizedTime);
    }
}
