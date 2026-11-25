using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Chat1Valentina : MonoBehaviour
{
    public Text contactNameText;
    public Text dialogueText;
    public Image npcImage;

    public GameObject choicePanel;
    public Button option1;
    public Button option2;

    public GameObject nextButton;
    public GameObject yellowButton;


    public Text yellowButtonText;

    public TMP_InputField playerInputField;
    public GameObject inputPanel;

    public CanvasGroup popupCanvasGroup;
    public float popupDuration = 1.5f;
    public float floatSpeed = 30f;

    public GameObject popupPrefab;
    public Transform popupContainer;

    //avatarcitos de todos
    public Sprite valentinaSprite;
    public Sprite aaronSprite;
    public Sprite nataliaSprite;
    public Sprite angelaSprite;
    public Sprite paulaSprite;
    public Sprite vacioSprite;


    public GameObject backButton;


    int step = 0;
    int lastChoice = 0;
    public int chatID;

    public enum YellowButtonType
    {
        None,
        Event,
        Publication
    }

    YellowButtonType yellowType = YellowButtonType.None;

    void Start()
    {
        GameData.Load();
        LoadChat();

        GameData.chatsRead[chatID] = true;
        GameData.Save();
    }

    void LoadChat()
    {
        chatID = PlayerPrefs.GetInt("currentChat", 0);

        if (chatID == 0)
            backButton.SetActive(false);
        else
            backButton.SetActive(true);


        if (chatID == 0 || chatID == 6 || chatID == 18)
            yellowType = YellowButtonType.Publication;

        else if (chatID == 3 || chatID == 7 || chatID == 17)
            yellowType = YellowButtonType.Event;

        else
            yellowType = YellowButtonType.None;

        step = 0;
        Next();
    }

   

    public void Next()
    {

        

        if (inputPanel.activeSelf)
        {
            string playerText = playerInputField.text;

            if (string.IsNullOrEmpty(playerText))
                playerText = "..."; 

            inputPanel.SetActive(false);

            ShowMessage(GameData.playerName, playerText);
            return; 
        }

            step++;


        switch (step)
        {
            // 
            case 1:

                if (chatID == 0) ShowMessage("Valentina", "¿Ya revisaste la nueva publicación de Natalia en ORION?");   
                else if (chatID == 1) ShowMessage("Ángela", "¿Estrenando cuenta de ORION? Vi tu publicación! Me encantó, obvio le di like.");
                else if (chatID == 2) ShowMessage("Valentina", "Loba! Ya andas robando likes desde ahorita nena!");
                else if (chatID == 3) ShowMessage("Valentina", "Recuerdas a Natalia?");
                else if (chatID == 4) ShowMessage("Ángela", "Vi que saliste de fiesta");
                else if (chatID == 5) ShowMessage("Natalia", "Hey!");
                else if (chatID == 6) ShowMessage("Paula", "???");
                else if (chatID == 7) ShowMessage("Aaron", "Hola perdida…");
                else if (chatID == 8) ShowMessage("Valentina", "Texto1");
                else if (chatID == 9) ShowMessage("Paula", "Texto1");
                else if (chatID == 10) ShowMessage("Paula", "Texto1");
                else if (chatID == 11) ShowMessage("Ángela", "Texto1");
                else if (chatID == 12) ShowMessage("Luka", "Texto1");
                else if (chatID == 13) ShowMessage("Natalia", "Texto1");
                else if (chatID == 14) ShowMessage("Desconocido", "Texto1");
                else if (chatID == 15) ShowMessage("Ángela", "Texto1");
                else if (chatID == 16) ShowMessage("Natalia", "Texto1");
                else if (chatID == 17) ShowMessage("Natalia", "Texto1");
                else if (chatID == 18) ShowMessage("Paula", "Texto1");
                else if (chatID == 19) ShowMessage("Ángela", "Texto1");

                break;

            
            case 2:

                if (chatID == 0)
                {
                    ShowMessage("Valentina", "Creo que se operó el pecho y se hizo la rino de paso!");
                    ShowChoices("No, nisiquiera sé que es eso. Es esa nueva red social que todos andan abriendo ¿no?", "Uhhhh, chismecitooo. Lástima no tengo ORION.");
                }
                else if (chatID == 1)
                {
                   
                    ShowChoices("Recibí muchas cantidades de likes, tú crees? Y se sintió bien", "Gracias! aunque no me sentí del todo cómoda.");
                }
                else if (chatID == 2)
                {
                    ShowMessage("Valentina", "¿Qué tal, eh?");
                    ShowChoices("uyyy, Gracias nena! Aquí empieza mi arco de fama!", " Me siento algo extraña recibiendo tanta atención. Como que entre más veo mi foto más rara me veo.");
                    
                }
                else if (chatID == 3)
                {
                    ShowMessage(GameData.playerName, "Claro, la chica influencer…");
                }

                else if (chatID == 4)
                {
                    ShowMessage("Ángela", "¿Qué tal eso?");
                    ShowChoices("De MARAVILLA! Platiqué mucho con varias personas y conocí a algunos chicos! Creo que es el comienzo de algo chido!", "Algo extraño sin duda, no sabía con quien platicar e intenté no perder a Valentina de vista.");


                }

                else if (chatID == 5)
                {
                    ShowMessage("Natalia", "Mira, varias personas me preguntarón que onda contigo de que en buen pedo…");
                    ShowChoices("Hola Nat. Que bien que dejé una impresión en ellos. ¿dijeron más?", "Hola Nat… Pues que les dijiste o qué? No me gustan esos puntos suspensivos que dejaste ahí…");

                }
                else if (chatID == 6)
                {
                    ShowMessage(GameData.playerName, "Hola Pau! ¿como estás? Soy la chica de la fiesta, amiga de Val.");
        
                }
                else if (chatID == 7)
                {
                    ShowMessage("Aaron", "¿Cómo va todo?");
                    ShowChoices("Hellooo! Todo super chill! tuuuu, que tal?", "Hola Aaron, pues bien, algo raro la verdad.");

                }
                else
                {
                    ShowMessage(contactNameText.text, "Texto2");
                }

                break;

            
            case 3:


                if (chatID == 0 || chatID == 1 || chatID == 2)
                    ResponseAfterChoice();
                else if (chatID == 3)
                {
                    ShowMessage("Valentina", "Bueno pues me mandó mensaje! me dice que le salió tu foto en perfiles recomendados y vio tus likes. Está segura que te puedes convertir en una chica como ella. Te quiere conocer en persona.");
                }
                else if (chatID == 4)
                {
                    ResponseAfterChoice();


                }
                else if (chatID == 5)
                {
                    ShowMessage("Natalia", "Mira, linda, creo que tienes todo lo necesario, sabes? Buen cuerpo, aunque sin cirugias, cara linda y tu cabello podria tener algunas mejoras, pero realmente eres un 7/10 ¿captas?");
                }
                else if (chatID == 6)
                {
                    ShowMessage("Paula", "Ah si, me dijo Nat que te pondrias en contacto conmigo…");
                }
                else if (chatID == 7)
                {
                    ContinueNormal();

                }
                else
                    ContinueNormal();

                break;

            
            case 4:
                if (chatID == 0)
                {
                    ShowMessage(GameData.playerName, "¿Para qué? Yo no me sé tomar fotos como ella y no me veo así en bikini…");
                }
                else if(chatID == 1)
                {
                    ShowMessage(GameData.playerName, "Gracias Angie!");
                    
                }
                else if (chatID == 2)
                {
                    ShowMessage(GameData.playerName, "¿No crees que es medio raro?, le puse algunos filtros a mi foto, honestamente...");

                }
                else if (chatID == 3)
                {
                    ShowMessage(GameData.playerName, "Wow, eso fue rápido");

                }
                else if (chatID == 4)
                {
                    ShowMessage(GameData.playerName, "");
                    ShowInput();

                }
                else if (chatID == 5)
                {
                    ShowMessage(GameData.playerName, "Ehh… Creo que sí.");


                }
                else if (chatID == 6)
                {
                    ShowMessage("Paula", "Mira, honestamente me pareces una chica super atractiva y guapa.");
                }
                else if (chatID == 7)
                {
                    ShowMessage("Aaron", "Ja, si. Bueno, oye nena, me encantaría poder salir a tomar algo contigo un día de estos. Me pareciste super interesante y peculiar");
                }
                else
                    ShowMessage(contactNameText.text, "Texto3");

                break;

            
            case 5:

                if (chatID == 0)
                {
                    ShowMessage("Valentina", "¿Cómo no vas a saber nena? anda, es algo que hay que vivir, neta! ¿que tal que te consigues fama y un novio?");
                }
                else if (chatID == 1)
                {
                    ShowMessage("Sistema", "Fin del chat");
                    
                    EndChatWithoutAction();
                }
                else if (chatID == 2)
                {
                    ShowMessage("Valentina", "¿y eso qué? lo más normal del mundo, vamos a ir buscando los filtros que mejor te quedan. Confia");

                   
                }
                else if (chatID == 3)
                {
                    ShowMessage("Valentina", "JAJAJ obvio! Bueno el chiste es que Nat te quiere invitar a su fiesta! Jalas? es tu oportunidad de conocer más gente de la uni!");
                    ShowChoices("WOW, Claro! me encantaría ir!", "¿cómo crees? ni los conozco, yo que voy a hacer ahí?");
                    
                }
                else if (chatID == 4)
                {
                    ShowMessage("Ángela", "Vaya noche! Bueno, pues creo que lo mejor es que descanses bestie! tkm, nos vemos en la uni.");
                    


                }
                else if (chatID == 5)
                {
                    ShowMessage("Natalia", "Pero no hay nada interesante en tu feed. ¿qué se supone que muestre?");

                }
                else if (chatID == 6)
                {
                    ShowMessage(GameData.playerName, "Ay, muchas gracias Pau");
                }
                else if (chatID == 7)
                {
                    ShowMessage(GameData.playerName, "¿Peculiar?");
                }
                else
                ShowMessage(contactNameText.text, "Texto4");

                break;

           
            case 6:

                if (chatID == 0)
                {
                    ShowMessage("Valentina", "Anda, hay que crearte un perfil, yo te ayudo");
                }
                else if (chatID == 2)
                {
                    ShowMessage("Valentina", "Aparte esa foto mega llamó la atención!");

                }
                else if (chatID == 3)
                {
                    ResponseAfterChoice();
                }
                else if (chatID == 4)
                {
                    ShowMessage("Sistema", "Fin del chat");
                    EndChatWithoutAction();


                }

                else if (chatID == 5)
                {
                    ShowMessage("Natalia", "Tienes que seguir el paso si quieres siquiera figurar. Tienes potencial de influencer nena. Te puedo dar unos brand deals que te ayudarían mucho. Pero necesito que subas más cosas. ¿Jalas?");
                    ShowChoices("Wow, me encantaría! ¿Qué recomiendas?", "Eh, creo que no es lo mío, pero gracias por decirme.");
                }
                else if (chatID == 6)
                {
                    ShowMessage("Paula", "Ew. Ni te emociones. Bueno, pues yo soy la fotografa personal de la bella Nat. Aparte de ser su bestie, of course. Anyway, te quiero ayudar a tomarte mejores fotos y a encontrar tu escencia para que subas cosas a redes que llamen la atención, te late?");
                    ShowChoices("Wow! de verdad? Claro, me encantaría!", "Ehh… Crees??");
                }
                else if (chatID == 7)
                {
                    ShowMessage("Aaron", "Totalmente. Tienes cara de florecita y actitud de bebita enojona. Me encantó coincidir contigo, traes todo el flow y a la gente le encantó vernos juntos.");
                }
                break;


            
            case 7:

                if (chatID == 0)
                {
                    ShowMessage("Sistema", "Personalízate y crea tu perfil de Orion");

                    nextButton.SetActive(false);
                    yellowButton.SetActive(true);

                    Button btn = yellowButton.GetComponent<Button>();
                    btn.onClick.RemoveAllListeners();
                    btn.onClick.AddListener(GoToCustomization);
                }
                else if (chatID == 2)
                {
                    ShowMessage("Sistema", "Fin del chat");
                    EndChatWithoutAction();

                }

                else if (chatID == 3)
                {
                    ShowMessage(GameData.playerName, "Lo he pensado mejor, creo que si asistiré, ¿qué podría pasar?");
                    ShowYellowButton();

                }
                else if (chatID == 5)
                {
                    ResponseAfterChoice();
                }
                else if (chatID == 6)
                {
                    ContinueNormal();
                    ShowMessage("Paula", "Obvio. Mira, donde Nat pone el ojo es donde nace una estrella. Por eso pone sus ojos en ella misma. Pero si te tomó a tí, confiaré en que ella sabe por qué.");

                }
                else if (chatID == 7)
                {
                    ShowMessage("Aaron", "Además, ese post? no puedo rajarme sin antes darte una oportunidad, chica…");
                }
                

                break;

            

            case 8:

                if (chatID == 5)
                {
                    ShowMessage("Sistema", "Fin del chat");
                    EndChatWithoutAction();

                }

                else if (chatID == 6)
                {
                    ShowMessage("Paula", "Mira, te mando inspo pics de fotos y poses que sé que gustarán bastante. Te gustaría más atrevida o cute?");

                }
                else if (chatID == 7)
                {
                    ShowMessage("Aaron", "¿Te gustaría salir por un café? Sería la oportunidad perfecta para, ya sabes, conocernos y ser amigos lejos de Nat y Pau.");
                    ShowChoices("Creo que no es mala idea.", "Lo siento AP, no creo poder.");
                }



                break;

            
            case 9:

               

                if (chatID == 6)
                {
                    ShowMessage(GameData.playerName, "Creo que prefiero…");
                    ShowChoices("Atrevida", "Cute");

                }
                else if (chatID == 7)
                {
                    ResponseAfterChoice();
                    ShowYellowButton();
                }



                break;

            
            case 10:

   
                if (chatID == 6)
                {
                    ResponseAfterChoice();
                    ShowYellowButton();

                }
                



                break;

          
            case 11:


                



                break;

               
        }
    }




    void ShowMessage(string speaker, string message)
    {
        contactNameText.text = speaker;
        dialogueText.text = message;

       
        if (speaker == "Valentina")
            npcImage.sprite = valentinaSprite;

        else if (speaker == "Aaron")
            npcImage.sprite = aaronSprite;

        else if (speaker == "Ángela")
            npcImage.sprite = angelaSprite;

        else if (speaker == "Natalia")
            npcImage.sprite = nataliaSprite;

        else if (speaker == "Paula")
            npcImage.sprite = paulaSprite;

        else if (speaker == GameData.playerName)
            npcImage.sprite = vacioSprite;

        else if (speaker == "Sistema")
            npcImage.sprite = vacioSprite;

        else
            npcImage.sprite = vacioSprite;

        nextButton.SetActive(true);
        yellowButton.SetActive(false);
    }
    

    void ShowChoices(string op1, string op2)
    {
        choicePanel.SetActive(true);
        nextButton.SetActive(false);

        option1.GetComponentInChildren<Text>().text = op1;
        option2.GetComponentInChildren<Text>().text = op2;

        option1.onClick.RemoveAllListeners();
        option2.onClick.RemoveAllListeners();

        option1.onClick.AddListener(() => Choose(1));
        option2.onClick.AddListener(() => Choose(2));
    }


    void Choose(int option)
    {
        lastChoice = option;

        choicePanel.SetActive(false);

       
        ShowMessage(GameData.playerName,
            (option == 1) ? option1.GetComponentInChildren<Text>().text
                          : option2.GetComponentInChildren<Text>().text);

        
        ApplyChatStats(option);

        nextButton.SetActive(true);
    }

    

    void ResponseAfterChoice()
    {
        //valentina prologo
        if (chatID == 0)
        {
            if (lastChoice == 1)
            {
                ShowMessage("Valentina", "¿Pero de que hablas nena? No TENIAS, por que te vamos a hacer uno!");
            }
            else
            {
                ShowMessage("Valentina", "¿Pero de que hablas nena? No TENIAS, por que te vamos a hacer uno!");
            }
        }

       
        //  ANGELA
        
        else if (chatID == 1)
        {
            if (lastChoice == 1)
            {
                ShowMessage("Ángela", "Obvio, mereces todos los likes del mundo bella! Aparte te veias re linda!");
            }
            else
            {
                ShowMessage("Ángela", "Ay no me digas eso! no tienes que forzarte a subir cosas que te incomoden, poco a poco linda.");
            }
        }
        //Chat valentina antes invitacion
        else if (chatID == 2)
        {
            if (lastChoice == 1)
            {
                ShowMessage("Valentina", "Esoooo! Seguro le llamas la atención a más de una persona ehh… Los compas de la uni seguro te amarían!");
            }
            else
            {
                ShowMessage("Valentina", "No te preocupes chica, es normal! Pero la gente se va a fijar más en tu belleza y tu cuerpo. Hay que sacar esos gains! Estoy segura que los de la uni segura ya quieren conocerte!");
            }
        }

        //Case3valentina invitacion
        else if (chatID == 3)
        {
            if (lastChoice == 1)
            {
                ShowMessage("Valentina", "¡Nos la vamos a pasar increíble! Vistete bien porque habrá muchos chicos");
            }
            else
            {
                ShowMessage("Valentina", "Tu te lo pierdes amiga, me preocupo por ti y no se si podrias hacer amigos por ti misma, nos vemos despues y espero no me rechaces!");
            }
        }
        //angela reflexion 
        else if (chatID == 4)
        {
            if (lastChoice == 1)
            {
                ShowMessage("Ángela", "Cuéntame, ¿como te sientes? ¿lo repetirías? ¿como te sientes contigo? Cuentame todo!");
            }
            else
            {
                ShowMessage("Ángela", "Cuéntame, ¿como te sientes? ¿lo repetirías? ¿como te sientes contigo? Cuentame todo!");
            }
        }
        //natalia
        else if (chatID == 5)
        {
            if (lastChoice == 1)
            {
                ShowMessage("Natalia", "Me mega encanta tu vibra nena! Te recomiendo que subas tus fotos más atrevidas. Dile a Pau que te ayude, sabe tomar unas fotos super sexy y coquetas.");
            }
            else
            {
                ShowMessage("Natalia", "¿De qué hablas? Obvio es lo tuyo, no seas tonta. Si te lo digo es por que yo lo sé, tengo talento para elegir the next best thing. No seas apretada. Dile a Paula que te ayude y me avisas.");
            }
        }
        
        
        //case6 paula segunda decision de como prefiere las fotos
        else if (chatID == 6)
        {
            if (lastChoice == 1)
            {
                ShowMessage("Paula", "Esa es exactamente tu vibra. Recuerda enseñar lo que tienes. Tu actitud es de 10 reina.");
            }
            else
            {
                ShowMessage("Paula", "Supongo que lento pero seguro… Pues bien, lo que te haga sentir cómoda te hara sacar tu brillo entonces…");
            }
        }

        //CASE 7 AARON SALIR EVENTO
        else if (chatID == 7)
        {
            if (lastChoice == 1)
            {
                ShowMessage("Aaron", "Genial,te llevaré al mejor café de la ciudad. Te veo entonces nena.");
            }
            else
            {
                ShowMessage("Aaron", "Desde la fiesta juegas a la dificil. No importa. Iré por tí para que salgamos.");
            }
        }
    }

    void ContinueNormal()
    {
        nextButton.SetActive(true);
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

        ShowStatsPopup(validación, vínculos, autopercepción);
    }

    

    void ShowStatsPopup(int validación, int vínculos, int autopercepción)
    {
        ShowMultiplePopups(validación, vínculos, autopercepción);
    }


    void ShowYellowButton()
    {
        nextButton.SetActive(false);
        yellowButton.SetActive(true);

        UpdateYellowText(); 

        Button btn = yellowButton.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();

       
        if (chatID == 0)
        {
            btn.onClick.AddListener(GoToCustomization);
            return;
        }

       
        if (yellowType == YellowButtonType.Event)
        {
            btn.onClick.AddListener(GoToEventsScene);
        }
        else if (yellowType == YellowButtonType.Publication)
        {
            btn.onClick.AddListener(GoToPost);
        }
    }

    void UpdateYellowText()
    {
        switch (chatID)
        {

            case 1:
                yellowButtonText.text = "Has decidido abrir ORION. Decide que tipo de foto quieres y cómo deseas editarla, presionando este botón.";
                break;

            case 3:
                yellowButtonText.text = "Finalmente, has decidido asistir a la fiesta. Alístate y encuéntrate con Valentina.";
                break;

            case 6:
                yellowButtonText.text = "Paula te ha incitado a subir una publicación, da click y decide qué deseas publicar hoy.";
                break;

            case 7:
                yellowButtonText.text = "Has decidido aceptar la invitación de Aaron. Alístate y prepárate para encontrarte con él. ¿Quién sabe que sopresa podrás llevarte?";
                break;

            default:
                yellowButtonText.text = "Continúa tu historia...";
                break;
        }
    }

    void GoToCustomization()
    {
        PlayerPrefs.SetInt("FromPrologue", 1);

        SceneManager.LoadScene("CreacionPersonaje1");
    }

    void EndChatWithoutAction()
    {
        GameData.chatsDone[chatID] = true;
        GameData.chatsRead[chatID] = true;

        if (chatID + 1 < GameData.chatsUnlocked.Length)
        {
            GameData.chatsUnlocked[chatID + 1] = true;
            GameData.chatsRead[chatID + 1] = false;
        }

        GameData.Save();

        nextButton.SetActive(false);
        yellowButton.SetActive(false);
    }

    public void GoBack()
    {
        
        
       
        SceneManager.LoadScene("PantallaChatsInicio");
    }

    public void GoToPost() //Es el Onyellowbutton
    {
        GameData.chatsDone[chatID] = true;

        if (chatID + 1 < GameData.chatsUnlocked.Length)
        {
            GameData.chatsUnlocked[chatID + 1] = true;
            GameData.chatsRead[chatID + 1] = false;
        }
        

        GameData.Save();

        PlayerPrefs.SetInt("FromChat", 1);
        PlayerPrefs.SetInt("PostState", 0);

        SceneManager.LoadScene("Publicaciones");
    }

    void GoToEventsScene()
    {
        PlayerPrefs.SetInt("currentChat", chatID);

        GameData.Save();

        SceneManager.LoadScene("Eventos");
    }

    void ShowInput()
    {
        inputPanel.SetActive(true);
        playerInputField.text = "";
        

        nextButton.SetActive(true);
        yellowButton.SetActive(false);
    }

    //este es para cambiar las metricas:p
    void ApplyChatStats(int option)
    {
        
        if (chatID == 2)
        {
            if (option == 1)
            {
                ModifyStats(0, +10, +10);
            }
            else
            {
                ModifyStats(0, 0, +10);
            }
        }

        
        else if (chatID == 4)
        {
            if (option == 1)
            {
                ModifyStats(+10, 0, 0); 
            }
            else
            {
                ModifyStats(0, 0, -10); 
            }
        }

        else if (chatID == 5)
        {
            if (option == 1)
            {
                ModifyStats(+10, 0, 0);
            }
            else
            {
                ModifyStats(-10, 0, +10);
            }
        }

       
        else if (chatID == 6)
        {
            if (option == 1)
            {
                ModifyStats(+10, 0, -10);
            }
            else
            {
                ModifyStats(-10, 0, +10);
            }
        }

        else if (chatID == 7)
        {
            if (option == 1)
            {
                ModifyStats(+10, 0, 0);
            }
            else
            {
                ModifyStats(0, 0, +10);
            }
        }


        else
        {
            
        }
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