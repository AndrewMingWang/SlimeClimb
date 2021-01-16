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

    private bool _stunned = false;

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
        if (transform.position.y > 80)
        {
            Vector3 pos = transform.position;
            pos.y = 0;
            transform.position = pos;  
        }
    }

    public void Stun()
    {
        StartCoroutine(Stunned());
    }
    
    IEnumerator Stunned()
    {
        _stunned = true;
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(1f);
        _stunned = false;
        GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
    }

    private void OnMouseDown()
    {
        if (!_stunned)
        {
            _pressLoc = Input.mousePosition;

            Arrow.SetActive(true);
        }
        Debug.Log("Clicked");
    }

    private void OnMouseDrag()
    {
        if (!_stunned)
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
            arrowBodyPos.x = 0.75f + 0.005f * magnitude * 2;
            arrowHeadPos.x = 1f + 0.005f * magnitude * 4;

            _arrowBody.localScale = arrowBodyScale;
            _arrowBody.localPosition = arrowBodyPos;
            _arrowHead.localPosition = arrowHeadPos;
        }
    }

    private void OnMouseUp()
    {
        if (!_stunned)
        {
            Debug.Log("Released");
            _releaseLoc = Input.mousePosition;

            Vector3 forceVector = 0.5f * new Vector3(-_drag_vector.x, -_drag_vector.y, 0);
            Debug.Log(forceVector);
            GetComponent<Rigidbody>().AddForce(forceVector, ForceMode.VelocityChange);

            Arrow.SetActive(false);
        }
    }
}
