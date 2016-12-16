using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    [SerializeField]
    private Transform startPos;
    [SerializeField]
    private Transform endPos;
    [SerializeField]
    private Transform bird;

    private Camera camera;
    private float zoom = 1.5f;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        Vector3 newPosition = transform.position;
        if (newPosition.x != endPos.position.x)
        {
            newPosition.x = bird.position.x;
        }
        else
        {
            newPosition.x = endPos.position.x;
        }
        newPosition.x = Mathf.Clamp(newPosition.x, startPos.position.x, endPos.position.x);
        transform.position = newPosition;

        if(Projectile.cameraZoom == true && camera.orthographicSize <= 11)

        {
            camera.orthographicSize += zoom * Time.deltaTime;
        }
    }

    public static IEnumerator Zoom()
    {
        yield return new WaitForSeconds(1f);
    }
}
