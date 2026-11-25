using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ArchetypeSelector : MonoBehaviour
{
    public GameObject archetype1;
    public GameObject archetype2;
    public GameObject archetype3;

    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;

    public GameObject confirmButton;

    private CanvasGroup cg1;
    private CanvasGroup cg2;
    private CanvasGroup cg3;

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;

    private GameObject currentArch = null;
    private CanvasGroup currentCG = null;

    private int selectedType = 0;

    void Start()
    {
        GameData.Load();

        pos1 = archetype1.transform.position;
        pos2 = archetype2.transform.position;
        pos3 = archetype3.transform.position;

        cg1 = panel1.GetComponent<CanvasGroup>();
        cg2 = panel2.GetComponent<CanvasGroup>();
        cg3 = panel3.GetComponent<CanvasGroup>();

       
        cg1.alpha = 0;
        cg2.alpha = 0;
        cg3.alpha = 0;

        confirmButton.SetActive(false);
    }

   

    public void SelectArchetype(int type)
    {
        StopAllCoroutines();
        StartCoroutine(HandleSelection(type));
    }

   

    IEnumerator HandleSelection(int type)
    {
        if (currentArch != null)
        {
            StartCoroutine(MoveTo(currentArch, GetOriginalPos(currentArch), 0.3f));
        }

        if (currentCG != null)
        {
            yield return StartCoroutine(Fade(currentCG, currentCG.alpha, 0, 0.3f));
        }

        GameObject newArch = GetArch(type);
        CanvasGroup newCG = GetCG(type);

        Vector3 target = GetOriginalPos(newArch) + new Vector3(-1.7f, 0, 0);
        yield return StartCoroutine(MoveTo(newArch, target, 0.3f));

        
        yield return StartCoroutine(Fade(newCG, 0, 1, 1f)); 

        
        currentArch = newArch;
        currentCG = newCG;

        selectedType = type;

        confirmButton.SetActive(true);
    }


    IEnumerator MoveTo(GameObject obj, Vector3 target, float duration)
    {
        float t = 0;
        Vector3 start = obj.transform.position;

        while (t < duration)
        {
            t += Time.deltaTime;
            obj.transform.position = Vector3.Lerp(start, target, t / duration);
            yield return null;
        }
    }

    IEnumerator Fade(CanvasGroup cg, float from, float to, float duration)
    {
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Lerp(from, to, t / duration);
            yield return null;
        }
    }

    GameObject GetArch(int t)
    {
        if (t == 1) return archetype1;
        if (t == 2) return archetype2;
        return archetype3;
    }

    CanvasGroup GetCG(int t)
    {
        if (t == 1) return cg1;
        if (t == 2) return cg2;
        return cg3;
    }

    Vector3 GetOriginalPos(GameObject obj)
    {
        if (obj == archetype1) return pos1;
        if (obj == archetype2) return pos2;
        return pos3;
    }



    public void Confirm() 
    {
        

        GameData.arquetipo = selectedType;

        if (selectedType == 1)
        {
            GameData.validacion = 40;
            GameData.vinculos = 70;
            GameData.autopercepcion = 50;
        }
        else if (selectedType == 2)
        {
            GameData.validacion = 70;
            GameData.vinculos = 40;
            GameData.autopercepcion = 50;
        }
        else if (selectedType == 3)
        {
            GameData.validacion = 50;
            GameData.vinculos = 50;
            GameData.autopercepcion = 70;
        }

       

        GameData.Save();

        SceneManager.LoadScene("PersonalizarNombre");

        
        
    }

}