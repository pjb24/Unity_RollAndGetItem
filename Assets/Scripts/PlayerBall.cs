using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerBall : MonoBehaviour
{
    private Rigidbody _rigid;
    private Vector2 _inputVec = Vector2.zero;
    private bool _isJump = false;

    private AudioSource _audio;
    private int _itemCount = 0;

    [SerializeField] private float _jumpPower = 10;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        _rigid.AddForce(new Vector3(_inputVec.x, 0, _inputVec.y), ForceMode.Impulse);
    }

    void OnMove(InputValue value)
    {
        _inputVec = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!_isJump)
        {
            _rigid.AddForce(new Vector3(0, _jumpPower, 0), ForceMode.Impulse);
            _isJump = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            _isJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            AddItemCount();

            _audio.Play();

            other.gameObject.SetActive(false);

            _gameManager.ChangeItemText(_itemCount);
        }

        if (other.tag == "Finish")
        {
            if (_gameManager._totalItemCount == _itemCount)
            {
                if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
                {
                    //Game Clear
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    SceneManager.LoadScene(0);
                }
            }
            else
            {
                //Restart...
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void AddItemCount()
    {
        _itemCount++;
    }
}
