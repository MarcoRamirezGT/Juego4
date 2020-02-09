using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionManagerS2 : MonoBehaviour
{
    [SerializeField] private string selectableTag = "objetivos";
    [SerializeField] private Material MaterialPrincipal;
    [SerializeField] private Material MaterialAnterior;
    public float rango = 10f;
   // public float fuerza = 4;
    public GameObject effecto;
    public Text scoreText;
    private int count;

    private Transform _selection;
    private void Start()
    {
        count = 0;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        if (_selection != null)
        {
            var seleccionado = _selection.GetComponent<Renderer>();
            seleccionado.material = MaterialAnterior;
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selec = hit.transform;
            if (selec.CompareTag(selectableTag))
            {
                var selectionRenderer = selec.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = MaterialPrincipal;
                }

                _selection = selec;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, rango))
            {
                GameObject _effect = Instantiate(effecto, hit.point, Quaternion.identity);
                Destroy(_effect, 0.5f);


                if (hit.collider.GetComponent<Rigidbody>() != null)
                {
                    Destroy(hit.transform.gameObject);
                   
                    scoreText.text = "Objetos eliminados: " + ++count;

                }
            }

        }

    }
}