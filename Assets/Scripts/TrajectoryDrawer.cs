using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrajectoryDrawer : MonoBehaviour
{
    [Range(0, 50)]
    public int _segments = 50;
    LineRenderer line;

    private void Awake()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.positionCount = _segments + 1;
    }

    public void CreatePoints(float radius)
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (_segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i, new Vector3(x, 0, y));

            angle += (360f / _segments);
        }
    }
}
