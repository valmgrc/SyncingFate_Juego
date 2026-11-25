using UnityEngine;

public class CalendarController : MonoBehaviour
{
    public GameObject[] eventSlots; 

    void Start()
    {
        GameData.Load();
        UpdateCalendar();
    }

    void UpdateCalendar()
    {
        for (int i = 0; i < eventSlots.Length; i++)
        {
            if (GameData.eventsCompleted[i])
                eventSlots[i].SetActive(true);
            else
                eventSlots[i].SetActive(false);
        }
    }
}