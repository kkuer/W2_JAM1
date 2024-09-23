using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

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

    public Volume ppfxVolume;
    ChromaticAberration ca;
    LensDistortion ld;

    public bool direction = true;

    public Image indicator;

    private float slowRotation = -50f;
    private float mediumRotation = -18f;
    private float fastRotation = 40f;

    public ParticleSystem fastParticles;
    public ParticleSystem mediumParticles;

    public ScreenShake shake;

    public AudioSource speedUp;

    private void Start()
    {
        ppfxVolume.profile.TryGet(out ca);
        ppfxVolume.profile.TryGet(out ld);
    }

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
            shake.TriggerShake();
            speedUp.Play();
        }
        if (Input.GetKeyDown(KeyCode.S) && speed > 1)
        {
            speed--;
            shake.TriggerShake();
            speedUp.Play();
        }
        if (speed == 1)
        {
            arrowsLeft.SetVector("_Direction", new Vector2(0.16f, 0));
            arrowsRight.SetVector("_Direction", new Vector2(-0.16f, 0));

            arrowsLeft.SetColor("_Color", slow);
            arrowsRight.SetColor("_Color", slow);

            ca.intensity.value = 0.05f;
            ld.intensity.value = 0f;

            indicator.rectTransform.rotation = Quaternion.Euler(0, 0, slowRotation);

            if (mediumParticles.isPlaying) 
            {
                mediumParticles.Stop();
            }
        }
        else if (speed == 2)
        {
            arrowsLeft.SetVector("_Direction", new Vector2(0.32f, 0));
            arrowsRight.SetVector("_Direction", new Vector2(-0.32f, 0));

            arrowsLeft.SetColor("_Color", medium);
            arrowsRight.SetColor("_Color", medium);

            ca.intensity.value = 0.2f;
            ld.intensity.value = -0.25f;

            indicator.rectTransform.rotation = Quaternion.Euler(0, 0, mediumRotation);

            if (!mediumParticles.isPlaying)
            {
                mediumParticles.Play();
            }
            if (fastParticles.isPlaying) 
            {
                fastParticles.Stop();
            }
            
        }
        else if (speed == 3)
        {
            arrowsLeft.SetVector("_Direction", new Vector2(0.5f, 0));
            arrowsRight.SetVector("_Direction", new Vector2(-0.5f, 0));

            arrowsLeft.SetColor("_Color", fast);
            arrowsRight.SetColor("_Color", fast);

            ca.intensity.value = 0.5f;
            ld.intensity.value = -0.4f;

            indicator.rectTransform.rotation = Quaternion.Euler(0, 0, fastRotation);

            if (mediumParticles.isPlaying)
            {
                mediumParticles.Stop();
            }
            if (!fastParticles.isPlaying)
            {
                fastParticles.Play();
            }
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
