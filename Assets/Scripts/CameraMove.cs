using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private Vector3 _offset;

    private void Awake()
    {
        _offset = transform.position - _player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _player.transform.position + _offset;
    }
}
