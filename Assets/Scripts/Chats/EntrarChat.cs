using UnityEngine;
using UnityEngine.SceneManagement;

public class EntrarChat : MonoBehaviour
{

    public void Chats(string PantallaConversaciones)
    {

        SceneManager.LoadScene(PantallaConversaciones);
    }

    void Start()
    {
        GameData.Load();
        GameData.chat1Read = true;

    }

    public void SalirChats(string PantallaChatsInicio)
    {
        SceneManager.LoadScene(PantallaChatsInicio);
    }
}