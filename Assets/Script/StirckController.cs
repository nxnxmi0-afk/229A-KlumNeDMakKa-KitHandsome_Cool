using Unity.Multiplayer.PlayMode;
using UnityEngine;
using UnityEngine.UI;

public class StirckController : MonoBehaviour
{
    private Transform Stick;
    public Camera maincamera;

    float hitforce;
    float Sliderhitforce;

    
    Slider forceSlider;

    public void OnSliderValueChange()
    {
        Sliderhitforce = hitforce * forceSlider.value; 
    }
       void handleMouseInput()
    {
        Vector3 mousePos = maincamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = Stick.position.z;

        Vector3 dir = mousePos - Stick.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Stick.rotation = Quaternion.Euler(0f, 0f, angle);
    }
       
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
