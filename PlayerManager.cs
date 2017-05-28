using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private Text            m_PointText;
    [SerializeField]
    private Text            m_Highscoretext;
    [SerializeField]
    private Rigidbody2D     m_PlayerRB2d;
    [SerializeField]
    private float           m_Velocity;

    public static int       m_PointsHits = 0;
    public static bool      m_PlayerDead;
    public static int       m_Highscore;

    void Start()
    {
        m_PlayerDead = false;
        m_PlayerRB2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1") && !m_PlayerDead) // HERE
        {
            MovimentPlayer(-1f);
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        }

        m_PlayerRB2d.velocity = new Vector2(m_Velocity, m_PlayerRB2d.velocity.y);
        m_PointText.text = m_PointsHits.ToString();
    }

    private void MovimentPlayer(float speed)
    {
        m_Velocity *= speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("stone"))
        {
            PlayerDead();
        }
        else if (collision.gameObject.tag.Equals("mushroomVelocity"))
        {
            //Debug.Log("Ganhou pontos !");
        }
        else if (collision.gameObject.tag.Equals("mushroomScale"))
        {
            //Debug.Log("Ganhou pontos !");
        }
        else if (collision.gameObject.tag.Equals("mushroomProtection"))
        {
            //Debug.Log("Ganhou pontos !");
        }
    }

    private void PlayerDead()
    {
        GameObject[] stones = GameObject.FindGameObjectsWithTag("stone");

        foreach (GameObject stone in stones)
        {
            Destroy(stone.gameObject);
        }

        m_PlayerDead = true;
        m_Velocity = 0;
        GetComponent<Animator>().Play("Dead");

        if (m_PointsHits > PlayerPrefs.GetInt("highscore", m_Highscore))
        {
            m_Highscore = m_PointsHits;
            PlayerPrefs.SetInt("highscore", m_Highscore);
        }

        m_Highscore = PlayerPrefs.GetInt("highscore", m_Highscore);

        m_Highscoretext.text = "recorde: " + "\n\n" + PlayerPrefs.GetInt("highscore", m_Highscore);
        print("Highscore current:: " + m_Highscore);
        // Chamar propaganda
        ShowAds();
    }

    // Methods of ADS
    public void ShowAds()
    {
        //Advertisement.Show();
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                //Debug.Log("The ad was successfully shown.");
                break;
            case ShowResult.Skipped:
                //Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                //Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
