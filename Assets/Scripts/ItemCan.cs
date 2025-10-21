using UnityEngine;

public class ItemCan : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    void Update()
    {
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime, Space.World);
    }
}
