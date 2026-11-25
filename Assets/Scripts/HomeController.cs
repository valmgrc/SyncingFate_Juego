using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeController : MonoBehaviour
{
    public GameObject notifMensaje;

    void Start()
    {
        GameData.Load();

        if (!GameData.chatsUnlocked[0])
        {
            GameData.chatsUnlocked[0] = true;
            GameData.chatsRead[0] = false;
        }

        UnlockNextChat();
        CheckBranchChat();

        GameData.Save();

        int current = GetCurrentChat();

        if (current >= 0 && !GameData.chatsRead[current])
        {
            if (notifMensaje != null) notifMensaje.SetActive(true);
        }
    }

    int GetCurrentChat()
    {
        for (int i = 0; i < GameData.chatsUnlocked.Length; i++)
        {
            if (GameData.chatsUnlocked[i] && !GameData.chatsDone[i])
                return i;
        }
        return -1;
    }

    void UnlockNextChat()
    {
        for (int i = 0; i < GameData.chatsUnlocked.Length; i++)
        {
            if (!GameData.chatsUnlocked[i])
            {
                if (i == 0 || GameData.chatsDone[i - 1])
                {
                    GameData.chatsUnlocked[i] = true;
                    GameData.chatsRead[i] = false;

                    
                }
                break;
            }
        }
    }

    void CheckNextChat()
    {
        for (int i = 0; i < GameData.chatsUnlocked.Length; i++)
        {
            if (!GameData.chatsUnlocked[i])
            {
                if (i == 0 || GameData.chatsDone[i - 1])
                {
                    GameData.chatsUnlocked[i] = true;
                    GameData.chatsRead[i] = false;

                    GameData.Save();

                    if (notifMensaje != null) notifMensaje.SetActive(true);
                }

                break;
            }
        }
    }

    void CheckBranchChat()
    {
        if (GameData.chatsDone[9])
        {
            int eventID = PlayerPrefs.GetInt("LastEventPlayed", 0);

            if (eventID == 0)
                GameData.chatsUnlocked[10] = true;
            else
                GameData.chatsUnlocked[11] = true;

            GameData.Save();
        }
    }
}