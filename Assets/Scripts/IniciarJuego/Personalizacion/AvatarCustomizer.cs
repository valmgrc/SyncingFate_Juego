using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvatarCustomizer : MonoBehaviour
{
    public Image bodyImage;
    public Image faceImage;
    public Image hairImage;
    public Image outfitImage;

    public Sprite[] bodies;
    public Sprite[] faces;
    public Sprite[] hairs;
    //public Sprite[] outfit;

    public Sprite[] outfitBody0; 
    public Sprite[] outfitBody1; 
    public Sprite[] outfitBody2;

    public Animator bodyAnim;
    public Animator faceAnim;
    public Animator hairAnim;
    public Animator outfitAnim;


    
    

    Sprite[] currentOutfits; 


    int currentBody = 0;
    int currentFace = 0;
    int currentHair = 0;
    int currentOutfit = 0;

    void Start()
    {
        LoadAvatar();
        UpdateAvatar();
    }

    


    public void NextBody()
    {
        currentBody = (currentBody + 1) % bodies.Length;
        UpdateAvatar();
    }

    public void NextFace()
    {
        currentFace = (currentFace + 1) % faces.Length;
        UpdateAvatar();
    }

    public void NextHair()
    {
        currentHair = (currentHair + 1) % hairs.Length;
        UpdateAvatar();
    }
    public void NextOutfit()
    {
        currentOutfit = (currentOutfit + 1) % currentOutfits.Length;
        UpdateAvatar();
    }

    

    void UpdateAvatar()
    {
        bodyImage.sprite = bodies[currentBody];
        faceImage.sprite = faces[currentFace];
        hairImage.sprite = hairs[currentHair];

        if (currentBody == 0)
            currentOutfits = outfitBody0;
        else if (currentBody == 1)
            currentOutfits = outfitBody1;
        else if (currentBody == 2)
            currentOutfits = outfitBody2;

        
        currentOutfit = currentOutfit % currentOutfits.Length;

        outfitImage.sprite = currentOutfits[currentOutfit];

    }

    public void OnHoverEnter(int tipo)
    {
        GetAnimator(tipo).SetBool("isHover", true);
    }

    public void OnHoverExit(int tipo)
    {
        GetAnimator(tipo).SetBool("isHover", false);
    }

    Animator GetAnimator(int t)
    {
        if (t == 1) return bodyAnim;
        if (t == 2) return faceAnim;
        if (t == 3) return hairAnim;
        return outfitAnim;
    }

    public void Confirm()
    {
        GameData.body = currentBody;
        GameData.face = currentFace;
        GameData.hair = currentHair;
        GameData.outfit = currentOutfit;



        GameData.Save();

        SceneManager.LoadScene("CreacionPersonaje2");
    }

    void LoadAvatar()
    {
        currentBody = GameData.body;
        currentFace = GameData.face;
        currentHair = GameData.hair;
        currentOutfit = GameData.outfit;
    }
}