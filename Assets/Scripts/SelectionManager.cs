using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "objetivos";
    [SerializeField] private Material MaterialPrincipal;
    [SerializeField] private Material MaterialAnterior;
    public float rango = 10f;
    public float fuerza = 4;
    public GameObject effecto;

    private Transform _selection;

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
                    hit.collider.GetComponent<Rigidbody>().AddForce(hit.normal * fuerza);                }
            }

        }

    }
}