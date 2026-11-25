using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NotificationController : MonoBehaviour
{
    public GameObject notificationPanel;
    public TMP_Text nameText;
    public TMP_Text previewText;

    int currentChatID = -1;

    
    void Start()
    {
        GameData.Load();
        CheckNotification();
    }

    void CheckNotification()
    {
        for (int i = 0; i < GameData.chatsUnlocked.Length; i++)
        {
            if (GameData.chatsUnlocked[i] && !GameData.chatsRead[i])
            {
                currentChatID = i;

                notificationPanel.SetActive(true);

                nameText.text = GetName(i);
                previewText.text = GetPreview(i);

                return;
            }
        }

       
        notificationPanel.SetActive(false);
    }

    
    public void OpenChatFromNotification()
    {
        if (currentChatID == -1) return;

        PlayerPrefs.SetInt("currentChat", currentChatID);

        SceneManager.LoadScene("PantallaConversaciones"); 
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
                //aqui se termina
            case 8: return "Ángela";
            case 9: return "Paula";
            case 10: return "Paula";
            case 11: return "Ángela";
            case 12: return "Luka";
            case 13: return "Natalia";
            case 14: return "Desconocido";
            case 15: return "Ángela";
            case 16: return "Natalia";
            case 17: return "Natalia";
            case 18: return "Paula";
            case 19: return "Ángela";
            default: return "???";
        }
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
}