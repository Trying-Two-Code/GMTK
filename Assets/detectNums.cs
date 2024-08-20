using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class detectNums : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    private string inputedCode = "";
    public int CodeGuess = 0000;
    public passcode _pascode;
    public GameObject DestroyOnCorrect;

    private void Update()
    {
        if(NumPressed() != 10)
        {
            inputedCode = inputedCode + NumPressed().ToString();
            if(inputedCode.Length >= 4)
            {
                ResetCode();
            }
        }
        if(inputedCode != "")
        {
            text.text = inputedCode;
            for (int i = 0; i < 4 - inputedCode.Length; i++)
            {
                text.text = text.text + "-";
            }
            
        }
        else
        {
            text.text = "(type a number) ---- (type a number)";
        }


    }

    private void ResetCode()
    {
        CodeGuess = int.Parse(inputedCode);
        inputedCode = "";
        text.text = "";
        if(_pascode != null)
        {
            if(_pascode.code == CodeGuess)
            {
                Debug.Log("HORRAY!");
                Destroy(DestroyOnCorrect);
            }
        }
        gameObject.SetActive(false);
    }


    private int NumPressed()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            return 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            return 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            return 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            return 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            return 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            return 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            return 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            return 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            return 8;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            return 9;
        }
        return 10;
    }

}
