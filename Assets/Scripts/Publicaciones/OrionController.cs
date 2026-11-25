using UnityEngine;

public class OrionController : MonoBehaviour
{
    public GameObject feedPanel;
    public GameObject selectPanel;
    public GameObject editPanel;
    public GameObject resultPanel;

    void Awake()
    {
        feedPanel.SetActive(false);
        selectPanel.SetActive(false);
        editPanel.SetActive(false);
        resultPanel.SetActive(false);

        int source = PlayerPrefs.GetInt("YellowSource", -1);

        

        if (source == -1)
        {
            
            feedPanel.SetActive(true);
            selectPanel.SetActive(false);
            editPanel.SetActive(false);
        }
        else
        {
            
            feedPanel.SetActive(false);
            selectPanel.SetActive(true);
            editPanel.SetActive(false);
        }
    }
}