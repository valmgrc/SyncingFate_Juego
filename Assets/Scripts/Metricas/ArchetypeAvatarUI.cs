using UnityEngine;
using UnityEngine.UI;

public class ArchetypeAvatarUI : MonoBehaviour
{
    public Image avatarImage;

    public Sprite archetype1;
    public Sprite archetype2;
    public Sprite archetype3;

    void Start()
    {
        GameData.Load();

        if (GameData.arquetipo == 1)
            avatarImage.sprite = archetype1;

        else if (GameData.arquetipo == 2)
            avatarImage.sprite = archetype2;

        else if (GameData.arquetipo == 3)
            avatarImage.sprite = archetype3;
    }
}