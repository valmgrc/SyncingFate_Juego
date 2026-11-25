using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using TMPro;


public class PostSystem : MonoBehaviour
{
    public GameObject normalFeedPanel;
    public GameObject selectPanel;
    public GameObject editPanel;
    public GameObject feedPanel;
    public Text likesText;

    public GameObject popupPrefab;
    public Transform popupContainer;


    int selectedFilter = 0; 
    int selectedImageID; //imagenes post
    
    
    public Image selectedImageUI; 
    public Image finalPostImage;
    public Image feedImage; 

    public Sprite[] images; 
    public Sprite[] imagesChat0; 
    public Sprite[] imagesChat6; 
    public Sprite[] imagesChat7;

    Sprite[] currentImages;

    List<int> publishedImages = new List<int>();
    public GameObject[] postPanels; 
    public Image[] postImages;     
    public Image[] selectImageUIs;  

    void Start()
    {
        if (normalFeedPanel != null) normalFeedPanel.SetActive(false);
        selectPanel.SetActive(false);
        editPanel.SetActive(false);
        feedPanel.SetActive(false);

        SetCurrentImages();
        UpdateSelectPanel();
        LoadPosts();
        DisplayPosts();

        int fromChat = PlayerPrefs.GetInt("FromChat", 0);
        int postState = PlayerPrefs.GetInt("PostState", -1);

        
        PlayerPrefs.SetInt("FromChat", 0);
        PlayerPrefs.SetInt("PostState", -1);

        if (fromChat == 1 && postState == 0)
        {
            selectPanel.SetActive(true);
        }
        else
        {
            if (normalFeedPanel != null) normalFeedPanel.SetActive(true);
        }

       

        LoadFeedImage();
    }


    public void SelectImage(int imageID) 
    { 
        PlayerPrefs.SetInt("SelectedImage", imageID); 
        selectPanel.SetActive(false); 
        editPanel.SetActive(true); 
        feedPanel.SetActive(false); 

        UpdateSelectedImage(); 
    } 
    
    
    void UpdateSelectedImage() 
    { 
        int id = PlayerPrefs.GetInt("SelectedImage", 0); 
       
           if (currentImages != null && id < currentImages.Length)
        {
        selectedImageUI.sprite = currentImages[id];
        }
            else
        {
    
        }
    } 
    
    
    public void ChooseFilter(int filter) 
    { 
        selectedFilter = filter; 
         
    } 
    
    
    public void Publish() 
    {
        int chatID = PlayerPrefs.GetInt("currentChat", 0);

        
        if (chatID == 0)
        {
            if (selectedFilter == 1) 
                ModifyStats(-10, 0, +10);

            else if (selectedFilter == 2)
                ModifyStats(0, +10, +10);

            else if (selectedFilter == 3) 
                ModifyStats(+10, 0, -10);
        }

        else if (chatID == 6)
        {
            if (selectedFilter == 1)
                ModifyStats(0, -10, -10);

            else if (selectedFilter == 2)
                ModifyStats(+10, 0, 0);

            else if (selectedFilter == 3)
                ModifyStats(+10, -10, -10);
        }

        else if (chatID == 7)
        {
            if (selectedFilter == 1)
                ModifyStats(0, 0, +10);

            else if (selectedFilter == 2)
                ModifyStats(+10, -10, 0);

            else if (selectedFilter == 3)
                ModifyStats(+10, -10, -10);
        }


        FindAnyObjectByType<MetricsManagerUI>(); 
        
        Invoke("ShowFeed", 2f);

        int id = PlayerPrefs.GetInt("SelectedImage", 0);

        publishedImages.Add(id);
        SavePosts();

        PlayerPrefs.SetInt("PublishedImage", id);

        PlayerPrefs.SetInt("PostState", 2); 
    } 
    
    void ShowFeed() 
    { 
        selectPanel.SetActive(false); 
        editPanel.SetActive(false); 
        feedPanel.SetActive(true); 
        
        int id = PlayerPrefs.GetInt("SelectedImage", 0);
        if (currentImages != null && id < currentImages.Length)
        {
            finalPostImage.sprite = currentImages[id];
        }

        int likes = GameData.validacion * 2; 
        likesText.text = likes + " likes";

        int chatID = PlayerPrefs.GetInt("currentChat", -1);

        if (chatID >= 0)
        {
            GameData.chatsDone[chatID] = true;

            if (chatID + 1 < GameData.chatsUnlocked.Length)
            {
                GameData.chatsUnlocked[chatID + 1] = true;
                GameData.chatsRead[chatID + 1] = false;
            }

            GameData.Save();
        }

        PlayerPrefs.SetInt("PostState", -1); 
        PlayerPrefs.SetInt("FromChat", 0); 
    }


