using UnityEngine;

public class AvataresInfo : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;

    public void ActivarValentina()
    {
        if (panel1 != null)
        {
            panel1.SetActive(true);
        }
    }
   
    public void DesactivarValentina()
    {
        if (panel1 != null)
        {
            panel1.SetActive(false);
        }
    }

    public void ActivarAaron()
    {
        if (panel2 != null)
        {
            panel2.SetActive(true);
        }
    }

    public void DesactivarAaron()
    {
        if (panel2 != null)
        {
            panel2.SetActive(false);
        }
    }

    public void ActivarNatalia()
    {
        if (panel3 != null)
        {
            panel3.SetActive(true);
        }
    }

    public void DesactivarNatalia()
    {
        if (panel3 != null)
        {
            panel3.SetActive(false);
        }
    }

    public void ActivarPaula()
    {
        if (panel4 != null)
        {
            panel4.SetActive(true);
        }
    }

    public void DesactivarPaula()
    {
        if (panel4 != null)
        {
            panel4.SetActive(false);
        }
    }
}
