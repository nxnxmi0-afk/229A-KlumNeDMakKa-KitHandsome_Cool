using System;
using Unity.Multiplayer.PlayMode;
using UnityEngine;
using UnityEngine.UI;

public class StirckController : MonoBehaviour
{
    
    public Camera maincamera;

    float Sliderhitforce,StickhitSpeed;

    [NonSerialized]public Transform stick;
    Rigidbody2D rb;

    float pullAmount = 0f;
    float maxPull = 10f;
    Vector3 startPos;




    void handleMouseInput()
    {
        if (!Input.GetKey(KeyCode.Space))
        {
            Vector3 mousePos = maincamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = stick.position.z;

            Vector3 dir = mousePos - stick.position;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
      
        
            stick.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
    }
    void change()
    {
        {
            if (Input.GetKey(KeyCode.Space))
            {
                pullAmount += Time.deltaTime * 6f;
                pullAmount = Mathf.Clamp(pullAmount, 0, maxPull);

                // ง้างจากตำแหน่งเดิม
                stick.localPosition = startPos - stick.up * pullAmount;
            }
            else
            {
                // กลับไปตำแหน่งเดิม
                stick.localPosition = Vector3.Lerp(stick.localPosition, startPos, Time.deltaTime * 10f);
            }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stick = GetComponent<Transform>();
        rb.gravityScale = 0;
        startPos = stick.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        handleMouseInput();
        change();
/*        stick.position = ball.position;
*/    }
}
