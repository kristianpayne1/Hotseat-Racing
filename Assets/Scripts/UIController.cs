using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject blackOutSquare;
    public GameObject introText;
    public TextMeshProUGUI introCredsText;
    public TextMeshProUGUI touchText;
    public TextMeshProUGUI Title;
    public AudioSource cloudAudio;

    private bool introComplete = false;
    private bool carStarted = false;
    private bool introSkipped = false;
    private bool canSkipIntro = false;

    void Start() 
    {
        Title.enabled = false;
        blackOutSquare.SetActive(true);
        StartCoroutine(intro());
    }

    private void Update() {
        if(Input.touchCount > 0 && !carStarted && canSkipIntro)    
        {
            canSkipIntro = false;
            carStarted = true;
            if (!introSkipped && !introComplete) introText.SetActive(false);
            if (introComplete && !introSkipped) 
            {
                StartCoroutine(FadeInOutText(touchText, false, 50f));
            }
            // start the menu bot
            GameObject botCar = GameObject.FindGameObjectsWithTag("Bot")[0];
            BotManager BotManager = botCar.GetComponent<BotManager>();
            BotManager.disableBot = false;
            BotManager.carController.engineSound.Play();
            BotManager.carController.isRunning = true;
            StartCoroutine(waitForTitle());
            // Rigidbody botRigidbody = botCar.GetComponentInChildren<Rigidbody>();
            // botRigidbody.AddForce(-botCar.transform.forward * 99999999999f);
        }
    }

    IEnumerator waitForTitle()
    {
        yield return new WaitForSeconds(2.5f);
        cloudAudio.Stop();
        Title.enabled = true;
    }

    IEnumerator intro()
    {
        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(FadeBlackOutSquare(false));
        canSkipIntro = true;
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeInOutText(introCredsText, true, 1f));
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeInOutText(introCredsText, false, 1f));
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(FadeInOutText(touchText, true, 1f));
        introComplete = true;
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, float fadeSpeed = 0.5f)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if(fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        } else {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        yield return new WaitForEndOfFrame();
    }

    public IEnumerator FadeInOutText(TextMeshProUGUI text, bool fadeToBlack = true, float fadeSpeed = 0.5f)
    {
        Color objectColor = text.color;
        float fadeAmount;

        if(fadeToBlack)
        {
            while (text.color.a < 1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                text.color = objectColor;
                yield return null;
            }
        } else {
            while (text.color.a > 0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                text.color = objectColor;
                yield return null;
            }
        }
        yield return new WaitForEndOfFrame();
    }
}
