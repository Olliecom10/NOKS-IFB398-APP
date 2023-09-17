using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EditCost : MonoBehaviour
{
    public string userInput;

    public void ReadInput(TMP_InputField userinput)
    {
        userInput = userinput.text;
        Debug.Log(userInput);
    }

   
}
