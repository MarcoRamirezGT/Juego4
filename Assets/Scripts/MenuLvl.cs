using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLvl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Destrolvl()
    {
        SceneManager.LoadScene("Destruir");
        Time.timeScale = 1f;

    }
    public void Force()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;

    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;

    }
}
