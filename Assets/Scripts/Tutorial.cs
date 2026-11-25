using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial1;
    public GameObject tutorial1entre2;
    public GameObject tutorial2;
    public GameObject tutorial3;
    public GameObject tutorial4;
    public GameObject tutorial5;
    public GameObject tutorial6;
    public GameObject tutorial7;
    public GameObject tutorial8;

    void Start()
    {

        GameData.Load();

        if (tutorial1 != null)
        {
            tutorial1.SetActive(true);
        }
    }

    public void Abrir1()
    {
        tutorial1.SetActive(true);
    }

    public void Continuar1()
    {
        tutorial1.SetActive(false);
        tutorial1entre2.SetActive(true);
    }


    public void Continuar2()
    {
        tutorial1entre2.SetActive(false);
        tutorial2.SetActive(true);
    }

    public void Continuar3()
    {
        tutorial2.SetActive(false);
        tutorial3.SetActive(true);
    }

    public void Continuar4()
    {
        tutorial3.SetActive(false);
        tutorial4.SetActive(true);
    }

    public void Continuar5()
    {
        tutorial4.SetActive(false);
        tutorial5.SetActive(true);
    }

    public void Continuar6()
    {
        tutorial5.SetActive(false);
        tutorial6.SetActive(true);
    }

    public void Continuar7()
    {
        tutorial6.SetActive(false);
        tutorial7.SetActive(true);
    }
    public void Continuar8()
    {
        tutorial7.SetActive(false);
        tutorial8.SetActive(true);
    }

    public void Final()
    {
        tutorial8.SetActive(false);

        GameData.didCustomization = true;

        GameData.Save();
        int fromPrologue = PlayerPrefs.GetInt("FromPrologue", 0);

        if (fromPrologue == 1)
        {
            PlayerPrefs.DeleteKey("FromPrologue");
            SceneManager.LoadScene("Publicaciones");
        }
        else
        {
            SceneManager.LoadScene("PantallaInicio");
        }
    }

}
