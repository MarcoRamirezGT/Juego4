using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
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
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;

    }
    public void Level()
    {
        SceneManager.LoadScene("Levels");
        Time.timeScale = 1f;

    }
    public void Controles()
    {
        SceneManager.LoadScene("Controles");
        Time.timeScale = 1f;
    }
    public void Salir()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
