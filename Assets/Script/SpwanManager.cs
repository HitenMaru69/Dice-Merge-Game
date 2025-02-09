using System.Collections.Generic;
using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    [SerializeField] List<GameObject> spwanObject;
    [SerializeField] RectTransform spwanTransform;
    [SerializeField] Canvas gamePlayCanvas;

    private void Start()
    {
        SpwanRandomObject();
        EventManager.Instance.SpwanNewObjectEvent += OnSpwanNewObject;
    }

    private void OnDisable()
    {
        EventManager.Instance.SpwanNewObjectEvent -= OnSpwanNewObject;
    }

    private void SpwanRandomObject()
    {
        int randomNumber = Random.Range(0, spwanObject.Count);
        GameObject newSpwanObject = Instantiate(spwanObject[randomNumber], gamePlayCanvas.transform);
        RectTransform rectTransform = newSpwanObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = spwanTransform.anchoredPosition;
    }

    private void OnSpwanNewObject(object sender, System.EventArgs e)
    {
        SpwanRandomObject();
    }


}
