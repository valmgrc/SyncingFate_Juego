using UnityEngine;
using UnityEngine.SceneManagement;

public class EventChoiceManager : MonoBehaviour
{
    public GameObject popup;

    int selectedEvent = -1;

    void Start()
    {
        popup.SetActive(false);

        
        if (GameData.chatsDone[8] && GameData.chatsDone[9])
        {
            popup.SetActive(true);
        }
    }

    public void SelectEvent(int id)
    {
        selectedEvent = id;
        
    }

    public void ConfirmEvent()
    {
        if (selectedEvent == -1) return;

        PlayerPrefs.SetInt("SelectedEvent", selectedEvent);

        SceneManager.LoadScene("Eventos");
    }
}