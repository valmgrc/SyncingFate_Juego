using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Event17Controller : MonoBehaviour
{
    public TMP_Text npcNameText;
    public TMP_Text dialogueText;
    public Image npcImage;

    public GameObject nextButton;

    public Sprite nataliaSprite;

    int step = 0;

    void Start()
    {
        nextButton.SetActive(true);
        Next();
    }

    public void Next()
    {
        step++;

        switch (step)
        {
            case 1:
                SetNPC("Natalia", nataliaSprite);
                SetDialogue("Texto1");
                break;

            case 2:
                if (GameData.validacion < 40)
                    SetDialogue("Texto2"); 
                else
                    SetDialogue("Texto3");
                break;

            case 3:
                SetDialogue("Texto4");
                break;

            case 4:
                SetDialogue("Evento terminado");
                ShowEndButton();
                break;
        }
    }

    void SetNPC(string n, Sprite s)
    {
        npcNameText.text = n;
        npcImage.sprite = s;
    }

    void SetDialogue(string t)
    {
        dialogueText.text = t;
    }

    void ShowEndButton()
    {
        Button btn = nextButton.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(EndEvent);
    }

    void EndEvent()
    {
        GameData.chatsDone[17] = true;

        if (18 < GameData.chatsUnlocked.Length)
        {
            GameData.chatsUnlocked[18] = true;
            GameData.chatsRead[18] = false;
        }

        
        GameData.eventsCompleted[4] = true;
        GameData.Save();

        SceneManager.LoadScene("PantallaInicio");
    }
}