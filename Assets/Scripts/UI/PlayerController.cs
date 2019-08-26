using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Text currencyText;
    public Text currencyValueText;
    public Text currencyTextUnits;
    public Text currencyValueTextUnits;
    public Text populationText;
    public Text populationValueText;
    public int currency;
    public float population;
    public int speed;
    public Image speedGrn;
    public Image speedRed;
    public Image speedYellow;
    public bool unitsBtnWasClicked = true;
    public GameObject allUnits;

    // Start is called before the first frame update
    void Start()
    {
        GetSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        currencyValueText.text = currency.ToString();
        currencyValueTextUnits.text = currency.ToString();
        populationValueText.text = population.ToString();
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

    public void UnitsBtnClick()
    {
        if (unitsBtnWasClicked)
        {
            unitsBtnWasClicked = false;
            //Hide These
            currencyText.gameObject.SetActive(false);
            currencyValueText.gameObject.SetActive(false);
            populationText.gameObject.SetActive(false);
            populationValueText.gameObject.SetActive(false);
            //Show These
            allUnits.gameObject.SetActive(true);
            currencyTextUnits.gameObject.SetActive(true);
            currencyValueTextUnits.gameObject.SetActive(true);
        }
        else
        {
            unitsBtnWasClicked = true;
            //Hide These
            allUnits.gameObject.SetActive(false);
            currencyTextUnits.gameObject.SetActive(false);
            currencyValueTextUnits.gameObject.SetActive(false);

            //Show These
            currencyText.gameObject.SetActive(true);
            currencyValueText.gameObject.SetActive(true);
            populationText.gameObject.SetActive(true);
            populationValueText.gameObject.SetActive(true);
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
