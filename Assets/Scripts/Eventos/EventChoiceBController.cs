using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EventChoiceBController : MonoBehaviour
{
    public TMP_Text npcNameText;
    public TMP_Text dialogueText;
    public Image npcImage;

    public GameObject nextButton;

    public Sprite paulaSprite;

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
                SetNPC("Paula", paulaSprite);
                SetDialogue("Texto1");
                break;

            case 2:
                SetDialogue("Texto2");
                break;

            case 3:
                GameData.vinculos += 15;
                SetDialogue("Texto3");
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
            PlayerPrefs.SetInt("LastEventPlayed", 1);

            GameData.eventsCompleted[3] = true;
            GameData.Save();
            SceneManager.LoadScene("Publicaciones");
        });
    }
}