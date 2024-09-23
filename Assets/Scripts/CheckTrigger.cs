using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckTriggerMAIL : MonoBehaviour
{
    public bool isMailbox;

    public ParticleSystem winParticles;
    public ParticleSystem FireParticles;

    public GameLoop loop;

    public AudioSource correct;
    public AudioSource wrong;

    private void OnTriggerEnter(Collider other)
    {
        if (isMailbox)
        {
            if (other.tag == "box")
            {
                loop.updateScore(10);
                Destroy(other.gameObject);
                winParticles.Play();
                correct.Play();
            }
            else if (other.tag == "box_2x")
            {
                loop.updateScore(20);
                Destroy(other.gameObject);
                winParticles.Play();
                correct.Play();
            }
            else if (other.tag == "box_3x")
            {
                loop.updateScore(30);
                Destroy(other.gameObject);
                winParticles.Play();
                correct.Play();
            }
            else if (other.tag == "box_0.5x")
            {
                loop.updateScore(5);
                Destroy(other.gameObject);
                winParticles.Play();
                correct.Play();
            }
            else if (other.tag == "trash")
            {
                loop.updateScore(-15);
                wrong.Play();
                Destroy(other.gameObject);
            }
            
        }
        else if(!isMailbox)
        {
            if (other.tag == "box")
            {
                loop.updateScore(-10);
                Destroy(other.gameObject);
                FireParticles.Play();
                wrong.Play();
            }
            else if (other.tag == "box_2x")
            {
                loop.updateScore(-20);
                Destroy(other.gameObject);
                FireParticles.Play();
                wrong.Play();
            }
            else if (other.tag == "box_3x")
            {
                loop.updateScore(-30);
                Destroy(other.gameObject);
                FireParticles.Play();
                wrong.Play();
            }
            else if (other.tag == "box_0.5x")
            {
                loop.updateScore(-5);
                Destroy(other.gameObject);
                FireParticles.Play();
                wrong.Play();
            }
            else if (other.tag == "trash")
            {
                loop.updateScore(15);
                Destroy(other.gameObject);
                FireParticles.Play();
                correct.Play();
            }
        }
    }
}
