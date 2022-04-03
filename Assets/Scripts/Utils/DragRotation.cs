using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragRotation : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject obj;
    private GameObject root;
    private Vector3 lastAngle_;

    private void Start() {
        root = new GameObject();
        root.transform.position = obj.transform.position;
        obj.transform.SetParent(root.transform);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        root.transform.eulerAngles += new Vector3(eventData.delta.y, -eventData.delta.x);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        obj.transform.parent = null;
        root.transform.eulerAngles = Vector3.zero;
        obj.transform.SetParent(root.transform);

    }
}
