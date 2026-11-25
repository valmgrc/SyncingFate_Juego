using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ArchetypeSelector : MonoBehaviour
{
    public GameObject archetype1;
    public GameObject archetype2;
    public GameObject archetype3;

    public GameObject confirmButton;

    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public Animator siguienteAnim;

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;

    private GameObject currentArch = null;
    private int selectedType = 0;

    void Start()
    {
        GameData.Load();

        pos1 = archetype1.transform.position;
        pos2 = archetype2.transform.position;
        pos3 = archetype3.transform.position;

        confirmButton.SetActive(false);
    }
 

    public void OnHoverEnterSiguiente()
    {
        siguienteAnim.SetBool("isHover", true);
    }

    public void OnHoverExitSiguiente()
    {
        siguienteAnim.SetBool("isHover", false);
    }

    public void OnClickSiguiente()
    {
        siguienteAnim.SetTrigger("isSelected");

        Confirm(); 
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

        
            int prevType = selectedType;
            if (prevType == 1) anim1.SetBool("isSelected", false);
            if (prevType == 2) anim2.SetBool("isSelected", false);
            if (prevType == 3) anim3.SetBool("isSelected", false);
        }

        GameObject newArch = GetArch(type);

       
        Vector3 target = GetOriginalPos(newArch) + new Vector3(-1.7f, 0, 0);
        yield return StartCoroutine(MoveTo(newArch, target, 0.3f));

        currentArch = newArch;
        selectedType = type;

    
        SetSelectedAnimation(type);

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

   
    void SetSelectedAnimation(int type)
    {
        anim1.SetBool("isSelected", type == 1);
        anim2.SetBool("isSelected", type == 2);
        anim3.SetBool("isSelected", type == 3);
    }

 
    public void OnHoverEnter(int type)
    {
        GetAnimator(type).SetBool("isHover", true);
    }

    public void OnHoverExit(int type)
    {
        GetAnimator(type).SetBool("isHover", false);
    }

    Animator GetAnimator(int t)
    {
        if (t == 1) return anim1;
        if (t == 2) return anim2;
        return anim3;
    }


    GameObject GetArch(int t)
    {
        if (t == 1) return archetype1;
        if (t == 2) return archetype2;
        return archetype3;
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