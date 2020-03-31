using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlGame :MonoBehaviour
{
    public Button pause;
    public Button close;
    public Button reboot;
    public Button reboot2;
    public Button closeSubMenu;
    public Button continueB;
    public GameObject _settings;
    public GameObject _menu;
    public GameObject _winLevel;
    public GameObject _scoreIndicator;

    public Text score2;
    public Text bonus2;
 

    public static bool pauseState;



    void Start()
    {
       //_settings = GameObject.Find("SettingsPanel");
        _settings.SetActive(false);
        _menu.SetActive(false);
        _winLevel.SetActive(false);
        reboot = reboot.GetComponent<Button>();
        reboot.onClick.AddListener(rebootAction);
        reboot2 = reboot2.GetComponent<Button>();
        reboot2.onClick.AddListener(rebootAction);
        continueB = continueB.GetComponent<Button>();
        continueB.onClick.AddListener(closeSubMenuAction);
        pause = pause.GetComponent<Button>();
        pause.onClick.AddListener(pauseAction);
        close = close.GetComponent<Button>();
        close.onClick.AddListener(closeAction);
        closeSubMenu = closeSubMenu.GetComponent<Button>();
        closeSubMenu.onClick.AddListener(closeSubMenuAction);
        Time.timeScale =1f;
        pauseState = false;
        score2.text = "" + GM.winStreak;
       
        bonus2.text = "" + GM.winBonus;

    }

    void Update()
    {
        if (GM.winStreak > 40) {
            _winLevel.SetActive(true);
            _menu.SetActive(false);
            Time.timeScale = 0.0f;
            score2.text = "" + GM.winStreak;
            bonus2.text = "" + GM.winBonus;
        }   
    }

    void  pauseAction()
    {
        Debug.Log("You have clicked the button!");
        _menu.SetActive(true);
        Time.timeScale = 0.0f;
        pause.gameObject.SetActive(false);
        close.gameObject.SetActive(false);
        pauseState = true;
       


    }

    void closeAction()
    {
        Debug.Log("You have clicked the close");
       Time.timeScale = 1.0f;
        _menu.SetActive(false);
        pause.gameObject.SetActive(false);
        close.gameObject.SetActive(false);
        pauseState = false;


    }

    void closeSubMenuAction()
    {
        Debug.Log("You have clicked the close");
        Time.timeScale = 1.0f;
        _menu.SetActive(false);
        _settings.SetActive(false);
        _winLevel.SetActive(false);
        pause.gameObject.SetActive(true);
        close.gameObject.SetActive(true);
        pauseState = false;


    }
    void rebootAction()
    {
        _winLevel.SetActive(false);
        GM.winStreak = 0;
        pauseState = false;
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );


    }
}