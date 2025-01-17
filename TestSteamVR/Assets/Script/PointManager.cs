using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PointManager : MonoBehaviour
{
    public int Point = 0;
    public int Fat = 0;
    public int Vitamin = 0;
    public TMP_Text pointText;
    public Slider energySlider;
    public Slider fatSlider;
    public Slider vitSlider;
    // Start is called before the first frame update
    void Start()
    {
        updateStartDatatoSlider();
        StartCoroutine(AFK());
    }

    // Update is called once per frame
    void Update()
    {
        updateDatatoText();
        updateDatatoSlider();
    }

    private void updateDatatoText()
    {
        pointText.text = "Point : " + Point;
    }

    private void updateStartDatatoSlider()
    {
        energySlider.maxValue = Point*2;
        fatSlider.maxValue = 100;
        vitSlider.maxValue = 100;
    }
    private void updateDatatoSlider()
    {
        energySlider.value = Point;
        fatSlider.value = Fat;
        vitSlider.value = Vitamin;
    }

    IEnumerator AFK()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            Point -= 1;
            if (Point == 0 || Fat == 100)
            {
                SceneManagers sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagers>();
                sceneManager.LoseActive();
            }
        }
        
    }
}
