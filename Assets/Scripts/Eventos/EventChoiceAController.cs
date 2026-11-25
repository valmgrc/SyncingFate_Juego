using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EventChoiceAController : MonoBehaviour
{
    public TMP_Text npcNameText;
    public TMP_Text dialogueText;
    public Image npcImage;

    public GameObject nextButton;
    public GameObject choicePanel;

    public Sprite valentinaSprite;

    int step = 0;

    void Start()
    {
        Next();
    }

    public void Next()
    {
        step++;

        switch (step)
        {
            case 1:
                SetNPC("Valentina", valentinaSprite);
                SetDialogue("Texto");
                break;

            case 2:
                SetDialogue("Texto");
                break;

            case 3:
                GameData.validacion += 15;
                SetDialogue("Texto");
                break;

            case 4:
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
        btn.onClick.AddListener(() =>
        {
            PlayerPrefs.SetInt("LastEventPlayed", 0);

            GameData.eventsCompleted[2] = true;
            GameData.Save();
            SceneManager.LoadScene("Publicaciones");
        });
    }
}