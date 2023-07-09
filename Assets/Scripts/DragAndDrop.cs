using UnityEngine.EventSystems;
using UnityEngine;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera MainCamera;
    Vector3 offset;
    public Transform DefaultParent, DefaultTempCardParent;
    private RectTransform rectTransform;
    void Awake()
    {
        MainCamera = Camera.allCameras[0];
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
        DefaultParent =DefaultTempCardParent= transform.parent;
        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
       

    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
        newPos.z = 0;
        rectTransform.anchoredPosition = newPos + offset;
        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }
    void CheckPosition()
    {
        int newIndex = DefaultTempCardParent.childCount;
        for(int i=0; i<DefaultTempCardParent.childCount; i++)
        {
            if(transform.position.x<DefaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;
                    newIndex--;
                break;
            }
        }
    }
}