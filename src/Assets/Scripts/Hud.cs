using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{
    public Animator anim;
    public GameObject primaryCam, secondaryCam, buttonComecar;
    public Slider sliderLoop;
    public TextMeshProUGUI qtdLoop, exercicio;
    private bool isRunning;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        anim.IsInTransition(0);
    }

    public void SetExerc(string exerc)
    {
        if (!isRunning)
        {
            exercicio.text = exerc;
            if (exerc == "Prancha")
            {
                sliderLoop.maxValue = 180;
            }
            else
            {
                sliderLoop.maxValue = 30;
            }
        }
    }

    public void SetLoop(float slider)
    {
        qtdLoop.text = slider.ToString();
        if (exercicio.text == "Prancha")
        {
            anim.SetInteger("Loop", (int)slider/5);
        }
        else
        {
            anim.SetInteger("Loop", (int)slider - 1);
        }
    }

    public void DiminuiLoop()
    {
        int loop = anim.GetInteger("Loop") - 1;
        if (exercicio.text == "Abdominal")
            loop--;
        if (exercicio.text == "Quick Steps")
            loop -= 3;
        anim.SetInteger("Loop", loop);
        loop++;
        if (exercicio.text == "Prancha")
            loop *= 5;
        sliderLoop.SetValueWithoutNotify(loop);
        qtdLoop.text = loop.ToString();
    }

    public void FimLoop()
    {
        anim.SetInteger("Loop", 0);
        sliderLoop.interactable = true;
        anim.SetBool(exercicio.text, false);
        sliderLoop.SetValueWithoutNotify(0);
        qtdLoop.text = "0";

        Image aux = buttonComecar.GetComponent<Image>();
        aux.color = Color.green;

        TextMeshProUGUI text = buttonComecar.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Começar";

        isRunning = false;
    }

    public void PlayAnimation()
    {
        if (!isRunning && !exercicio.text.Equals("Exercício"))
        {
            isRunning = true;
            sliderLoop.interactable = false;
            anim.SetBool(exercicio.text, true);

            Image aux = buttonComecar.GetComponent<Image>();
            aux.color = Color.yellow;

            TextMeshProUGUI text = buttonComecar.GetComponentInChildren<TextMeshProUGUI>();
            text.text = "Espere";
        }
        
    }

    public void ChangeCamera()
    {
        ToggleCamera(primaryCam, secondaryCam);
    }

    void ToggleCamera(GameObject pri, GameObject sec)
    {
        if (pri.activeSelf)
        {
            pri.SetActive(false);
            sec.SetActive(true);
        }
        else
        {
            pri.SetActive(true);
            sec.SetActive(false);
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
