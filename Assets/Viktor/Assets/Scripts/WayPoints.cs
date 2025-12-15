using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public Transform startPort;
    public Transform endPort;
    public Transform[] waypoints;
    public LineRenderer line;

    void Update()
    {
        line.positionCount = waypoints.Length + 2;

        line.SetPosition(0, startPort.position);

        for (int i = 0; i < waypoints.Length; i++)
        {
            line.SetPosition(i + 1, waypoints[i].position);
        }

        line.SetPosition(line.positionCount - 1, endPort.position);
}

}
