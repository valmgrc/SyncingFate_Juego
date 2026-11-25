using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChatListController : MonoBehaviour
{
    class ChatContact
    {
        public string name;
        public int chatID;
    }

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

    int GetLatestChatIDForContact(string contact)
    {
        int latestID = -1;

        for (int i = 0; i < GameData.chatsDone.Length; i++)
        {
            if (GetName(i) == contact && (GameData.chatsUnlocked[i] || GameData.chatsDone[i]))
            {
                latestID = i;
            }
        }

        return latestID;
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
            case 8: return "Oye...";
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
            case 7: return "Aarón";
            case 8: return "Ángela";
            default: return "???";
        }
    }

    void UpdateChatList()
    {
        string[] contactosBase = { "Valentina", "Ángela", "Natalia", "Paula", "Aarón" };

        List<ChatContact> lista = new List<ChatContact>();

        // Obtener el último chat de cada contacto
        foreach (string contacto in contactosBase)
        {
            int latestID = GetLatestChatIDForContact(contacto);

            if (latestID != -1)
            {
                lista.Add(new ChatContact
                {
                    name = contacto,
                    chatID = latestID
                });
            }
        }

        // 🔥 ORDENAR: más reciente arriba
        lista.Sort((a, b) => b.chatID.CompareTo(a.chatID));

        // UI
        for (int i = 0; i < chatItems.Length; i++)
        {
            if (i >= lista.Count)
            {
                chatItems[i].SetActive(false);
                continue;
            }

            ChatContact chat = lista[i];

            chatItems[i].SetActive(true);

            nameTexts[i].text = chat.name;

            if (GameData.chatsRead[chat.chatID])
                previewTexts[i].text = "Leído";
            else
                previewTexts[i].text = GetPreview(chat.chatID);

            redDots[i].SetActive(GameData.chatsUnlocked[chat.chatID] && !GameData.chatsRead[chat.chatID]);

            chatButtons[i].interactable = !GameData.chatsDone[chat.chatID];

            int capturedID = chat.chatID;

            chatButtons[i].onClick.RemoveAllListeners();
            chatButtons[i].onClick.AddListener(() =>
            {
                PlayerPrefs.SetInt("currentChat", capturedID);
                UnityEngine.SceneManagement.SceneManager.LoadScene("PantallaConversaciones");
            });
        }
    }



}