using UnityEngine;

public class CablePlacer : MonoBehaviour
{
    public GameObject cablePrefab;
    public float interactDistance = 3f;
    public KeyCode placeKey = KeyCode.E;

    private Transform firstPoint = null;

    void Update()
    {
        // Mit Raycast ermitteln, was der Spieler ansieht
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            // Prüfen ob es ein Port ist
            if (hit.collider.CompareTag("CablePort"))
            {
                if (Input.GetKeyDown(placeKey))
                {
                    SelectPoint(hit.collider.transform);
                }
            }
        }
    }

    void SelectPoint(Transform port)
    {
        if (firstPoint == null)
        {
            // Erstes Ende gesetzt
            firstPoint = port;
        }
        else
        {
            // Zweites Ende gewählt → Kabel erzeugen
            CreateCable(firstPoint, port);
            firstPoint = null;
        }
    }

    void CreateCable(Transform a, Transform b)
    {
        GameObject cable = Instantiate(cablePrefab);

        LineRenderer lr = cable.GetComponent<LineRenderer>();
        lr.positionCount = 2;

        // Anfangs setzen
        lr.SetPosition(0, a.position);
        lr.SetPosition(1, b.position);

        // Damit das Kabel live folgt, falls sich Ports bewegen
        CableFollow follow = cable.AddComponent<CableFollow>();
        follow.pointA = a;
        follow.pointB = b;
    }
}