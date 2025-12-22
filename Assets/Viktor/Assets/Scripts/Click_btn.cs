using UnityEngine;

public class SimpleClickRaycast : MonoBehaviour
{
    [Header("Einstellungen")]
    public Camera playerCamera;         // hier deine FPS-Kamera reinziehen
    public float interactDistance = 3f; // wie weit du "klicken" kannst
    public LayerMask interactLayer = ~0; // standard: alles

    void Awake()
    {
        // Falls du es im Inspector vergisst
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        // 1. Wurde linke Maustaste gedrückt?
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("[Click] Linksklick registriert");

            if (playerCamera == null)
            {
                Debug.LogError("[Click] Keine Kamera gesetzt!");
                return;
            }

            // 2. Ray aus Bildschirmmitte (Fadenkreuz)
            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f);
            Ray ray = playerCamera.ScreenPointToRay(screenCenter);

            Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.green, 1f);

            // 3. Raycast
            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
            {
                Debug.Log("[Click] Getroffen: " + hit.collider.name +
                          " (Layer: " + LayerMask.LayerToName(hit.collider.gameObject.layer) + ")");
                
                // Beispiel: Button-Script auf dem Objekt aufrufen
                // SimpleButton btn = hit.collider.GetComponent<SimpleButton>();
                // if (btn != null) btn.OnClick();
            }
            else
            {
                Debug.Log("[Click] Raycast hat NICHTS getroffen.");
            }
        }
    }
}
