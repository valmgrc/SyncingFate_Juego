using UnityEngine;

public static class GameData
{
    public static int validacion = 50;
    public static int vinculos = 50;
    public static int autopercepcion = 50;

    public static int arquetipo = 0;

    
    public static bool chat1Read = false;
    public static bool chat1Unlocked = false;
    public static bool chat1Done = false;

    public static bool[] chatsUnlocked;
    public static bool[] chatsRead;
    public static bool[] chatsDone;

    public static int body = 0;
    public static int face = 0;
    public static int hair = 0;
    public static int outfit = 0;

    public static string playerName = "Tú";

    public static bool didCustomization = false;

    static int totalChats = 20;

    public static bool[] eventsCompleted;
    static int totalEvents = 5;

    //

    static void InitIfNeeded()
    {
        if (chatsUnlocked == null || chatsUnlocked.Length == 0)
        {
            chatsUnlocked = new bool[totalChats];
            chatsRead = new bool[totalChats];
            chatsDone = new bool[totalChats];
        }

        if (eventsCompleted == null || eventsCompleted.Length == 0)
        {
            eventsCompleted = new bool[totalEvents];
        }
    }

    // 

    public static void ResetData()
    {
        validacion = 50;
        vinculos = 50;
        autopercepcion = 50;

        chat1Read = false;
        chat1Unlocked = false;
        chat1Done = false;

        InitIfNeeded();

        for (int i = 0; i < totalChats; i++)
        {
            chatsUnlocked[i] = false;
            chatsRead[i] = false;
            chatsDone[i] = false;
        }
    }

    
    public static void ResetAll()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        validacion = 50;
        vinculos = 50;
        autopercepcion = 50;
        arquetipo = 0;
        body = 0;
        face = 0;
        hair = 0;
        outfit = 0;
        playerName = "Tú";
        didCustomization = false;
        chat1Read = false;
        chat1Unlocked = false;
        chat1Done = false;

        InitIfNeeded();

        for (int i = 0; i < totalChats; i++)
        {
            chatsUnlocked[i] = false;
            chatsRead[i] = false;
            chatsDone[i] = false;
        }

        for (int i = 0; i < totalEvents; i++)
        {
            eventsCompleted[i] = false;
        }
    }

    // 

    public static void Save()
    {
        PlayerPrefs.SetInt("validacion", validacion);
        PlayerPrefs.SetInt("vinculos", vinculos);
        PlayerPrefs.SetInt("auto", autopercepcion);

        PlayerPrefs.SetInt("arquetipo", arquetipo);

        PlayerPrefs.SetInt("body", body);
        PlayerPrefs.SetInt("face", face);
        PlayerPrefs.SetInt("hair", hair);
        PlayerPrefs.SetInt("outfit", outfit);

        PlayerPrefs.SetString("playerName", playerName);

        PlayerPrefs.SetInt("chat1Read", chat1Read ? 1 : 0);
        PlayerPrefs.SetInt("chat1Unlocked", chat1Unlocked ? 1 : 0);
        PlayerPrefs.SetInt("chat1Done", chat1Done ? 1 : 0);

        PlayerPrefs.SetInt("didCustomization", didCustomization ? 1 : 0);

        InitIfNeeded();

        for (int i = 0; i < totalChats; i++)
        {
            PlayerPrefs.SetInt("chatUnlocked_" + i, chatsUnlocked[i] ? 1 : 0);
            PlayerPrefs.SetInt("chatRead_" + i, chatsRead[i] ? 1 : 0);
            PlayerPrefs.SetInt("chatDone_" + i, chatsDone[i] ? 1 : 0);
        }

        for (int i = 0; i < totalEvents; i++)
        {
            PlayerPrefs.SetInt("event_" + i, eventsCompleted[i] ? 1 : 0);
        }

        PlayerPrefs.Save();
    }

    //
    public static void Load()
    {
        InitIfNeeded();

        validacion = PlayerPrefs.GetInt("validacion", 50);
        vinculos = PlayerPrefs.GetInt("vinculos", 50);
        autopercepcion = PlayerPrefs.GetInt("auto", 50);

        arquetipo = PlayerPrefs.GetInt("arquetipo", 0);

        playerName = PlayerPrefs.GetString("playerName", "Tú");

        for (int i = 0; i < totalChats; i++)
        {
            chatsUnlocked[i] = PlayerPrefs.GetInt("chatUnlocked_" + i, 0) == 1;
            chatsRead[i] = PlayerPrefs.GetInt("chatRead_" + i, 0) == 1;
            chatsDone[i] = PlayerPrefs.GetInt("chatDone_" + i, 0) == 1;
        }

        didCustomization = PlayerPrefs.GetInt("didCustomization", 0) == 1;
 
        if (!chatsUnlocked[0] && !chatsDone[0])
        {
            chatsUnlocked[0] = true;
        }

        for (int i = 0; i < totalEvents; i++)
        {
            eventsCompleted[i] = PlayerPrefs.GetInt("event_" + i, 0) == 1;
        }
    }
}