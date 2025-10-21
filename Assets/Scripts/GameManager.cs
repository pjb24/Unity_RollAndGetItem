using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public int _totalItemCount;

    [SerializeField] private UIDocument _uiDoc;

    private Label _playerItemText;
    private Label _stageItemText;

    private void Awake()
    {
        _totalItemCount = GameObject.FindGameObjectsWithTag("Item").Length;

        VisualElement root = _uiDoc.rootVisualElement;

        _playerItemText = root.Q<Label>("Player_Item_Text");
        _stageItemText = root.Q<Label>("Stage_Item_Text");

        _stageItemText.text = "/ " + _totalItemCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ChangeItemText(int itemCount)
    {
        _playerItemText.text = itemCount.ToString();
    }
}
