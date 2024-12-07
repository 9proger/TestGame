using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] int Levels;
    [SerializeField] Button lvl;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        if (Levels - 1 <= PlayerPrefs.GetInt("Levelcomplete"))
        {
            lvl.interactable = true;
        }
        //Debug.Log(PlayerPrefs.GetInt("Levelcomplete").ToString());
    }

    // Update is called once per frame
    public void Level()
    {
        SceneManager.LoadScene(Levels + 1);
    }

    //public void Level2()
    //{
    //    SceneManager.LoadScene(3);
    //}
}
