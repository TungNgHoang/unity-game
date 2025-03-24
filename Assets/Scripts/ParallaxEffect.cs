using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;
    // Starting position for the parallax game object
    Vector2 startingPosition;
    // Start Z value of the parallax game object
    float startingZ;
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - (Vector2)startingPosition;
    float zDistanceFromTarget => followTarget.position.z - followTarget.transform.position.z;
    float clippingPlace => (cam.transform.position.z + (zDistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    float parallaxFactor => Mathf.Abs(zDistanceFromTarget) / clippingPlace;
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = startingPosition + (Vector2)camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
