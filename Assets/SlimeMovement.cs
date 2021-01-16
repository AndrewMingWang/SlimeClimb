using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    private Vector2 _pressLoc;
    private Vector2 _heldLoc;
    private Vector2 _releaseLoc;

    public GameObject Arrow;
    public Camera Camera;
    private Transform _arrowBody;
    private Transform _arrowHead;

    private Vector2 _drag_vector;

    private void Awake()
    {
        _arrowBody = Arrow.transform.GetChild(0);
        _arrowHead = Arrow.transform.GetChild(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        _pressLoc = Input.mousePosition;

        Arrow.SetActive(true);
    }

    private void OnMouseDrag()
    {
        _heldLoc = Input.mousePosition;
        _drag_vector = _heldLoc - _pressLoc;


        float angle = -Vector2.SignedAngle(_drag_vector, new Vector2(-1, 0));
        float magnitude = Mathf.Sqrt(Vector2.SqrMagnitude(_drag_vector));

        magnitude = Mathf.Clamp(magnitude, 25, 100);

        Arrow.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Vector3 arrowBodyScale = _arrowBody.localScale;
        Vector3 arrowBodyPos = _arrowBody.localPosition;
        Vector3 arrowHeadPos = _arrowHead.localPosition;

        arrowBodyScale.x = 0.005f * magnitude;
        arrowBodyPos.x = 1.5f / 2 + 0.005f * magnitude * 2;
        arrowHeadPos.x = 2.5f / 2 + 0.005f * magnitude * 4;

        _arrowBody.localScale = arrowBodyScale;
        _arrowBody.localPosition = arrowBodyPos;
        _arrowHead.localPosition = arrowHeadPos;
       
    }

    private void OnMouseUp()
    {
        Debug.Log("Released");
        _releaseLoc = Input.mousePosition;

        Vector3 forceVector = 0.5f * new Vector3(-_drag_vector.x, -_drag_vector.y, 0);
        Debug.Log(forceVector);
        GetComponent<Rigidbody>().AddForce(forceVector, ForceMode.VelocityChange);

        Arrow.SetActive(false);
    }
}
