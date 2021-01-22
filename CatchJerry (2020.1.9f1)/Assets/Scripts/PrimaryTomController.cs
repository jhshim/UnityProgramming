using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PrimaryTomController : MonoBehaviour
{
    public GameObject secondaryTomUp;
    public GameObject secondaryTomLeft;
    public GameObject secondaryTomRight;
    public Camera camera;
    Vector2 speedVec;

    public float speed;
    float MinX;
    float MaxX;
    float MinY;
    float MaxY;

    private Vector3 screenPoint;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        float camera_height = 2 * camera.orthographicSize;
        float camera_width = camera_height * camera.aspect;

        MinX = (camera_width / 2) * -1;
        MaxX = camera_width / 2;
        MinY = (camera_height / 2) * -1;
        MaxY = camera_height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        secondaryTomUp.transform.position = new Vector3(this.gameObject.transform.position.x * -1, secondaryTomUp.transform.position.y, 0.0f);
        secondaryTomLeft.transform.position = new Vector3(secondaryTomLeft.transform.position.x, XToY(this.gameObject.transform.position.x), 0.0f);
        secondaryTomRight.transform.position = new Vector3(secondaryTomRight.transform.position.x, XToY(this.gameObject.transform.position.x) * -1, 0.0f);
    }

    float XToY(float x)
    {
        return x * MaxY / MaxX;
    }

    void OnMouseDown()
    {
        if (!GameController.gameEnd)
        {
            screenPoint = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
            offset = this.gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, this.gameObject.transform.position.y, 0.0f));
        }
    }

    void OnMouseDrag()
    {
        if (!GameController.gameEnd)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, this.gameObject.transform.position.y, 0.0f);

            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
        }
    }
}
