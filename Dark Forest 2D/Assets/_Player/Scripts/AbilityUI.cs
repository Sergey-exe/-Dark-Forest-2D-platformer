using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour
{
    [SerializeField] private Button _abilityButton;

    private Coroutine _coroutine;

    public void ChangeUI(float timeRecharge)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeAbsorptionButton(timeRecharge));
    }

    private IEnumerator ChangeAbsorptionButton(float timeRecharge)
    {
        float maxValue = 1;
        float minValue = 0;
        float speed = maxValue / timeRecharge;

        Image _absorptionImage = _abilityButton.GetComponent<Image>();
        _abilityButton.interactable = false;
        _absorptionImage.fillAmount = minValue;

        while (_absorptionImage.fillAmount != maxValue)
        {
            float fillAmount = _absorptionImage.fillAmount;

            _absorptionImage.fillAmount = Mathf.MoveTowards(fillAmount, maxValue, speed * Time.deltaTime);

            yield return null;
        }

        _abilityButton.interactable = true;
    }

}
