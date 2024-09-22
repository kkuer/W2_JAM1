using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerMove : MonoBehaviour
{
    public GameObject conveyer;
    public Transform endpoint1;
    public Transform endpoint2;
    public float speed;

    public MeshRenderer directionVisuals;

    public Material arrowsLeft;
    public Material arrowsRight;

    public Color slow;
    public Color medium;
    public Color fast;

    public bool direction = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = false;
            directionVisuals.material = arrowsLeft;
        }
        if (Input.GetKeyDown(KeyCode.D)) 
        { 
            direction = true;
            directionVisuals.material = arrowsRight;
        }
        if (Input.GetKeyDown(KeyCode.W) && speed < 3)
        {
            speed++;
        }
        if (Input.GetKeyDown(KeyCode.S) && speed > 1)
        {
            speed--;
        }
        if (speed == 1)
        {
            arrowsLeft.SetVector("_Direction", new Vector2(0.16f, 0));
            arrowsRight.SetVector("_Direction", new Vector2(-0.16f, 0));

            arrowsLeft.SetColor("_Color", slow);
            arrowsRight.SetColor("_Color", slow);
        }
        else if (speed == 2)
        {
            arrowsLeft.SetVector("_Direction", new Vector2(0.32f, 0));
            arrowsRight.SetVector("_Direction", new Vector2(-0.32f, 0));

            arrowsLeft.SetColor("_Color", medium);
            arrowsRight.SetColor("_Color", medium);
        }
        else if (speed == 3)
        {
            arrowsLeft.SetVector("_Direction", new Vector2(0.5f, 0));
            arrowsRight.SetVector("_Direction", new Vector2(-0.5f, 0));

            arrowsLeft.SetColor("_Color", fast);
            arrowsRight.SetColor("_Color", fast);
        }
        
    }
    private void OnTriggerStay(Collider item)
    {
        if (direction)
        {
            item.transform.position = Vector3.MoveTowards(item.transform.position, endpoint2.position, speed * Time.deltaTime);
        }
        else if (!direction)
        {
            item.transform.position = Vector3.MoveTowards(item.transform.position, endpoint1.position, speed * Time.deltaTime);
        }
    }
}
