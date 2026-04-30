using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class StirckController : MonoBehaviour
{
    private Transform Stick;
    public Camera maincamera;

    Vector3 lastPositionsenser;
    void handleMouseInput()
    {
        Vector3 mousePos = maincamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = Stick.position.z;

        Vector3 dir = mousePos - Stick.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Stick.rotation = Quaternion.Euler(0f, 0f, angle);
/*
        if (Input.GetMouseButtonDown(0))
        {
            lastPositionsenser = GetMouseWorldPosition();
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = GetMouseWorldPosition();

            Vector3 lastDirection = lastPositionsenser - Stick.position;
            Vector3 currentDirection = currentMousePosition - Stick.position;

            float angle = Vector3.SignedAngle(lastDirection, currentDirection, Vector3.forward);

            Stick.Rotate(Vector3.forward,angle * 2,Space.World);

            lastPositionsenser = currentMousePosition;
        }*/

    }
  /*  Vector3 GetMouseWorldPosition()
    {
        Ray ray = maincamera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up,Stick.position);

        if (plane.Raycast(ray,out float distance))
        {
            return ray.GetPoint(distance);
        }
        return Vector3.zero;
    }*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Stick = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        handleMouseInput();
    }
}
