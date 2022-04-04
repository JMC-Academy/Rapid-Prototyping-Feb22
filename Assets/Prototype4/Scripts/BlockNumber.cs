using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockNumber : GameBehaviour
{
    public TMP_Text numberText;
    public int myNumber;
    // Start is called before the first frame update
    void Start()
    {
        GenerateNumber();
    }

    void GenerateNumber()
    {
        myNumber = Random.Range(1, 20);
        numberText.text = myNumber.ToString();
    }

    private void Update()
    {
        numberText.transform.position = transform.position;
    }
}
