using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenChat : MonoBehaviour
{
    public void OpenChatByID(int id)
    {
        GameData.chatsRead[id] = true;
        GameData.Save();

        PlayerPrefs.SetInt("currentChat", id);

        SceneManager.LoadScene("PantallaConversaciones"); 
    }
}