    public void GoHome() 
    { 
        int chatID = PlayerPrefs.GetInt("currentChat", 0); 

        if (chatID == 0) 
        { 
            GameData.chatsDone[0] = true; 
            GameData.chatsRead[0] = true; 
            GameData.chatsUnlocked[1] = true; 
            GameData.chatsRead[1] = false; 

            GameData.Save(); 

            PlayerPrefs.SetInt("FromChat", 0); 
            PlayerPrefs.SetInt("PostState", -1); 
            
            SceneManager.LoadScene("PantallaInicio"); 
        }
        else if (chatID == 7)
        {
            int average = (GameData.validacion + GameData.vinculos + GameData.autopercepcion) / 3;
            PlayerPrefs.SetInt("EndingType", average >= 50 ? 1 : 0);
            PlayerPrefs.SetInt("FromChat", 0);
            PlayerPrefs.SetInt("PostState", -1);

            SceneManager.LoadScene("Finales");
        }
        else 
        { 
            PlayerPrefs.SetInt("FromChat", 0); 
            PlayerPrefs.SetInt("PostState", -1); 
            SceneManager.LoadScene("PantallaInicio"); 
        }
    } 
    
    

    void LoadFeedImage()
    {
        int id = PlayerPrefs.GetInt("PublishedImage", -1);

        if (id >= 0 && currentImages != null && id < currentImages.Length)
        {
            if (feedImage != null)
                feedImage.sprite = currentImages[id];
        }
    }

    void SetCurrentImages()
    {
        int chatID = PlayerPrefs.GetInt("currentChat", 0);

        if (chatID == 0)
            currentImages = imagesChat0;
        else if (chatID == 6)
            currentImages = imagesChat6;
        else if (chatID == 7)
            currentImages = imagesChat7;
        else
            currentImages = imagesChat0; 
    }

   
    void UpdateSelectPanel()
    {
        if (currentImages == null || selectImageUIs == null) return;

        for (int i = 0; i < selectImageUIs.Length; i++)
        {
            if (i < currentImages.Length && selectImageUIs[i] != null)
                selectImageUIs[i].sprite = currentImages[i];
        }
    }

    void SavePosts()
    {
        string data = string.Join(",", publishedImages);
        PlayerPrefs.SetString("Posts", data);
    }

    void LoadPosts()
    {
        string data = PlayerPrefs.GetString("Posts", "");

        publishedImages.Clear();

        if (!string.IsNullOrEmpty(data))
        {
            string[] split = data.Split(',');

            foreach (string s in split)
            {
                if (int.TryParse(s, out int id))
                {
                    publishedImages.Add(id);
                }
            }
        }
    }

    void DisplayPosts()
    {
        for (int i = 0; i < postPanels.Length; i++)
        {
            if (i < publishedImages.Count)
            {
                postPanels[i].SetActive(true);

                int id = publishedImages[i];

                if (currentImages != null && id < currentImages.Length)
                {
                    postImages[i].sprite = currentImages[id];
                }
            }
            else
            {
                postPanels[i].SetActive(false);
            }
        }
    }

    void ModifyStats(int validacion, int vinculos, int autopercepcion)
    {
        GameData.validacion += validacion;
        GameData.vinculos += vinculos;
        GameData.autopercepcion += autopercepcion;

        GameData.validacion = Mathf.Clamp(GameData.validacion, 0, 100);
        GameData.vinculos = Mathf.Clamp(GameData.vinculos, 0, 100);
        GameData.autopercepcion = Mathf.Clamp(GameData.autopercepcion, 0, 100);

        GameData.Save();

        ShowMultiplePopups(validacion, vinculos, autopercepcion);
    }

    void ShowMultiplePopups(int validacion, int vinculos, int autopercepcion)
    {
        if (validacion != 0)
            CreatePopup("Validación " + (validacion > 0 ? "+" : "") + validacion, 0);

        if (vinculos != 0)
            CreatePopup("Vínculos " + (vinculos > 0 ? "+" : "") + vinculos, 1);

        if (autopercepcion != 0)
            CreatePopup("Autopercepción " + (autopercepcion > 0 ? "+" : "") + autopercepcion, 2);
    }

    
    void CreatePopup(string text, int index)
    {
        GameObject popup = Instantiate(popupPrefab, popupContainer);

        TMP_Text txt = popup.GetComponentInChildren<TMP_Text>();
        txt.text = text;

        popup.transform.localPosition += new Vector3(0, -40 * index, 0);

        CanvasGroup cg = popup.GetComponent<CanvasGroup>();
        StartCoroutine(AnimatePopup(popup.transform, cg));
    }

    IEnumerator AnimatePopup(Transform popup, CanvasGroup cg)
    {
        float duration = 4f;
        float timer = 0f;

        Vector3 startPos = popup.localPosition;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            popup.localPosition = startPos + new Vector3(0, timer * 30f, 0);
            cg.alpha = 1 - (timer / duration);
            yield return null;
        }

        Destroy(popup.gameObject);
    }

}
