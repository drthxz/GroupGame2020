using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIManager : MonoBehaviour
{
    public GameObject canvas;
    GameObject startBtn;
    GameObject characterMenu;
    GameObject settingMenu;
    GameObject startBG;

    bool onSetting;
    bool onCharacter;
    public GameObject character;
    List<GameObject> characterList;
    public Toggle window_toggle;
    public Toggle SE_toggle;
    public Toggle voice_toggle;
    public Toggle BGM_toggle;
    // Start is called before the first frame update
    void Start()
    {
        characterList = new List<GameObject>();
        for(int i=0; i<4; i++)
        {
            characterList.Add(character.transform.GetChild(i).gameObject);
            characterList[i].SetActive(false);
        }

        startBtn = canvas.transform.Find("StartBut").gameObject;
        settingMenu= canvas.transform.Find("SettingMenu").gameObject;
        characterMenu= canvas.transform.Find("CharacterMenu").gameObject;
        startBG = canvas.transform.Find("StartBG").gameObject;
        settingMenu.SetActive(false);
        characterMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(){
        SceneManager.LoadScene("Default");
    } 

    public void Setting(){
        onSetting=!onSetting;
        startBtn.SetActive(!onSetting);
        settingMenu.SetActive(onSetting);
        characterMenu.SetActive(false);

    }

    int index = 0;
    int windowSetting;
    public void Character(){
        onCharacter=!onCharacter;
        startBtn.SetActive(!onCharacter);
        settingMenu.SetActive(false);
        characterMenu.SetActive(onCharacter);
        characterList[index].SetActive(true);
    }
    
    public void CharacterChangeRight()
    {
        index++;
        if (index >= 3) { index = 3; }
        characterList[index-1].SetActive(false);
        characterList[index].SetActive(true);
    }

    public void CharacterChangeLeft()
    {
        index--;
        if (index <= 0) { index = 0; }
        characterList[index + 1].SetActive(false);
        characterList[index].SetActive(true);
    }

    public void StartGame()
    {
        Destroy(startBG.gameObject);
    }

    public void Window()
    {
        if (window_toggle.isOn == true)
        {
            Screen.fullScreen = Screen.fullScreen;
            PlayerPrefs.SetInt("windowSetting", 1);
        }
        else
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
    }

    public void SE()
    {
        if (SE_toggle.isOn == true)
        {

        }
    }

    public void Voice()
    {
        if (voice_toggle.isOn == true)
        {

        }
    }

    public void BGM()
    {
        if (BGM_toggle.isOn == true)
        {

        }
    }



}
