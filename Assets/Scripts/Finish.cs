using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    //[SerializeField] private GameObject panelwin;
    [SerializeField] ButtonController panelwin;
    [SerializeField] PlayerMovement LevelsCheck;
    //int levelComplete;
    //private int levelcomplete = 0;
    int levelcomplete;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player") {
            //panelwin.SetActive (true);
            levelcomplete = PlayerPrefs.GetInt("Levelcomplete", 0);
            //Debug.Log(levelcomplete.ToString());
            //_body.AddForceX(10);
            if (SceneManager.GetActiveScene().buildIndex - 1 >= levelcomplete)
            {
                levelcomplete = SceneManager.GetActiveScene().buildIndex - 1;
                //_body.AddForceX(10);
            }
            PlayerPrefs.SetInt("Levelcomplete", levelcomplete);
            //Debug.Log(PlayerPrefs.GetInt("Levelcomplete").ToString());
            //LevelsCheck.Victory();
            panelwin.Finish();
            //Time.timeScale = 0;
        }

    }
}
