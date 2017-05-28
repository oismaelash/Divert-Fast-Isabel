using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    private static UiManager m_UiManager;
    public static UiManager Instance
    {
        get
        {
            if(m_UiManager == null)
            {
                m_UiManager = new UiManager();
            }

            return m_UiManager;
        }
    }

    [SerializeField]
    private GameObject      m_PanelGameOver;
    public AudioSource      audioGameplay;
    [SerializeField]
    private SpriteRenderer m_Background;
    [SerializeField]
    private SpriteRenderer m_Ground;
    [SerializeField]
    private Sprite[] m_Backgrounds;
    [SerializeField]
    private Sprite[] m_Grounds;


    void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Gameplay"))
        {
            m_PanelGameOver.SetActive(false);
        }

        if (SceneManager.GetActiveScene().name.Equals("Gameplay"))
        {
            LevelDesign();
        }
        
    }

    void FixedUpdate()
    {
        if (PlayerManager.m_PlayerDead && SceneManager.GetActiveScene().name.Equals("Gameplay"))
        {
            m_PanelGameOver.SetActive(true);
            audioGameplay.Stop();
        }
    }

    public void RestartGameplay()
    {
        PlayerManager.m_PointsHits = 0;
        //LevelDesign();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ButtonSetup()
    {

    }

    public void ReturnScene(string scene)
    {
        PlayerManager.m_PointsHits = 0;
        SceneManager.LoadScene(scene);
    }

    public void ButtonRaking()
    {

    }

    public void ActivePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    private void LevelDesign()
    {
        int levelDesign = Random.Range(0, m_Backgrounds.Length);

        m_Background.sprite = m_Backgrounds[levelDesign];
        m_Ground.sprite = m_Grounds[levelDesign];
    }
}
