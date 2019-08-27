using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Currency Text and TxtValues for UI
    public Text currencyText;
    public Text currencyValueText;
    public Text currencyTextUnits;
    public Text currencyValueTextUnits;

    //Population Text and TxtValues for UI
    public Text populationText;
    public Text populationValueText;

    //Vars
    public int speed;
    public Image speedGrn;
    public Image speedRed;
    public Image speedYellow;
    public bool unitsBtnWasClicked = true;
    public GameObject allUnits;

    //Units
    public ScriptableUnits Unit1;
    public ScriptableUnits Unit2;
    public ScriptableUnits Unit3;

    //Unit UI Vars
    public Image U1_Image;
    public Text U1_txtType;
    public Text U1_txtCost;
    public Image U2_image;
    public Text U2_txtType;
    public Text U2_txtCost;
    public Image U3_Image;
    public Text U3_txtType;
    public Text U3_txtCost;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        GetSpeed();
        setUnitsUI();
    }

    // Update is called once per frame
    void Update()
    {
        currencyValueText.text = GameManager.currency.ToString();
        currencyValueTextUnits.text = GameManager.currency.ToString();
        populationValueText.text = GameManager.population.ToString();
    }

    public void SpeedChange()
    {
        switch (speed)
        {
            case 1:
                speed++;
                Time.timeScale = 2f;
                speedYellow.gameObject.SetActive(true);
                break;
            case 2:
                speed++;
                Time.timeScale = 3f;
                speedRed.gameObject.SetActive(true);
                break;
            case 3:
                Time.timeScale = 1f;
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

    void setUnitsUI()
    {
        U1_Image.sprite = Unit1.unitImage;
        U1_txtType.text = Unit1.unitType;
        U1_txtCost.text = Unit1.unitCost.ToString();
        U2_image.sprite = Unit2.unitImage;
        U2_txtType.text = Unit2.unitType;
        U2_txtCost.text = Unit2.unitCost.ToString();
        U3_Image.sprite = Unit3.unitImage;
        U3_txtType.text = Unit3.unitType;
        U3_txtCost.text = Unit3.unitCost.ToString();
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
