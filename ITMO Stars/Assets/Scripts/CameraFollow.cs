using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform newTrans;
    private Vector3 newPosition;
    Transform pos => GetComponent<Transform>();

    void Update()
    {
        newPosition = newTrans.position;
        newPosition.z = pos.position.z;
        pos.position = newPosition;
    }
}
