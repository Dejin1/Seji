using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text currencyText;
    public Text currencyTextUnits;
    public int currency;
    public Text populationText;
    public float population;
    public int speed;
    public Image speedGrn;
    public Image speedRed;
    public Image speedYellow;
   
    // Start is called before the first frame update
    void Start()
    {
        GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = currency.ToString();
        currencyTextUnits.text = currency.ToString();
        populationText.text = population.ToString();
    }

    public void SpeedChange()
    {
        switch (speed)
        {
            case 1:
                speed++;
                speedYellow.gameObject.SetActive(true);
                break;
            case 2:
                speed++;
                speedRed.gameObject.SetActive(true);
                break;
            case 3:
                speedYellow.gameObject.SetActive(false);
                speedRed.gameObject.SetActive(false);
                speed = 1;
                break;
            default:
                Debug.Log("Error Speed variable not 1-3");
                break;
        }
    }

    void GetSpeed()
    {
        switch (speed)
        {
            case 1:
                speedGrn.gameObject.SetActive(true);
                speedYellow.gameObject.SetActive(false);
                speedRed.gameObject.SetActive(false);
                break;
            case 2:
                speedGrn.gameObject.SetActive(true);
                speedYellow.gameObject.SetActive(true);
                speedRed.gameObject.SetActive(false);
                break;
            case 3:
                speedGrn.gameObject.SetActive(true);
                speedYellow.gameObject.SetActive(true);
                speedRed.gameObject.SetActive(true);
                speed = 1;
                break;
            default:
                Debug.Log("Error Speed variable not 1-3");
                break;
        }
    }
}
