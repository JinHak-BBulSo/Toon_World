using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;
    // 추가
    [SerializeField, Range(10f, 150f)]
    private float leverRange;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        //추가
        var clampedDir = inputDir.magnitude < leverRange ?
            inputDir : inputDir.normalized * leverRange;

        // lever.anchoredPosition = inputDir;
        lever.anchoredPosition = clampedDir;    // 변경
    }

    public void OnDrag(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        // 추가
        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;

        // lever.anchoredPosition = inputDir;
        lever.anchoredPosition = clampedDir;    // 변경
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
    }
}
