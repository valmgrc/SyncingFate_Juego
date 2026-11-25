using UnityEngine;
using UnityEngine.UI;

public class MetricsManagerUI : MonoBehaviour
{
    public Image validacionImage;
    public Image autoImage;
    public Image vinculosImage;

    
    public Sprite[] validacionSprites;     
    public Sprite[] vinculosSprites;      
    public Sprite[] autoSprites;          

    void Start()
    {
        GameData.Load();
        UpdateMetrics();
    }

    public void UpdateMetrics()
    {
        validacionImage.sprite = GetSprite(GameData.validacion, validacionSprites);
        vinculosImage.sprite = GetSprite(GameData.vinculos, vinculosSprites);
        autoImage.sprite = GetSprite(GameData.autopercepcion, autoSprites);
    }

    Sprite GetSprite(int value, Sprite[] sprites)
    {
        int index = Mathf.Clamp(value / 10, 0, sprites.Length - 1);
        return sprites[index];
    }
}