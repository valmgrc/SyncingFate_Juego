using UnityEngine;
using UnityEngine.SceneManagement;

public class BarraNavegacion : MonoBehaviour
{
    public GameObject notifChatIcono;

    void Start()
    {
        GameData.Load();
        RefreshChatNotification();
    }

    /// <summary>Activa o desactiva el punto rojo del icono de chats según si hay chats sin leer.</summary>
    void RefreshChatNotification()
    {
        if (notifChatIcono == null) return;
        notifChatIcono.SetActive(HasUnreadChat());
    }

    /// <summary>Devuelve true si existe al menos un chat desbloqueado que no ha sido leído.</summary>
    bool HasUnreadChat()
    {
        for (int i = 0; i < GameData.chatsUnlocked.Length; i++)
        {
            if (GameData.chatsUnlocked[i] && !GameData.chatsRead[i])
                return true;
        }
        return false;
    }

    public void Home(string PantallaInicio)
    {
        SceneManager.LoadScene(PantallaInicio);
    }

    public void Chats(string PantallaChatsInicio)
    {
        SceneManager.LoadScene(PantallaChatsInicio);
    }

    public void Publicaciones()
    {
        SceneManager.LoadScene("Publicaciones");
    }

    public void Calendario(string PantallaCalendario)
    {
        SceneManager.LoadScene(PantallaCalendario);
    }
}
