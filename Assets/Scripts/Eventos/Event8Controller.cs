using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Event8Controller : MonoBehaviour
{

    public TMP_Text npcNameText;
    public TMP_Text dialogueText;
    public Image npcImage;

    public GameObject nextButton;
    public GameObject choicePanel;

   
    public TMP_InputField playerInputField;
    public GameObject inputPanel;

    public GameObject event3Panel;
    public GameObject event7Panel;
    public GameObject event8Panel;

    public Button option1;
    public Button option2;


    public Sprite angelaSprite;
    public Sprite vacioSprite;

    int step = 0;
    int choice1 = 0;
   


    void Start()
    {
        int chatID = PlayerPrefs.GetInt("currentChat", 0);

        if (chatID == 3)
        {
            event3Panel.SetActive(true);
            event7Panel.SetActive(false);
            event8Panel.SetActive(false);
        }
        else if (chatID == 7)
        {
            event3Panel.SetActive(false);
            event7Panel.SetActive(true);
            event8Panel.SetActive(false);
        }
        else if (chatID == 8)
        {
            event3Panel.SetActive(false);
            event7Panel.SetActive(false);
            event8Panel.SetActive(true);
        }

        step = 0;
        choicePanel.SetActive(false);
        nextButton.SetActive(true);

        Next();
    }



    public void Next()
    {

        if(inputPanel.activeSelf)
        {
            string playerText = playerInputField.text;

            if (string.IsNullOrEmpty(playerText))
                playerText = "...";

            inputPanel.SetActive(false);

            SetNPC(GameData.playerName, vacioSprite);
            SetDialogue(playerText);

            return;
        }

        step++;


        nextButton.SetActive(true);
        choicePanel.SetActive(false);

        switch (step)
        {
            case 1:
                SetNPC("", vacioSprite);
                SetDialogue("Llego corriendo a la casa de Ángela, el metro se demoró más de lo debido.");
                break;
            case 2:
                SetNPC("Ángela", angelaSprite);
                SetDialogue("Hola amiga, entra, estás en tu casa"); 
                break;

            case 3:
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("Muchas gracias Angie, vengo de rápido porque mi mamá me mandó a hacer unos deberes, ¿de qué querías hablar?");

                break;

            case 4:
                SetNPC("Ángela", angelaSprite);
                SetDialogue("Solo quería preguntar por ti, ¿cómo estás? ¿cómo te sientes con pues...tu nueva amiga Natalia");
                break;

            case 5:

                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("");
                ShowInput();
               

                break;

            case 6:
                SetNPC("Ángela", angelaSprite);
                SetDialogue("Y, ¿puedo preguntar por tus fotos? Por que he visto que las has editado un poco");
              
                ShowChoices("Ah, bueno, solamente quería verme un poquito mejor, ya sabes, solo un poquitin.", "Si, sobre eso...me han dicho que es mejor con filtro y bueno Natalia sabe tooodo sobre el mundo de las redes");
                break;

            case 7:
                if (choice1 == 1)
                {
                    SetNPC("Ángela", angelaSprite);
                    SetDialogue("Claro, entiendo, esto de los filtros es woow una maravilla");
                }
                else
                {
                    SetNPC("Ángela", angelaSprite);
                    SetDialogue("Si, entiendo amix, Natalia si que es muy popular en redes");
                }
                break;

            case 8:
                SetNPC("Ángela", angelaSprite);
                SetDialogue("Aunque, solo un consejito, no me gustaría que intentaras aparentar algo que no eres, las redes pueden ser peligrosas si buscas validación de otros, y tú no necesitas eso nena, tú mereces sentirte bien contigo");

                break;

            case 9:
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("Muchas gracias aprecio enserio tus palabras, por eso te quiero muchisimo.");

                break;

            case 10:
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("Y lo siento que corte esta conversación, pero ahora si mi mamá me anda llamando, ¡me tengo que ir Angie!");
                break;

            case 11:
                SetNPC("Valentina", vacioSprite);
                SetDialogue("Si amix, vete con cuidado, luego hablamos y recuerda, vales mucho");
                ShowEndButton();
                break;

        }
    }


    // OPCIONES


    void ShowChoices(string op1, string op2)
    {
        nextButton.SetActive(false);
        choicePanel.SetActive(true);

        option1Text = op1;
        option2Text = op2;


        option1.GetComponentInChildren<UnityEngine.UI.Text>().text = op1;
        option2.GetComponentInChildren<UnityEngine.UI.Text>().text = op2;

        option1.onClick.RemoveAllListeners();
        option2.onClick.RemoveAllListeners();

        option1.onClick.AddListener(() => ChooseOption(1));
        option2.onClick.AddListener(() => ChooseOption(2));
    }

    void ShowInput()
    {
        inputPanel.SetActive(true);
        playerInputField.text = "";


        nextButton.SetActive(true);
       
    }

    string option1Text;
    string option2Text;


    public void ChooseOption(int option)
    {



        choicePanel.SetActive(false);
        nextButton.SetActive(true);


        SetNPC(GameData.playerName, vacioSprite);


        if (option == 1)
            SetDialogue(option1Text);
        else
            SetDialogue(option2Text);
    }



    void SetNPC(string name, Sprite sprite)
    {
        npcNameText.text = name;
        npcImage.sprite = sprite;
    }

    void SetDialogue(string text)
    {
        dialogueText.text = text;
    }



    void ShowEndButton()
    {
        nextButton.SetActive(true);
        choicePanel.SetActive(false);

        Button btn = nextButton.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(EndEvent);
    }


    void EndEvent()
    {

        int chatID = PlayerPrefs.GetInt("currentChat", 0);

        GameData.chatsDone[chatID] = true;
        GameData.chatsRead[chatID] = true;


        if (chatID + 1 < GameData.chatsUnlocked.Length)
        {
            GameData.chatsUnlocked[chatID + 1] = true;
            GameData.chatsRead[chatID + 1] = false;
        }



        GameData.eventsCompleted[0] = true;
        GameData.Save();


        int average = (GameData.validacion + GameData.vinculos + GameData.autopercepcion) / 3;
        PlayerPrefs.SetInt("EndingType", average >= 50 ? 1 : 0);

        SceneManager.LoadScene("Finales");


    }

    
}