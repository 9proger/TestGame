using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] GameObject BCont;
    [SerializeField] GameObject BMenu;
    [SerializeField] GameObject BResp;
    [SerializeField] GameObject BNext;
    [SerializeField] GameObject Background;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        BCont.SetActive(false);
        BResp.SetActive(false);
        BMenu.SetActive(false);
        BNext.SetActive(false);
        Background.SetActive(false);

    }

    // Update is called once per frame
    public void Pause()
    {
        BCont.SetActive(true);
        BResp.SetActive(true);
        BMenu.SetActive(true);
        Background.SetActive(true);
        Time.timeScale = 0;
    }

    public void Respawn()
    {
        BCont.SetActive(false);
        BResp.SetActive(false);
        BMenu.SetActive(false);
        BNext.SetActive(false);
        Background.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Continue()
    {
        BCont.SetActive(false);
        BResp.SetActive(false);
        BMenu.SetActive(false);
        Background.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        BCont.SetActive(false);
        BResp.SetActive(false);
        BMenu.SetActive(false);
        BNext.SetActive(false);
        Background.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    //public void Dead()
    //{
        //BCont.SetActive(false);
    //    BResp.SetActive(false);
    //    BMenu.SetActive(false);
    //    Time.timeScale = 0;
    //}

    public void Finish()
    {
        //BCont.SetActive(false);
        BNext.SetActive(true);
        BResp.SetActive(true);
        BMenu.SetActive(true);
        Background.SetActive(true);
        Time.timeScale = 0;
    }

    public void NextLevel()
    {
        BCont.SetActive(false);
        BNext.SetActive(false);
        BResp.SetActive(false);
        BMenu.SetActive(false);
        Background.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LastLevel()
    {
        BCont.SetActive(false);
        BResp.SetActive(false);
        BMenu.SetActive(false);
        BNext.SetActive(false);
        Background.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
