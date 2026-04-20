using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject StylePopup;

    [Space]

    public GameSettings[] PossibleStyles;
    public GameSettings ChosenStyle;

    [Space]
    public GameSettings FallbackStyle;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StyleUI.OnClickStyle += OnStyleButtonClick;
    }

    private void OnDestroy()
    {
        StyleUI.OnClickStyle += OnStyleButtonClick;
    }

    private void OnStyleButtonClick(int style) 
    {
        ChosenStyle = PossibleStyles[style];
    }

    public void ShowStylePopup() 
    {
        StylePopup.SetActive(true);
    }

    public void LoadGameplayScene() 
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void ReloadScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}