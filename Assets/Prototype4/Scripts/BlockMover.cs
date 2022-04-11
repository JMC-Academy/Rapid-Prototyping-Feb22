using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum Orientation { North, East, South, West}
public enum RotationOptions { Vertical, Horizontal, Both}
public class BlockMover : GameBehaviour
{
    public float speed = 0.2f;
    float currentSpeed;
    public float tweenTime = 0.2f;
    public Ease tweenEase;
    public Orientation orientation;
    public RotationOptions rotationOptions;
    bool rotating = false;
    bool moving = false;
    bool canMove = true;

    public Transform pivot;
    public Transform numberOne;
    public Transform numberTwo;
    // Start is called before the first frame update
    void Start()
    {
        orientation = Orientation.North;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
            return;

        if(transform.position.y <= _BM.bottomBound)
        {
            canMove = false;
            Vector3 temp = transform.position;
            temp.y = _BM.bottomBound;
            transform.position = temp;
        }

        transform.Translate(Vector3.down * Time.deltaTime * currentSpeed);

        if (Input.GetKey(KeyCode.DownArrow))
            currentSpeed = speed * 6;
        else
            currentSpeed = speed;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            RotateBlock(-90);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            RotateBlock(90);
            //RotateBlock(rotationOptions == RotationOptions.Vertical ? 180 : 90);

        if (Input.GetKeyDown(KeyCode.A))
            MoveBlock(-1);
        if (Input.GetKeyDown(KeyCode.D))
            MoveBlock(1);
    }

    void MoveBlock(float dir)
    {
        if (CanMove())
        {
            dir = Mathf.Clamp(dir, 0, _BM.gridWidth);
            if (moving == false)
            {
                moving = true;
                transform.DOMoveX(dir, tweenTime).SetRelative(true).SetEase(tweenEase).OnComplete(() => moving = false);
            }
        }
    }

    void RotateBlock(float dir)
    {
        if (rotating == false)
        {
            rotating = true;
            pivot.transform.DORotate(new Vector3(0, 0, dir), tweenTime).SetRelative(true).SetEase(tweenEase).OnComplete(() => rotating = false);
        }
    }

    bool CanMove()
    {
        return transform.position.x != 0 || transform.position.x != _BM.gridWidth;
    }
}
