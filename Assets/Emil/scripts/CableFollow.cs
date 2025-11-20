using UnityEngine;

public class CableFollow : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        if (lr == null) Debug.LogError("[CableFollow] Kein LineRenderer am Objekt!");
    }

    void Update()
    {
        if (lr == null || pointA == null || pointB == null) return;
        lr.SetPosition(0, pointA.position);
        lr.SetPosition(1, pointB.position);
    }
}
