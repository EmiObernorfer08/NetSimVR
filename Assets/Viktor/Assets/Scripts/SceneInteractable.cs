using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRaycastLoader : MonoBehaviour
{
    public float interactDistance = 3f;
    public KeyCode interactKey = KeyCode.Mouse0;
    public LayerMask interactLayer = ~0; // alle Layer
    public string requiredTag = "SceneCube";
    public string sceneToLoad = "CLI_Scene";

    void Update()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("[SceneRaycastLoader] Keine Camera mit Tag MainCamera gefunden!");
            return;
        }

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.green);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
        {
            // nur reagieren bei Taste (wie bei dir)
            if (Input.GetKeyDown(interactKey))
            {
                Debug.Log("[SceneRaycastLoader] Getroffen: " + hit.collider.name + " Tag=" + hit.collider.tag);

                if (hit.collider.CompareTag(requiredTag))
                {
                    Debug.Log("[SceneRaycastLoader] Lade Scene: " + sceneToLoad);
                    SceneManager.LoadScene(sceneToLoad);
                }
                else
                {
                    Debug.Log("[SceneRaycastLoader] Getroffenes Objekt hat nicht den Tag: " + requiredTag);
                }
            }
        }
    }
}
