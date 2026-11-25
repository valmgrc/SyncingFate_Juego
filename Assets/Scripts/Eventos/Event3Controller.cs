using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Event3Controller : MonoBehaviour
{
   
    public TMP_Text npcNameText;
    public TMP_Text dialogueText;
    public Image npcImage;

    public GameObject nextButton;
    public GameObject choicePanel;

 
    public GameObject event3Panel;
    public GameObject event7Panel;
    public GameObject event8Panel;

    public Button option1;
    public Button option2;

   
    public Sprite valentinaSprite;
    public Sprite aaronSprite;
    public Sprite nataliaSprite;
    public Sprite paulaSprite;
    public Sprite vacioSprite;

    int step = 0;
    int choice1 = 0;
    int choice2 = 0;
    int choice3 = 0;
    int choice4 = 0;
    int choice5 = 0;
    int choice6 = 0;


    public GameObject popupPrefab;
    public Transform popupContainer;

    public Sprite iconValidacion;
    public Sprite iconVinculos;
    public Sprite iconAuto;


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
        step++;

       
        nextButton.SetActive(true);
        choicePanel.SetActive(false);

        switch (step)
        {
            case 1:
                SetNPC("", vacioSprite);
                SetDialogue("Llego a la fiesta acompañada de Valentina. El sonido está por todos lados, es algo molesto.");
                break;
            case 2:
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("Val me dejó sola! Uy, qué hago, no conozco a nadie!");
                ShowChoices("Quedarme aquí es lo más seguro", "Vayamos a hablar con ese chico de por allá");
                break;

            case 3:
                if (choice1 == 1)
                {
                    SetNPC("", vacioSprite);
                    SetDialogue("Un chico aparece delante mío y me sonríe en cuanto me ve");
                }
                else
                {
                    SetNPC("???", aaronSprite);
                    SetDialogue("Buenas noches! Que onda! tú debes ser la chica de la que me contó Naty…");
                }
                
                break;

            case 4:
                if (choice1 == 1)
                {
                    SetNPC("???", aaronSprite);
                    SetDialogue("Buenas noches! Que onda! tu debes ser la chica de la que me contó Naty… No me habia dicho lo linda que eres y los ojazos que tienes. Toma, te traje esta bebida");
                    
                    ShowChoices("Jaja, Gracias! tú tambien te ves muy guapo ¿cómo te llamas?", "ehhh… ¿tú eres?");
                }
                else
                {
                    SetNPC("???", aaronSprite);
                    SetDialogue("No me habia dicho lo linda que eres y los ojazos que tienes. Toma, te traje esta bebida");
                    ShowChoices("Jaja, Gracias! tú tambien te ves muy guapo ¿cómo te llamas?", "ehhh… ¿Tú eres?");

                }
                break;

            case 5:
                if (choice2 == 2)
                {
                    SetNPC("???", aaronSprite);
                    SetDialogue("¡Claro! que descortés de mi parte, creí que todos aquí sabian quien soy");
                    
                }
                else
                {
                    SetNPC("???", aaronSprite);
                    SetDialogue("¡Claro! que descortés de mi parte, creí que todos aquí sabian quien soy.");
                   
                }
               
                break;

            case 6:
                SetNPC("Aarón", aaronSprite);
                SetDialogue("Aarón Praga, para servirle.");
                ShowChoices("Disculpa. No tenía ni idea de quien eres", "Disculpa. No quería parecer grosera.");
                break;

            case 7:
                if (choice3 == 3)
                {
                    SetNPC("Aarón", aaronSprite);
                    SetDialogue("Te quería ofrecer esta bebida. Las anda preparando Mark por ahi en el bar.");
                }
                else
                {
                    SetNPC("Aarón", aaronSprite);
                    SetDialogue("Te quería ofrecer esta bebida. Las anda preparando Mark por ahi en el bar.");
                }
                break;

            case 8:
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("¿De qué es?"); 

                break;

            case 9:
                SetNPC("Aarón", aaronSprite);
                SetDialogue("¿Eso importa? es alcohol, es lo unico que importa, así que, ¿qué dices?");
                ShowChoices("Tomar del vaso", "No tomar");

                break;

            case 10:
                if (choice4 == 1)
                {
                    SetNPC(GameData.playerName, vacioSprite);
                    SetDialogue("Bueno, está bien… un vaso no debería ser mayor problema.");
                }
                else
                {
                    SetNPC(GameData.playerName, vacioSprite);
                    SetDialogue("Ni te conozco ¿y quieres que tome tu bebida turbia? yo paso…");
                }
                break;

            case 11:
                SetNPC("", vacioSprite);
                SetDialogue("La fiesta continúa. Aarón sigue al lado mío, baila mientras toma. Actúa como un animal, pero eso parece agradarle a las chicas y hombres que están por ahí.");
                
                
                break;

            case 12:
                SetNPC("Valentina", vacioSprite);
                SetDialogue("NENA?!? ¿DÓNDE ESTÁS? NO TE VEOOOO!");
                break;

            case 13:
                SetNPC("Valentina", valentinaSprite);
                SetDialogue("OMG! TE ESTABA BUSCANDO NENA! Quería presentarte a la créme de la créme.");

                
                break;

            case 14:
                SetNPC("Valentina", valentinaSprite);
                SetDialogue("Ella es...");
                break;


            case 15:
                SetNPC("Natalia", nataliaSprite);
                SetDialogue("Ugh. No necesito introducción, claro que ya sabe quien soy. ¿Verdad?");
                ShowChoices("Claro! Natalia, es un gusto conocerte!", "Eh, aún así sería amable que te presentes");

                
                break;

            case 16:
                if (choice5 == 1)
                {
                    SetNPC("Natalia", nataliaSprite);
                    SetDialogue("Hm, me agradas. Creo que nos llevaremos muy bien, ¿no crees Pau?");
                }
                else
                {
                    SetNPC("", vacioSprite);
                    SetDialogue("Natalia se rÍe. Tu insolencia le parece algo patética.");
                }
                break;

            case 17:
                if (choice5 == 1)
                {
                    SetNPC("Paula", paulaSprite);
                    SetDialogue("Parece que si, Nat.");
                }
                else
                {
                    SetNPC("Paula", paulaSprite);
                    SetDialogue("¿Y tú quien te crees que eres para hablarle así a Naty? Tonta.");
                }
                break;

            case 18:
                SetNPC("Natalia", nataliaSprite);
                SetDialogue("Silencio, Paula. En fin, veo que AP ya te ofreció algo de beber, aunque me ha dicho que solo has tomado un sorbo");

               
                break;


            case 19:
                SetNPC("Natalia", nataliaSprite);
                SetDialogue("Que aburrida ¿que no quieres divertirte? acábate ese vaso y vamos por más.");

                ShowChoices("Claro! a eso vine!", "Creo que paso… Tomar no es lo mío");
                break;


            case 20:
                if (choice6 == 1)
                {
                    SetNPC("Natalia", nataliaSprite);
                    SetDialogue("Eso es lo que me gusta oir! Venga linda, vamos por otro vaso y brindemos hasta el amanecer!");
                }
                else
                {
                    SetNPC("Natalia", nataliaSprite);
                    SetDialogue("Que aburrida. ¿a qué vienes si no es a tomar?");
                }
                break;


            case 21:
                if (choice6 == 1)
                {
                    SetNPC("", vacioSprite);
                    SetDialogue("En lo que restó de la fiesta, pude pasar tiempo con Natalia e incluso, nos tomamos una selfie que publicó en su Orion");
                }
                else
                {
                    SetNPC("", vacioSprite);
                    SetDialogue("Pasé el resto de la fiesta con Valentina, después de ese comentario, me sentí descolocada.");
                }
                

                
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


    string option1Text;
    string option2Text;


    public void ChooseOption(int option)
    {


        if (step == 2)
            choice1 = option;

        else if (step == 4)
            choice2 = option;

        else if (step == 6)
            choice3 = option;

        else if (step == 9)
            choice4 = option;

        else if (step == 15)
            choice5 = option;

        else if (step == 19)
            choice6 = option;

        //Aqui estan las metricas para editarlas
        if (step == 2)
        {
            if (option == 1)
                ModifyStats(0, -10, -10);
            else
                ModifyStats(+10, +10, 0);
        }

        else if (step == 4)
        {
            if (option == 1)
                ModifyStats(+10, 0, 0);
            else
                ModifyStats(-10, 0, +10);
        }

        else if (step == 6)
        {
            if (option == 1)
                ModifyStats(-10, 0, +10);
            else
                ModifyStats(0, +10, -10);
        }

        else if (step == 9)
        {
            if (option == 1)
                ModifyStats(+10, 0, -10);
            else
                ModifyStats(-10, 0, +10);
        }

        else if (step == 15)
        {
            if (option == 1)
                ModifyStats(+10, 0, 0);
            else
                ModifyStats(-10, 0, 0);
        }

        else if (step == 19)
        {
            if (option == 1)
                ModifyStats(+10, -10, -10);
            else
                ModifyStats(-10, 0, +10);
        }



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

        
        SceneManager.LoadScene("PantallaCalendario");


    }

    void ModifyStats(int validación, int vínculos, int autopercepción)
    {
        GameData.validacion += validación;
        GameData.vinculos += vínculos;
        GameData.autopercepcion += autopercepción;

       
        GameData.validacion = Mathf.Clamp(GameData.validacion, 0, 100);
        GameData.vinculos = Mathf.Clamp(GameData.vinculos, 0, 100);
        GameData.autopercepcion = Mathf.Clamp(GameData.autopercepcion, 0, 100);

        GameData.Save();

        ShowMultiplePopups(validación, vínculos, autopercepción);

        var ui = FindFirstObjectByType<MetricsManagerUI>();
        if (ui != null)
        {
            ui.UpdateMetrics();
        }
    }

    string FormatStat(int value)
    {
        if (value > 0) return "+" + value;
        if (value < 0) return value.ToString();
        return "0";
    }

    
    void ShowMultiplePopups(int validacion, int vinculos, int autopercepcion)
    {
        if (validacion != 0)
            CreatePopup(validacion, iconValidacion, 0);

        if (vinculos != 0)
            CreatePopup(vinculos, iconVinculos, 1);

        if (autopercepcion != 0)
            CreatePopup(autopercepcion, iconAuto, 2);
    }

    
    
    void CreatePopup(int value, Sprite icon, int index)
    {
        GameObject popup = Instantiate(popupPrefab, popupContainer);

        
        TMP_Text txt = popup.GetComponentInChildren<TMP_Text>();
        txt.text = (value > 0 ? "+" : "") + value;

      
        Image iconImg = popup.transform.Find("Icon").GetComponent<Image>();
        iconImg.sprite = icon;

       
        popup.transform.localPosition += new Vector3(0, -40 * index, 0);

        CanvasGroup cg = popup.GetComponent<CanvasGroup>();

        StartCoroutine(AnimatePopup(popup.transform, cg));
    }

    IEnumerator AnimatePopup(Transform popup, CanvasGroup cg)
    {
        float fadeInTime = 0.3f;
        float visibleTime = 3f; 
        float fadeOutTime = 0.8f;

        float floatDistance = 30f; 
        float timer = 0f;

        Vector3 startPos = popup.localPosition;

      
        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            cg.alpha = timer / fadeInTime;

            popup.localPosition = startPos + new Vector3(0, (timer / fadeInTime) * floatDistance, 0);

            yield return null;
        }

        cg.alpha = 1;
        float visibleTimer = 0f;

        while (visibleTimer < visibleTime)
        {
            visibleTimer += Time.deltaTime;

      
            popup.localPosition += new Vector3(0, Time.deltaTime * 5f, 0);

            yield return null;
        }

        timer = 0f;

        while (timer < fadeOutTime)
        {
            timer += Time.deltaTime;

            cg.alpha = 1 - (timer / fadeOutTime);

            popup.localPosition += new Vector3(0, Time.deltaTime * 10f, 0);

            yield return null;
        }

        Destroy(popup.gameObject);
    }
}