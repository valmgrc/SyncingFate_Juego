using UnityEngine;

public class IconoChatController : MonoBehaviour
{
    public GameObject iconoRojo;

    void Update()
    {
        iconoRojo.SetActive(GameData.chat1Unlocked && !GameData.chat1Read);
    }
}