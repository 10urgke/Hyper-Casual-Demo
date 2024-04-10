using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public SoundManager sounds;

    public Image whiteeffectimage;
    private int effectcontrol = 0;
    private bool radialshine;

    public Image FillRateImage;
    public GameObject Player;
    public GameObject FinishLine;

    public Animator LayoutAnimator;

    public Text coin_text;
    //Butonlar
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject layout_Background;
    public GameObject sound_On;
    public GameObject sound_Off;
    public GameObject vibration_On;
    public GameObject vibration_Off;
    public GameObject iap;
    public GameObject information;

    public GameObject intro_Hand;
    public GameObject toptopmove_Text;
    public GameObject noAds;
    public GameObject shop_Button;

    public GameObject RestartScreen;

    //Oyun sonu Ekrani
    public GameObject finishScreen;
    public GameObject blackBackground;
    public GameObject complete;
    public GameObject radial_shine;
    public GameObject coin;
    public GameObject rewarded;
    public GameObject nothanks;

    public GameObject achievedCoin;
    public GameObject nextLevel;
    public Text achievedText;

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }

        if (PlayerPrefs.HasKey("Vibration") == false)
        {
            PlayerPrefs.SetInt("Vibration", 1);
        }

        if (PlayerPrefs.GetInt("Noads") == 1)
        {
            NoAdsRemove();
        }

        CoinTextUpdate();
    }

    public void Update()
    {
        if (radialshine == true)
        {
            radial_shine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 15f * Time.deltaTime));
        }

        FillRateImage.fillAmount = ((Player.transform.position.z*100) / (FinishLine.transform.position.z))/100;
    }



    public void FirstTouch()
    {
        intro_Hand.SetActive(false);
        toptopmove_Text.SetActive(false);
        noAds.SetActive(false);
        shop_Button.SetActive(false);
        settings_Open.SetActive(false);
        settings_Close.SetActive(false);
        layout_Background.SetActive(false);
        sound_On.SetActive(false);
        sound_Off.SetActive(false);
        vibration_On.SetActive(false);
        vibration_Off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
    }

    public void NoAdsRemove()
    {
        noAds.SetActive(false);
    }

    public void CoinTextUpdate()
    {
        coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }

    public void RestartButtonActive()
    {
        RestartScreen.SetActive(true);
    }

    public void RestartScene()
    {
        Variables.firsttouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        Variables.firsttouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FinishScreen()
    {
        StartCoroutine("FinishLaunch");
    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.5f;
        radialshine = true;
        finishScreen.SetActive(true);
        blackBackground.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        complete.SetActive(true);
        sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(1.3f);
        sounds.CompleteSound();
        radial_shine.SetActive(true);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        rewarded.SetActive(true);
        sounds.CompleteSound();
        yield return new WaitForSecondsRealtime(3f);
        nothanks.SetActive(true);
    }

    public IEnumerator AfterRewardButton()
    {
        achievedCoin.SetActive(true);
        achievedText.gameObject.SetActive(true);
        rewarded.SetActive(false);
        nothanks.SetActive(false);
        for (int i = 0; i < 401; i += 4)
        {
            achievedText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);
        }
        yield return new WaitForSecondsRealtime(1f);
        nextLevel.SetActive(true);
    }




    public void Privacy_Policy()
    {
        Application.OpenURL("https://www.tosugames.com/privacy-policy/");
    }

    public void TermOfUse()
    {
        Application.OpenURL("https://www.tosugames.com/term-of-use/");
    }



    //Buton fonksiyonlari

    public void Settings_Open()
    {
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_in");

        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            sound_On.SetActive(true);
            sound_Off.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }


        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibration_On.SetActive(true);
            vibration_Off.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {
            vibration_On.SetActive(false);
            vibration_Off.SetActive(true);
        }

    }

    public void Settings_Close()
    {
        settings_Open.SetActive(true);
        settings_Close.SetActive(false);
        LayoutAnimator.SetTrigger("Slide_out");
    }

    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);
    }

    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void Vibration_On()
    {
        vibration_On.SetActive(false);
        vibration_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 2);
    }

    public void Vibration_Off()
    {
        vibration_On.SetActive(true);
        vibration_Off.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 1);
    }



    //haskey
    //get
    //set












    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.001f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b,1))
            {
                effectcontrol = 1;
            }
        }

        while (effectcontrol == 1)
        {
            yield return new WaitForSeconds(0.001f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
            {
                effectcontrol = 2;
            }
        }

        if (effectcontrol == 2)
        {
            Debug.Log("Efekt bitti");
        }

    }
}
