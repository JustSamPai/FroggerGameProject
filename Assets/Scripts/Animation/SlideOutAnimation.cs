using System.Collections;
using TMPro;
using UnityEngine;

public class SlideOutAnimation : MonoBehaviour
{
    public Transform startPosition;
    public Transform middlePosition;
    public Transform endPosition;
    public float slideInDuration = 1f;
    public float stayDuration = 1f;
    public float slideOutDuration = 1f;

    private RectTransform rectTransform;
    private TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void StartAnimation(){
        textMeshPro.enabled = true;
        gameObject.SetActive(true);
        StartCoroutine(AnimateSlide());
        
    }

    IEnumerator AnimateSlide()
    {
        rectTransform.position = startPosition.position;
        textMeshPro.enabled = true;

        yield return StartCoroutine(SlideToPosition(middlePosition, slideInDuration));
        yield return new WaitForSeconds(stayDuration);
        yield return StartCoroutine(SlideToPosition(endPosition, slideOutDuration));

        textMeshPro.enabled = false;
        gameObject.SetActive(false);
    }

    IEnumerator SlideToPosition(Transform targetPosition, float duration)
    {
        Vector3 initialPosition = rectTransform.position;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float t = Mathf.Clamp01(timer / duration);
            rectTransform.position = Vector3.Lerp(initialPosition, targetPosition.position, t);

            yield return null;
        }
    }
}
