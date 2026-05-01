using System;
using Unity.Multiplayer.PlayMode;
using UnityEngine;
using UnityEngine.UI;

public class StirckController : MonoBehaviour
{
    public Rigidbody2D ballRb;
    public Camera maincamera;
    SpriteRenderer sr;
    float Sliderhitforce, StickhitSpeed;

    [NonSerialized] public Transform stick;
    Rigidbody2D rb;

    float pullAmount = 0f;
    float maxPull = 10f;
    Vector3 startPos;
    [NonSerialized]public GameObject otherStick1;
    [NonSerialized] public GameObject otherStick2;
    [NonSerialized] public GameObject otherStick3;
    [NonSerialized] public GameObject otherStick4;
    bool isSelectingStick = false;




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

        if (Input.GetKey(KeyCode.Space))
        {
            pullAmount += Time.deltaTime * 10f;
            pullAmount = Mathf.Clamp(pullAmount, 0, maxPull);

            // ง้างจากตำแหน่งเดิม
            stick.localPosition = startPos - stick.up * pullAmount;
        }
        else
        {
            // กลับไปตำแหน่งเดิม
            stick.localPosition = Vector3.Lerp(stick.localPosition, startPos, Time.deltaTime * 10f);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Vector2 dir = stick.up;

            float power = pullAmount / maxPull;
            float force = power * 15f;

            ballRb.AddForce(dir * force, ForceMode2D.Impulse);

            pullAmount = 0f;
            moving();
        }



    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stick = GetComponent<Transform>();
        rb.gravityScale = 0;
        startPos = stick.localPosition;
        sr = GetComponent<SpriteRenderer>();
        otherStick1 = GameObject.Find("Stick1");
        otherStick2 = GameObject.Find("Stick2");
        otherStick3 = GameObject.Find("Stick3");
        otherStick4 = GameObject.Find("Stick4");
        sr.sortingOrder = 0;

    }
    void SelectStick(GameObject selected)
    {
        sr.sortingOrder = 1;
        if (ballRb.velocity.magnitude >= 1f) return;

        isSelectingStick = true;

        otherStick1.SetActive(false);
        otherStick2.SetActive(false);
        otherStick3.SetActive(false);
        otherStick4.SetActive(false);

            selected.SetActive(true);

         if (ballRb.velocity.sqrMagnitude > 0.05f)
        {
            sr.sortingOrder = 0;
        }
        else
        {
            sr.sortingOrder = 1;
        }

        
    }
    void moving()
    {
        if (ballRb.velocity.sqrMagnitude > 0.05f)
        {
            sr.sortingOrder = 0;
        }
        else
        {
            sr.sortingOrder = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        


        if (!isSelectingStick)
        {
            handleMouseInput();
            change();
            
        }
       
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SelectStick(otherStick1);
            isSelectingStick = false;
            moving();

        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            SelectStick(otherStick2);
            isSelectingStick = false;
            moving();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SelectStick(otherStick3);
            isSelectingStick = false;
            moving();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            SelectStick(otherStick4);
            isSelectingStick = false;
            moving();
        }



    }
}
