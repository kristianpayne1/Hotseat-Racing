using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}

    public bool trackFinished {get; set;}
    public bool startRace {get; set;}

    void Start() {
        trackFinished = false;
        startRace = true;
        StartCoroutine(raceStart());
    }

    IEnumerator raceStart()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("3");
         yield return new WaitForSeconds(1f);
        Debug.Log("2");
         yield return new WaitForSeconds(1f);
        Debug.Log("1");
         yield return new WaitForSeconds(1f);
        Debug.Log("GOO!!!!!");
        startRace = false;
    }

    public void Restart() {
        SceneManager.LoadScene("Track 1");
    }

    void Awake() {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!trackFinished && !startRace) {
            if (Input.GetKey(KeyCode.R)) {
                Restart();
            }
        }
        PlayerManager.Instance.trackFinished = trackFinished;
        PlayerManager.Instance.startRace = startRace;
    }
}
