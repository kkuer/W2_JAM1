using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamMovement : MonoBehaviour
{
    public float camPos = 1f;

    public GameObject cam;

    public GameObject rightButton;
    public GameObject leftButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camPos == 3f)
        {
            rightButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
        }

        if (camPos == 1f)
        {
            leftButton.SetActive(false);
        }
        else
        {
            leftButton.SetActive(true);
        }
    }

    public void moveCamRight()
    {
        if (camPos < 3f)
        {
            camPos += 1;
            cam.transform.Rotate(0, 90, 0);
        }
    }
    public void moveCamLeft()
    {
        if (camPos > 1f)
        {
            camPos -= 1;
            cam.transform.Rotate(0, -90, 0);
        }
    }
}
