using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChatListController : MonoBehaviour
{
    public GameObject[] chatItems;     
    public Text[] previewTexts;       
    public GameObject[] redDots;     
    public Button[] chatButtons;

    public TMP_Text[] nameTexts;


    void Start()
    {
        

        GameData.Load();
        UpdateChatList();

    }

    string GetPreview(int id)
    {
        switch (id)
        {
            case 0: return "¿Ya revisaste la nueva...";
            case 1: return "¿Estrenando cuenta de ORION? Vi tu...";
            case 2: return "Loba! Ya andas robando likes...";
            case 3: return "Recuerdas a Natalia?";
            case 4: return "Vi que saliste de fiesta";
            case 5: return "Hey!";
            case 6: return "???";
            case 7: return "Hola perdida…";
            default: return "...";
        }
    }

    string GetName(int id)
    {
        switch (id)
        {
            case 0: return "Valentina";
            case 1: return "Ángela";
            case 2: return "Valentina";
            case 3: return "Valentina";
            case 4: return "Ángela";
            case 5: return "Natalia";
            case 6: return "Paula";
            case 7: return "Aaron";
            default: return "???";
        }
    }

    void UpdateChatList()
    {
        for (int i = 0; i < chatItems.Length; i++)
        {
            nameTexts[i].text = GetName(i);
            if (GameData.chatsUnlocked[i] || GameData.chatsDone[i])
                chatItems[i].SetActive(true);
            
            else
                chatItems[i].SetActive(false);

            
            if (GameData.chatsRead[i])
                previewTexts[i].text = "Leído";
            else
                previewTexts[i].text = GetPreview(i);
            
            redDots[i].SetActive(GameData.chatsUnlocked[i] && !GameData.chatsRead[i]);

            chatButtons[i].interactable = !GameData.chatsDone[i];
        }
    }

    
    
}