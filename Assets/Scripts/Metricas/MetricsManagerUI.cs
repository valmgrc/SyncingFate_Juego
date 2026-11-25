using UnityEngine;
using UnityEngine.UI;

public class MetricsManagerUI : MonoBehaviour
{
    public Image validacionImage;
    
    public Image autoImage;
    public Image vinculosImage;

    public Sprite[] purpleMetrics;
    public Sprite[] blueMetrics;
    public Sprite[] redMetrics;

    Sprite[] currentSet;

    void Start()
    {
        GameData.Load();

        SetArchetypeSprites();
        UpdateMetrics();
    }

    // 

    void SetArchetypeSprites()
    {
        if (GameData.arquetipo == 1)
            currentSet = blueMetrics;

        else if (GameData.arquetipo == 2)
            currentSet = redMetrics;

        else if (GameData.arquetipo == 3)
            currentSet = purpleMetrics;

        Debug.Log("Arquetipo: " + GameData.arquetipo);
    }

    // 

    public void UpdateMetrics()
    {
        validacionImage.sprite = GetSprite(GameData.validacion);
        vinculosImage.sprite = GetSprite(GameData.vinculos);
        autoImage.sprite = GetSprite(GameData.autopercepcion);
    }

    // 

    Sprite GetSprite(int value)
    {
        int index = Mathf.Clamp(value / 10, 0, currentSet.Length - 1);
        return currentSet[index];
    }
}