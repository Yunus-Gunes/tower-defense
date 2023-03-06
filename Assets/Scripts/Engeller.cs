using UnityEngine;
using UnityEngine.UI;

public class Engeller : MonoBehaviour
{

    private int tus = 0;


    public GameObject ok;



    void OnMouseDown()
    {
        if (tus == 0) { 
            gameObject.tag = "Enemy";
            tus = 1;

            ok.SetActive(true);

        }
        else
        {
            gameObject.tag = "Untagged";
            tus = 0;

            ok.SetActive(false);

        }
    }

   





}
