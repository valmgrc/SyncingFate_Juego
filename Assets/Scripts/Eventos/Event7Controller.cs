using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Event7Controller : MonoBehaviour
{
    public TMP_Text npcNameText;
    public TMP_Text dialogueText;
    public Image npcImage;

    public GameObject nextButton;
    public GameObject choicePanel;


    public GameObject event3Panel;
    public GameObject event7Panel;

    public Button option1;
    public Button option2;

    public Sprite aaronSprite;
    public Sprite paulaSprite;
    public Sprite vacioSprite;
    public Sprite nataliaSprite;

    int step = 0;
    
    int choice1 = 0;
    int choice2 = 0;
    int choice3 = 0;

    public GameObject popupPrefab;
    public Transform popupContainer;

    void Start()
    {
        int chatID = PlayerPrefs.GetInt("currentChat", 0);

        if (chatID == 3)
        {
            event3Panel.SetActive(true);
            event7Panel.SetActive(false);
        }
        else if (chatID == 7)
        {
            event3Panel.SetActive(false);
            event7Panel.SetActive(true);
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
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("Vaya, no esperaba que una salida con Aaron significara incluir a Natalia y Paula. Dudo que quieran aceptarme");
                break;

            case 2:
                SetNPC("Aaron", aaronSprite);
                SetDialogue("Vaya linda, has llegado. Creí que correrías asustadiza al vernos a todos aquí. Chicas, saluden a " + GameData.playerName + ", seguro que la recuerdan");
                break;

            case 3:
                SetNPC("Natalia", nataliaSprite);
                SetDialogue("Claro que la recuerdo, es la novata de la fiesta. Nena, espero que Paula te haya ayudado con las fotografías, esas que subías antes estaban OUT.");
                break;

            case 4:
                SetNPC("Paula", paulaSprite);
                SetDialogue("Claro que la ayudé, tú jamás te equivocas Nat, si dices que… esta tiene potencial, está claro que lo tiene. Y bueno, tú, ¿no vas a decir nada? jajaja.");
                break;

            case 5:
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("La conversación fluye tan bien entre ellas que me roban las palabras, no tengo idea de que decir para ser aceptada.");
                ShowChoices("¡Claro que sí! Es increíble encontrarlas y más cuando han sido unos ángeles para mí.", "No esperaba encontrarlas aquí… Como Aaron no me mencionó nada, pero es bueno verlas chicas.");
                break;

            case 6:
                if (choice1 == 1)
                {
                    SetNPC("Natalia", nataliaSprite);
                    SetDialogue("Bueno, basta de hablar, nuestras bebidas ya casi llegan así que, toma asiento nena.");
                }
                else
                {
                    SetNPC("Natalia", nataliaSprite);
                    SetDialogue("Bueno, basta de hablar, nuestras bebidas ya casi llegan así que, toma asiento nena.");
                }
                break;

            case 7:
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("¿Será que me comenzarán a mirar raro si sigo tan ensimismada? Debería agradecerle a Aaron por la invitación...");
                
                break;

            case 8:
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("Muchas gracias por la invitación Aaron, es increíble este lugar como lo dijiste, tienes, bueno, tienen muy buen gusto.");
              
                break;

            case 9:
                SetNPC("Aaron", aaronSprite);
                SetDialogue("Claro que sí niña, cualquier lugar de moda lo conozco como la palma de la mano, tú juntate conmigo y te mostraré un mundo que jamás imaginaste.");

                break;

            case 10:
                SetNPC("Natalia", nataliaSprite);
                SetDialogue("Okay Aaron, that´s disgusting, deja a la pobre chica en paz, al menos por ahora. Nena, ¿te está molestando este patán guapetón?");
                ShowChoices("Jajaja, claro que no, es lindo que sean tan amables conmigo y que me dejen ser su amiga.", "Bueno, es algo incómodo, no estoy acostumbrada y no conozco demasiado a Aaron");
                break;

            case 11:
                if (choice2 == 1)
                {
                    SetNPC("Aaron", aaronSprite);
                    SetDialogue("Que astuta, esa carita linda no es de adorno, te podría hacer mi esposa trofeo aquí mismo");
                }
                else
                {
                    SetNPC("Aaron", aaronSprite);
                    SetDialogue("Que arrogante, solo te doy unos cuantos cumplidos y te comportas así? De verdad que hay mujeres tan infelices que no creen que alguien como yo les hará caso.");
                }
                break;

            case 12:
                SetNPC("Aaron", aaronSprite);
                SetDialogue("De cualquier forma, no importa lo que digas, nena. Es sensual cuando una mujer se hace la difícil, así que tengo más ganas de conquistarte.");
                break;

            case 13:
                SetNPC("Natalia", nataliaSprite);
                SetDialogue("Nuestras bebidas han llegado, pedí lo más trendy del momento aunque claro, este lugar se caracteriza por ser lo más popular del momento.");
                break;

            case 14:
                SetNPC("Paula", paulaSprite);
                SetDialogue("Bueno " + GameData.playerName + ", cuéntanos. ¿Cómo te fue con tu post? Es claro que tuviste más reacciones, yo te aconsejé, dah, pero, ¿subiste de seguidores?");
                break;

            case 15:
                SetNPC("Natalia", nataliaSprite);
                SetDialogue("Tranquila reina, déjame conversar primero. TN, ahora que estás viendo como vivimos estoy segura que estás más que sorprendida.");
                break;

            case 16:
                SetNPC("Natalia", nataliaSprite);
                SetDialogue("Tan solo míranos, nos vemos y SOMOS increíbles. Si deseas, podrías vivir esto todos los días con nosotras, aunque… tu contenido no es tan bueno, no somos influencers por nada.");
                break;

            case 17:
                SetNPC("Paula", paulaSprite);
                SetDialogue("¡Claro! Todo esto nos lo hemos ganado. Mira a Nat, es la mujer más guapa de la universidad y de las redes. Ahora muchas marcas quieren patrocinar con ella.");
               
                ShowChoices("Eres tan increíble Natalia, estoy segura de que todos quieren ser como tú", "Me parece admirable y a la vez atemorizante estar a la vista de todos por como te ves.");
                break;

            case 18:
                if (choice3 == 1)
                {
                    SetNPC("Natalia", nataliaSprite);
                    SetDialogue("Yo, Natalia De La Garza, ¡puedo hacerte casi tan popular como yo! Solo debes subir más contenido atractivo. Paula te puede ayudar con eso, tiene contactos con algunos fotógrafos");
                }
                else
                {
                    SetNPC("Natalia", nataliaSprite);
                    SetDialogue("Yo, Natalia De La Garza, ¡puedo hacerte casi tan popular como yo! Solo debes subir más contenido atractivo. Paula te puede ayudar con eso, tiene contactos con algunos fotógrafos");
                }
                break;

            case 19:
                SetNPC("Paula", paulaSprite);
                SetDialogue("Claro, justo este fin me iba a hacer una sesión de fotos, así que si no quieres dejar morir esta oportunidad única, te veo el sábado en el estudio ECO a las 4:00 en punto.");
                break;

            case 20:
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("Jamás me habían invitado a este tipo de lugares, ¿será prudente ir?");
                break;

            case 21:
                SetNPC("Aaron", aaronSprite);
                SetDialogue("Vamos linda, no temas y ve a tomarte esas fotos, estoy seguro que no solo a mi me encantará como te ves, sino a todos tus seguidores");
                break;

            case 22:
                SetNPC(GameData.playerName, vacioSprite);
                SetDialogue("Después de aquel comentario, la conversación fluyó. Aunque aún no había confirmado mi asistencia, era más que seguro que Paula esperaba mi presencia si no quería tener problemas.");
                break;

            case 23:
                SetNPC("Natalia", nataliaSprite);
                SetDialogue("Increíble, esa sesión va a ser top, y sabes que, para conmemorar este momento, ¿qué tal si publicas una foto?");
                break;

            case 24:
                SetNPC("Paula", paulaSprite);
                SetDialogue("Buena idea, vamos " + GameData.playerName + " tomemos una foto entre todos.");
                ShowEndButton();
                break;
            
        }
    }

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

        if (step == 5)
            choice1 = option;

        else if (step == 10)
            choice2 = option;

        else if (step == 17)
            choice3 = option;

        //Aqui estan las metricas para editarlas
        if (step == 5)
        {
            if (option == 1)
                ModifyStats(+10, 0, 0);
            else
                ModifyStats(-10, 0, 0);
        }

        else if (step == 10)
        {
            if (option == 1)
                ModifyStats(+10, 0, -10);
            else
                ModifyStats(-10, 0, +10);
        }

        else if (step == 17)
        {
            if (option == 1)
                ModifyStats(+10, -10, -10);
            else
                ModifyStats(0, 0, -10);
        }


        //

        choicePanel.SetActive(false);
        nextButton.SetActive(true);


        SetNPC(GameData.playerName, vacioSprite);


        if (option == 1)
            SetDialogue(option1Text);
        else
            SetDialogue(option2Text);

        //
        
        //Next();
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
        Button btn = nextButton.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
        btn.onClick.AddListener(EndEvent);
    }

   

    void EndEvent()
    {
        GameData.chatsDone[7] = true;

        if (8 < GameData.chatsUnlocked.Length)
        {
            GameData.chatsUnlocked[8] = true;
            GameData.chatsRead[8] = false;
        }

        GameData.Save();

        
        PlayerPrefs.SetInt("FromChat", 1);
        PlayerPrefs.SetInt("PostState", 0);

        SceneManager.LoadScene("Publicaciones");
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
            CreatePopup("Validación " + (validacion > 0 ? "+" : "") + validacion, 0);

        if (vinculos != 0)
            CreatePopup("Vínculos " + (vinculos > 0 ? "+" : "") + vinculos, 1);

        if (autopercepcion != 0)
            CreatePopup("Autopercepción " + (autopercepcion > 0 ? "+" : "") + autopercepcion, 2);
    }

    
    void CreatePopup(string text, int index)
    {
        GameObject popup = Instantiate(popupPrefab, popupContainer);

        TMP_Text txt = popup.GetComponentInChildren<TMP_Text>();
        txt.text = text;

        popup.transform.localPosition += new Vector3(0, -40 * index, 0);

        CanvasGroup cg = popup.GetComponent<CanvasGroup>();
        StartCoroutine(AnimatePopup(popup.transform, cg));
    }

    IEnumerator AnimatePopup(Transform popup, CanvasGroup cg)
    {
        float duration = 4f;
        float timer = 0f;

        Vector3 startPos = popup.localPosition;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            popup.localPosition = startPos + new Vector3(0, timer * 30f, 0);
            cg.alpha = 1 - (timer / duration);
            yield return null;
        }

        Destroy(popup.gameObject);
    }
}