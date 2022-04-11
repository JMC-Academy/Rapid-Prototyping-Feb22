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

    public int GetNumber()
    {
        return myNumber;
    }

    private void Update()
    {
        numberText.transform.position = transform.position;
        Debug.Log(GetPosition());
    }

    Vector2 GetPosition()
    {
        return new Vector2(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y));
    }
}
