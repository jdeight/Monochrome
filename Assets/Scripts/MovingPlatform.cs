using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 pointA;
    [SerializeField] private Vector3 pointB;

    [SerializeField] private float speed;

    private void Start()
    {
        pointA = gameObject.transform.localPosition;
    }

    private void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        gameObject.transform.localPosition = Vector3.Lerp(pointA, pointB, time);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }
}
