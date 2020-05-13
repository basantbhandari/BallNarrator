using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject restartButton;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        restartButton.SetActive(true);
    }


    public void Restart() {
        SceneManager.LoadScene("Main");
    }


}
