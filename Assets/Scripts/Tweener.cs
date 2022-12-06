using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using DG;

public class Tweener : MonoBehaviour
{
    public GameObject target;
    public GameObject test;
    public GameObject endPos;
    public GameObject otherEndPos;
    public GameObject rotatePos;
    public bool thatOne = true;
    public bool rotationBool = true;
    public bool colorBool = false;
    public bool alphaBool = false;
    public int dist;
    public int id;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveLT()
    {
        if (thatOne)
        {
            LeanTween.move(target, endPos.transform.position, 2.0f).setEase(LeanTweenType.pingPong);
        }
        else if (!thatOne)
        {
            LeanTween.move(target, otherEndPos.transform.position, 2.0f).setEase(LeanTweenType.pingPong);
        }
        thatOne = !thatOne;
        
    }

    public void MoveDT()
    {
        if (thatOne)
        {
            target.GetComponent<Rigidbody>().DOMove(endPos.transform.position, 2.0f);
        }
        else if (!thatOne)
        {
            target.GetComponent<Rigidbody>().DOMove(otherEndPos.transform.position, 2.0f);
        }

        thatOne = !thatOne;
        
    }

    public void RotateLT()
    {
        if (rotationBool)
        {
            LeanTween.rotateY(target, 90, 2.0f);
        }
        else
        {
            LeanTween.rotateY(target, 180, 2.0f);
        }

        rotationBool = !rotationBool;
    }

    public void RotateDT()
    {
        if (rotationBool)
        {
            target.GetComponent<Rigidbody>().DORotate(rotatePos.transform.rotation.eulerAngles, 2.0f, RotateMode.LocalAxisAdd);
        }
        else
        {
            target.GetComponent<Rigidbody>().DORotate(-rotatePos.transform.rotation.eulerAngles, 2.0f, RotateMode.LocalAxisAdd);
        }

        rotationBool = !rotationBool;
    }

    public void ColorLT()
    {
        if (colorBool)
        {
            LeanTween.color(test, Color.green, 1.0f);
            Debug.Log("Green");
        }
        else
        {
            LeanTween.color(test, Color.white, 1.0f);
            Debug.Log("White");
        }

        colorBool = !colorBool;
    }
    public void ColorDT()
    {
        if (colorBool)
        {
            target.GetComponent<MeshRenderer>().material.DOColor(Color.green, 1.0f);
            Debug.Log("Green");
        }
        else
        {
            target.GetComponent<MeshRenderer>().material.DOColor(Color.white, 1.0f);
            Debug.Log("White");
        }

        colorBool = !colorBool;
    }


    public void AlphaLT()
    {
        if (alphaBool)
        {
            LeanTween.alpha(target, 0, 2.0f);
        }
        else
        {
            LeanTween.alpha(target, 1, 2.0f);
        }

        alphaBool = !alphaBool;
    }

    public void AlphaDT()
    {
        if (alphaBool)
        {
            target.GetComponent<MeshRenderer>().material.DOFade(0, 2.0f);
        }
        else
        {
            target.GetComponent<MeshRenderer>().material.DOFade(1, 2.0f);
        }

        alphaBool = !alphaBool;
    }

    public void MultitweenLT()
    {
        LTDescr descr = LeanTween.descr(id);
        if (thatOne)
        {
            id = LeanTween.move(target, endPos.transform.position, 2.0f).setOnComplete(AlphaDT).id;
        }
        else
        {
            id = LeanTween.move(target, otherEndPos.transform.position, 2.0f).setOnComplete(ColorDT).id;
        }

        thatOne = !thatOne;
    }

    public void MultitweenDT()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(target.transform.DOMove(endPos.transform.position, 2.0f))
            .Append(target.GetComponent<MeshRenderer>().material.DOColor(Color.blue, 1.0f))
            .Append(target.transform.DOMove(otherEndPos.transform.position, 2.0f))
            .Append(target.GetComponent<MeshRenderer>().material.DOFade(0, 1.0f));
    }


}
