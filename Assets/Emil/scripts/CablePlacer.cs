using UnityEngine;

public class CablePlacer : MonoBehaviour
{
    public GameObject cablePrefab;
    public float interactDistance = 3f;
    public KeyCode placeKey = KeyCode.E;
    public LayerMask interactLayer = ~0; // default: alle Layer

    private Transform firstPoint = null;

    void Update()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("[CablePlacer] Keine Camera mit Tag MainCamera gefunden!");
            return;
        }

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.green);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
        {
            // Zeige was getroffen wurde
            Debug.Log("[CablePlacer] Geklickt: " + hit.collider.name + " Tag=" + hit.collider.tag);

            // nur reagieren bei Taste E
            if (Input.GetKeyDown(placeKey))
            {
                if (hit.collider.CompareTag("CablePort"))
                {
                    SelectPoint(hit.collider.transform);
                }
                else
                {
                    Debug.Log("[CablePlacer] Getroffenes Objekt ist kein CablePort (Tag fehlt?).");
                }
            }
        }

        // Optional: Abbrechen mit Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            firstPoint = null;
            Debug.Log("[CablePlacer] Auswahl zurückgesetzt.");
        }
    }

    void SelectPoint(Transform port)
    {
        if (firstPoint == null)
        {
            firstPoint = port;
            Debug.Log("[CablePlacer] Punkt A gesetzt: " + port.name);
        }
        else
        {
            Debug.Log("[CablePlacer] Punkt B gesetzt: " + port.name + " -> Erstelle Kabel");
            CreateCable(firstPoint, port);
            firstPoint = null;
        }
    }

    void CreateCable(Transform a, Transform b)
    {
        if (cablePrefab == null)
        {
            Debug.LogError("[CablePlacer] cablePrefab ist nicht gesetzt!");
            return;
        }

        GameObject cable = Instantiate(cablePrefab);
        LineRenderer lr = cable.GetComponent<LineRenderer>();
        if (lr == null)
        {
            Debug.LogError("[CablePlacer] Das Prefab hat keinen LineRenderer!");
            Destroy(cable);
            return;
        }

        lr.positionCount = 2;
        lr.SetPosition(0, a.position);
        lr.SetPosition(1, b.position);

        // Falls Ports sich bewegen sollen:
        CableFollow follow = cable.AddComponent<CableFollow>();
        follow.pointA = a;
        follow.pointB = b;

        Debug.Log("[CablePlacer] Kabel erstellt zwischen " + a.name + " und " + b.name);
    }
}
