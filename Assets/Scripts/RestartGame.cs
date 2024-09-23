using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{
    public Image restartImage;

    public void onClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnMouseOver()
    {
        restartImage.rectTransform.sizeDelta = new Vector2(120, 120);
    }

    void OnMouseExit()
    {
        restartImage.rectTransform.sizeDelta = new Vector2(100, 100);
    }
}
