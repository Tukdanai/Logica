using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Boss1 : MonoBehaviour
{
    [SerializeField] LogicBoss boss;
    [SerializeField] public GameObject connector;
    [SerializeField] public GameObject endTank;
    [SerializeField] public GameObject tank;
    [SerializeField] public GameObject tank1;
    [SerializeField] public GameObject tank2;
    [SerializeField] public GameObject tank3;
    [SerializeField] public GameObject tank4;
    [SerializeField] public GameObject tank5;
    [SerializeField] public GameObject tank6;
    [SerializeField] public BoxSlot[] box1;
    [SerializeField] public BoxSlot[] box2;
    [SerializeField] public BoxSlot[] box3;
    [SerializeField] public BoxSlot[] box4;
    [SerializeField] public BoxSlot[] box5;
    [SerializeField] public BoxSlot[] box6;
    [SerializeField] public BoxSlot[] box7;
    [SerializeField] public BoxSlot[] box8;
    [SerializeField] public BoxSlot[] box9;
    [SerializeField] public BoxSlot[] box10;
    [SerializeField] public BoxSlot[] box11;
    [SerializeField] public BoxSlot[] box12;
    [SerializeField] public GameObject box1GameObject;
    [SerializeField] public GameObject box2GameObject;
    [SerializeField] public GameObject box3GameObject;
    [SerializeField] public GameObject box4GameObject;
    [SerializeField] public GameObject box5GameObject;
    [SerializeField] public GameObject box6GameObject;
    [SerializeField] public GameObject box7GameObject;
    [SerializeField] public GameObject box8GameObject;
    [SerializeField] public GameObject box9GameObject;
    [SerializeField] public GameObject box10GameObject;
    [SerializeField] public GameObject box11GameObject;
    [SerializeField] public GameObject box12GameObject;
    private int randomTank;
    private int randomItem;
    public Item ZERO;
    public Item ONE;
    public Item AND;
    public Item OR;
    public Item NOT;
    public Item NAND;
    public Item NOR;
    public Item XOR;
    public Item XNOR;
    private int output1;
    private int output2;
    private int output3;
    private int output4;
    private int output5;
    private int output6;
    public int Answer;

    void Start()
    {
        box1[0].Item = null;
        box2[0].Item = null;
        box3[0].Item = null;
        box4[0].Item = null;
        box5[0].Item = null;
        box6[0].Item = null;
        box7[0].Item = null;
        box8[0].Item = null;
        box9[0].Item = null;
        box10[0].Item = null;
        box11[0].Item = null;
        box12[0].Item = null;
        tank.SetActive(true);
        tank1.SetActive(false);
        tank2.SetActive(false);
        tank3.SetActive(false);
        tank4.SetActive(false);
        tank5.SetActive(false);
        tank6.SetActive(false);
        connector.SetActive(false);
        endTank.SetActive(false);
    }

    void Update()
    {
        if(boss.health <= 0)
        {
            tank.SetActive(false);
            endTank.SetActive(true);
        }
    }

    public void CloseAllPuzzle()
    {
        tank.SetActive(false);
        tank1.SetActive(false);
        tank2.SetActive(false);
        tank3.SetActive(false);
        tank4.SetActive(false);
        tank5.SetActive(false);
        tank6.SetActive(false);
        connector.SetActive(false);
    }

    public void Reset()
    {
        tank.SetActive(true);
        tank1.SetActive(false);
        tank2.SetActive(false);
        tank3.SetActive(false);
        tank4.SetActive(false);
        tank5.SetActive(false);
        tank6.SetActive(false);
        connector.SetActive(false);
        box1[0].Item = null;
        box2[0].Item = null;
        box3[0].Item = null;
        box4[0].Item = null;
        box5[0].Item = null;
        box6[0].Item = null;
        box7[0].Item = null;
        box8[0].Item = null;
        box9[0].Item = null;
        box10[0].Item = null;
        box11[0].Item = null;
        box12[0].Item = null;
    }

    public void ShowPuzzle(int randomTank)
    {
        tank.SetActive(false);
        connector.SetActive(true);
        if(randomTank == 1)
        {
            tank1.SetActive(true);
            box1GameObject.SetActive(true);
            box2GameObject.SetActive(true);
            box3GameObject.SetActive(true);
            box4GameObject.SetActive(true);
            box7GameObject.SetActive(true);
            box8GameObject.SetActive(true);
            box12GameObject.SetActive(true);
            RandomInput(box1);
            RandomInput(box2);
            RandomInput(box3);
            RandomInput(box4);
            RandomLogicGate(box7);
            RandomLogicGate(box8);
            RandomLogicGate(box12);
            Tank1AnswerCalculate();
        }
        else if(randomTank == 2)
        {
            tank2.SetActive(true);
            box1GameObject.SetActive(true);
            box2GameObject.SetActive(true);
            box3GameObject.SetActive(true);
            box4GameObject.SetActive(true);
            box7GameObject.SetActive(true);
            box8GameObject.SetActive(true);
            box10GameObject.SetActive(true);
            box12GameObject.SetActive(true);
            RandomInput(box1);
            RandomInput(box2);
            RandomInput(box3);
            RandomInput(box4);
            RandomLogicGate(box7);
            RandomLogicGate(box8);
            RandomLogicGate(box12);
            box10[0].Item = NOT;
            Tank2AnswerCalculate();
        }
        else if(randomTank == 3)
        {
            tank3.SetActive(true);
            box1GameObject.SetActive(true);
            box2GameObject.SetActive(true);
            box3GameObject.SetActive(true);
            box4GameObject.SetActive(true);
            box7GameObject.SetActive(true);
            box8GameObject.SetActive(true);
            box11GameObject.SetActive(true);
            box12GameObject.SetActive(true);
            RandomInput(box1);
            RandomInput(box2);
            RandomInput(box3);
            RandomInput(box4);
            RandomLogicGate(box7);
            RandomLogicGate(box8);
            RandomLogicGate(box12);
            box11[0].Item = NOT;
            Tank3AnswerCalculate();
        }
        else if(randomTank == 4)
        {
            tank4.SetActive(true);
            box1GameObject.SetActive(true);
            box2GameObject.SetActive(true);
            box3GameObject.SetActive(true);
            box4GameObject.SetActive(true);
            box5GameObject.SetActive(true);
            box6GameObject.SetActive(true);
            box7GameObject.SetActive(true);
            box8GameObject.SetActive(true);
            box9GameObject.SetActive(true);
            box11GameObject.SetActive(true);
            box12GameObject.SetActive(true);
            RandomInput(box1);
            RandomInput(box2);
            RandomInput(box3);
            RandomInput(box4);
            RandomInput(box5);
            RandomInput(box6);
            RandomLogicGate(box7);
            RandomLogicGate(box8);
            RandomLogicGate(box9);
            RandomLogicGate(box11);
            RandomLogicGate(box12);
            Tank4AnswerCalculate();
        }
        else if(randomTank == 5)
        {
            tank5.SetActive(true);
            box1GameObject.SetActive(true);
            box2GameObject.SetActive(true);
            box3GameObject.SetActive(true);
            box4GameObject.SetActive(true);
            box5GameObject.SetActive(true);
            box6GameObject.SetActive(true);
            box7GameObject.SetActive(true);
            box8GameObject.SetActive(true);
            box9GameObject.SetActive(true);
            box10GameObject.SetActive(true);
            box12GameObject.SetActive(true);
            RandomInput(box1);
            RandomInput(box2);
            RandomInput(box3);
            RandomInput(box4);
            RandomInput(box5);
            RandomInput(box6);
            RandomLogicGate(box7);
            RandomLogicGate(box8);
            RandomLogicGate(box9);
            RandomLogicGate(box10);
            RandomLogicGate(box12);
            Tank5AnswerCalculate();
        }
        else if(randomTank == 6)
        {
            tank6.SetActive(true);
            box1GameObject.SetActive(true);
            box2GameObject.SetActive(true);
            box3GameObject.SetActive(true);
            box4GameObject.SetActive(true);
            box5GameObject.SetActive(true);
            box6GameObject.SetActive(true);
            box7GameObject.SetActive(true);
            box8GameObject.SetActive(true);
            box9GameObject.SetActive(true);
            box10GameObject.SetActive(true);
            box11GameObject.SetActive(true);
            box12GameObject.SetActive(true);
            RandomInput(box1);
            RandomInput(box2);
            RandomInput(box3);
            RandomInput(box4);
            RandomInput(box5);
            RandomInput(box6);
            RandomLogicGate(box7);
            RandomLogicGate(box8);
            RandomLogicGate(box9);
            RandomLogicGate(box10);
            RandomLogicGate(box11);
            RandomLogicGate(box12);
            Tank6AnswerCalculate();
        }
    }

    public void RandomInput(BoxSlot[] box)
    {
        randomItem = Random.Range(1, 3);
        if(randomItem == 1) box[0].Item = ZERO;
        else if(randomItem == 2) box[0].Item = ONE;
    }

    public void RandomLogicGate(BoxSlot[] box)
    {
        randomItem = Random.Range(1, 7);
        if(randomItem == 1) box[0].Item = AND;
        else if(randomItem == 2) box[0].Item = OR;
        else if(randomItem == 3) box[0].Item = NAND;
        else if(randomItem == 4) box[0].Item = NOR;
        else if(randomItem == 5) box[0].Item = XOR;
        else if(randomItem == 6) box[0].Item = XNOR;
    }

    public void Tank1AnswerCalculate()
    {
        if(box7[0].Item == AND) output1 = ANDGateCalculator(box1, box2);
        else if(box7[0].Item == OR) output1 = ORGateCalculator(box1, box2);
        else if(box7[0].Item == NAND) output1 = NANDGateCalculator(box1, box2);
        else if(box7[0].Item == NOR) output1 = NORGateCalculator(box1, box2);
        else if(box7[0].Item == XOR) output1 = XORGateCalculator(box1, box2);
        else if(box7[0].Item == XNOR) output1 = XNORGateCalculator(box1, box2);
        Debug.Log("Out1 = " + output1);
        if(box8[0].Item == AND) output2 = ANDGateCalculator(box3, box4);
        else if(box8[0].Item == OR) output2 = ORGateCalculator(box3, box4);
        else if(box8[0].Item == NAND) output2 = NANDGateCalculator(box3, box4);
        else if(box8[0].Item == NOR) output2 = NORGateCalculator(box3, box4);
        else if(box8[0].Item == XOR) output2 = XORGateCalculator(box3, box4);
        else if(box8[0].Item == XNOR) output2 = XNORGateCalculator(box3, box4);
        Debug.Log("Out2 = " + output2);
        if(box12[0].Item == AND)
        {
            if(output1 == 1 && output2 == 1) output3 = 1;
            else output3 = 0;
        }
        else if(box12[0].Item == OR)
        {
            if(output1 == 0 && output2 == 0) output3 = 0;
            else output3 = 1;
        }
        else if(box12[0].Item == NAND)
        {
            if(output1 == 1 && output2 == 1) output3 = 0;
            else output3 = 1;
        }
        else if(box12[0].Item == NOR)
        {
            if(output1 == 0 && output2 == 0) output3 = 1;
            else output3 = 0;
        }
        else if(box12[0].Item == XOR)
        {
            if(output1 == 0 && output2 == 0) output3 = 0;
            else if(output1 == 1 && output2 == 1) output3 = 0;
            else output3 = 1;
        }
        else if(box12[0].Item == XNOR)
        {
            if(output1 == 0 && output2 == 0) output3 = 1;
            else if(output1 == 1 && output2 == 1) output3 = 1;
            else output3 = 0;
        }
        Debug.Log("Out3 = " + output3);
        Answer = output3;
    }

    public void Tank2AnswerCalculate()
    {
        if(box7[0].Item == AND) output1 = ANDGateCalculator(box1, box2);
        else if(box7[0].Item == OR) output1 = ORGateCalculator(box1, box2);
        else if(box7[0].Item == NAND) output1 = NANDGateCalculator(box1, box2);
        else if(box7[0].Item == NOR) output1 = NORGateCalculator(box1, box2);
        else if(box7[0].Item == XOR) output1 = XORGateCalculator(box1, box2);
        else if(box7[0].Item == XNOR) output1 = XNORGateCalculator(box1, box2);
        if(output1 == 0) output1 = 1;
        else if(output1 == 1) output1 = 0;
        Debug.Log("Out1 = " + output1);
        if(box8[0].Item == AND) output2 = ANDGateCalculator(box3, box4);
        else if(box8[0].Item == OR) output2 = ORGateCalculator(box3, box4);
        else if(box8[0].Item == NAND) output2 = NANDGateCalculator(box3, box4);
        else if(box8[0].Item == NOR) output2 = NORGateCalculator(box3, box4);
        else if(box8[0].Item == XOR) output2 = XORGateCalculator(box3, box4);
        else if(box8[0].Item == XNOR) output2 = XNORGateCalculator(box3, box4);
        Debug.Log("Out2 = " + output2);
        if(box12[0].Item == AND)
        {
            if(output1 == 1 && output2 == 1) output3 = 1;
            else output3 = 0;
        }
        else if(box12[0].Item == OR)
        {
            if(output1 == 0 && output2 == 0) output3 = 0;
            else output3 = 1;
        }
        else if(box12[0].Item == NAND)
        {
            if(output1 == 1 && output2 == 1) output3 = 0;
            else output3 = 1;
        }
        else if(box12[0].Item == NOR)
        {
            if(output1 == 0 && output2 == 0) output3 = 1;
            else output3 = 0;
        }
        else if(box12[0].Item == XOR)
        {
            if(output1 == 0 && output2 == 0) output3 = 0;
            else if(output1 == 1 && output2 == 1) output3 = 0;
            else output3 = 1;
        }
        else if(box12[0].Item == XNOR)
        {
            if(output1 == 0 && output2 == 0) output3 = 1;
            else if(output1 == 1 && output2 == 1) output3 = 1;
            else output3 = 0;
        }
        Debug.Log("Out3 = " + output3);
        Answer = output3;
    }

    public void Tank3AnswerCalculate()
    {
        if(box7[0].Item == AND) output1 = ANDGateCalculator(box1, box2);
        else if(box7[0].Item == OR) output1 = ORGateCalculator(box1, box2);
        else if(box7[0].Item == NAND) output1 = NANDGateCalculator(box1, box2);
        else if(box7[0].Item == NOR) output1 = NORGateCalculator(box1, box2);
        else if(box7[0].Item == XOR) output1 = XORGateCalculator(box1, box2);
        else if(box7[0].Item == XNOR) output1 = XNORGateCalculator(box1, box2);
        Debug.Log("Out1 = " + output1);
        if(box8[0].Item == AND) output2 = ANDGateCalculator(box3, box4);
        else if(box8[0].Item == OR) output2 = ORGateCalculator(box3, box4);
        else if(box8[0].Item == NAND) output2 = NANDGateCalculator(box3, box4);
        else if(box8[0].Item == NOR) output2 = NORGateCalculator(box3, box4);
        else if(box8[0].Item == XOR) output2 = XORGateCalculator(box3, box4);
        else if(box8[0].Item == XNOR) output2 = XNORGateCalculator(box3, box4);
        if(output2 == 0) output2 = 1;
        else if(output2 == 1) output2 = 0;
        Debug.Log("Out2 = " + output2);
        if(box12[0].Item == AND)
        {
            if(output1 == 1 && output2 == 1) output3 = 1;
            else output3 = 0;
        }
        else if(box12[0].Item == OR)
        {
            if(output1 == 0 && output2 == 0) output3 = 0;
            else output3 = 1;
        }
        else if(box12[0].Item == NAND)
        {
            if(output1 == 1 && output2 == 1) output3 = 0;
            else output3 = 1;
        }
        else if(box12[0].Item == NOR)
        {
            if(output1 == 0 && output2 == 0) output3 = 1;
            else output3 = 0;
        }
        else if(box12[0].Item == XOR)
        {
            if(output1 == 0 && output2 == 0) output3 = 0;
            else if(output1 == 1 && output2 == 1) output3 = 0;
            else output3 = 1;
        }
        else if(box12[0].Item == XNOR)
        {
            if(output1 == 0 && output2 == 0) output3 = 1;
            else if(output1 == 1 && output2 == 1) output3 = 1;
            else output3 = 0;
        }
        Debug.Log("Out3 = " + output3);
        Answer = output3;
    }

    public void Tank4AnswerCalculate()
    {
        if(box7[0].Item == AND) output1 = ANDGateCalculator(box1, box2);
        else if(box7[0].Item == OR) output1 = ORGateCalculator(box1, box2);
        else if(box7[0].Item == NAND) output1 = NANDGateCalculator(box1, box2);
        else if(box7[0].Item == NOR) output1 = NORGateCalculator(box1, box2);
        else if(box7[0].Item == XOR) output1 = XORGateCalculator(box1, box2);
        else if(box7[0].Item == XNOR) output1 = XNORGateCalculator(box1, box2);
        Debug.Log("Out1 = " + output1);
        if(box8[0].Item == AND) output2 = ANDGateCalculator(box3, box4);
        else if(box8[0].Item == OR) output2 = ORGateCalculator(box3, box4);
        else if(box8[0].Item == NAND) output2 = NANDGateCalculator(box3, box4);
        else if(box8[0].Item == NOR) output2 = NORGateCalculator(box3, box4);
        else if(box8[0].Item == XOR) output2 = XORGateCalculator(box3, box4);
        else if(box8[0].Item == XNOR) output2 = XNORGateCalculator(box3, box4);
        Debug.Log("Out2 = " + output2);
        if(box9[0].Item == AND) output3 = ANDGateCalculator(box5, box6);
        else if(box9[0].Item == OR) output3 = ORGateCalculator(box5, box6);
        else if(box9[0].Item == NAND) output3 = NANDGateCalculator(box5, box6);
        else if(box9[0].Item == NOR) output3 = NORGateCalculator(box5, box6);
        else if(box9[0].Item == XOR) output3 = XORGateCalculator(box5, box6);
        else if(box9[0].Item == XNOR) output3 = XNORGateCalculator(box5, box6);
        Debug.Log("Out3 = " + output3);
        if(box11[0].Item == AND)
        {
            if(output2 == 1 && output3 == 1) output4 = 1;
            else output4 = 0;
        }
        else if(box11[0].Item == OR)
        {
            if(output2 == 0 && output3 == 0) output4 = 0;
            else output4 = 1;
        }
        else if(box11[0].Item == NAND)
        {
            if(output2 == 1 && output3 == 1) output4 = 0;
            else output4 = 1;
        }
        else if(box11[0].Item == NOR)
        {
            if(output2 == 0 && output3 == 0) output4 = 1;
            else output4 = 0;
        }
        else if(box11[0].Item == XOR)
        {
            if(output2 == 0 && output3 == 0) output4 = 0;
            else if(output2 == 1 && output3 == 1) output4 = 0;
            else output4 = 1;
        }
        else if(box11[0].Item == XNOR)
        {
            if(output2 == 0 && output3 == 0) output4 = 1;
            else if(output2 == 1 && output3 == 1) output4 = 1;
            else output4 = 0;
        }
        Debug.Log("Out4 = " + output4);
        if(box12[0].Item == AND)
        {
            if(output1 == 1 && output4 == 1) output5 = 1;
            else output5 = 0;
        }
        else if(box12[0].Item == OR)
        {
            if(output1 == 0 && output4 == 0) output5 = 0;
            else output5 = 1;
        }
        else if(box12[0].Item == NAND)
        {
            if(output1 == 1 && output4 == 1) output5 = 0;
            else output5 = 1;
        }
        else if(box12[0].Item == NOR)
        {
            if(output1 == 0 && output4 == 0) output5 = 1;
            else output5 = 0;
        }
        else if(box12[0].Item == XOR)
        {
            if(output1 == 0 && output4 == 0) output5 = 0;
            else if(output1 == 1 && output4 == 1) output5 = 0;
            else output5 = 1;
        }
        else if(box12[0].Item == XNOR)
        {
            if(output1 == 0 && output4 == 0) output5 = 1;
            else if(output1 == 1 && output4 == 1) output5 = 1;
            else output5 = 0;
        }
        Debug.Log("Out5 = " + output5);
        Answer = output5;
    }

    public void Tank5AnswerCalculate()
    {
        if(box7[0].Item == AND) output1 = ANDGateCalculator(box1, box2);
        else if(box7[0].Item == OR) output1 = ORGateCalculator(box1, box2);
        else if(box7[0].Item == NAND) output1 = NANDGateCalculator(box1, box2);
        else if(box7[0].Item == NOR) output1 = NORGateCalculator(box1, box2);
        else if(box7[0].Item == XOR) output1 = XORGateCalculator(box1, box2);
        else if(box7[0].Item == XNOR) output1 = XNORGateCalculator(box1, box2);
        Debug.Log("Out1 = " + output1);
        if(box8[0].Item == AND) output2 = ANDGateCalculator(box3, box4);
        else if(box8[0].Item == OR) output2 = ORGateCalculator(box3, box4);
        else if(box8[0].Item == NAND) output2 = NANDGateCalculator(box3, box4);
        else if(box8[0].Item == NOR) output2 = NORGateCalculator(box3, box4);
        else if(box8[0].Item == XOR) output2 = XORGateCalculator(box3, box4);
        else if(box8[0].Item == XNOR) output2 = XNORGateCalculator(box3, box4);
        Debug.Log("Out2 = " + output2);
        if(box9[0].Item == AND) output3 = ANDGateCalculator(box5, box6);
        else if(box9[0].Item == OR) output3 = ORGateCalculator(box5, box6);
        else if(box9[0].Item == NAND) output3 = NANDGateCalculator(box5, box6);
        else if(box9[0].Item == NOR) output3 = NORGateCalculator(box5, box6);
        else if(box9[0].Item == XOR) output3 = XORGateCalculator(box5, box6);
        else if(box9[0].Item == XNOR) output3 = XNORGateCalculator(box5, box6);
        Debug.Log("Out3 = " + output3);
        if(box10[0].Item == AND)
        {
            if(output1 == 1 && output2 == 1) output4 = 1;
            else output4 = 0;
        }
        else if(box10[0].Item == OR)
        {
            if(output1 == 0 && output2 == 0) output4 = 0;
            else output4 = 1;
        }
        else if(box10[0].Item == NAND)
        {
            if(output1 == 1 && output2 == 1) output4 = 0;
            else output4 = 1;
        }
        else if(box10[0].Item == NOR)
        {
            if(output1 == 0 && output2 == 0) output4 = 1;
            else output4 = 0;
        }
        else if(box10[0].Item == XOR)
        {
            if(output1 == 0 && output2 == 0) output4 = 0;
            else if(output1 == 1 && output2 == 1) output4 = 0;
            else output4 = 1;
        }
        else if(box10[0].Item == XNOR)
        {
            if(output1 == 0 && output2 == 0) output4 = 1;
            else if(output1 == 1 && output2 == 1) output4 = 1;
            else output4 = 0;
        }
        Debug.Log("Out4 = " + output4);
        if(box12[0].Item == AND)
        {
            if(output3 == 1 && output4 == 1) output5 = 1;
            else output5 = 0;
        }
        else if(box12[0].Item == OR)
        {
            if(output3 == 0 && output4 == 0) output5 = 0;
            else output5 = 1;
        }
        else if(box12[0].Item == NAND)
        {
            if(output3 == 1 && output4 == 1) output5 = 0;
            else output5 = 1;
        }
        else if(box12[0].Item == NOR)
        {
            if(output3 == 0 && output4 == 0) output5 = 1;
            else output5 = 0;
        }
        else if(box12[0].Item == XOR)
        {
            if(output3 == 0 && output4 == 0) output5 = 0;
            else if(output3 == 1 && output4 == 1) output5 = 0;
            else output5 = 1;
        }
        else if(box12[0].Item == XNOR)
        {
            if(output3 == 0 && output4 == 0) output5 = 1;
            else if(output3 == 1 && output4 == 1) output5 = 1;
            else output5 = 0;
        }
        Debug.Log("Out5 = " + output5);
        Answer = output5;
    }

    public void Tank6AnswerCalculate()
    {
        if(box7[0].Item == AND) output1 = ANDGateCalculator(box1, box2);
        else if(box7[0].Item == OR) output1 = ORGateCalculator(box1, box2);
        else if(box7[0].Item == NAND) output1 = NANDGateCalculator(box1, box2);
        else if(box7[0].Item == NOR) output1 = NORGateCalculator(box1, box2);
        else if(box7[0].Item == XOR) output1 = XORGateCalculator(box1, box2);
        else if(box7[0].Item == XNOR) output1 = XNORGateCalculator(box1, box2);
        Debug.Log("Out1 = " + output1);
        if(box8[0].Item == AND) output2 = ANDGateCalculator(box3, box4);
        else if(box8[0].Item == OR) output2 = ORGateCalculator(box3, box4);
        else if(box8[0].Item == NAND) output2 = NANDGateCalculator(box3, box4);
        else if(box8[0].Item == NOR) output2 = NORGateCalculator(box3, box4);
        else if(box8[0].Item == XOR) output2 = XORGateCalculator(box3, box4);
        else if(box8[0].Item == XNOR) output2 = XNORGateCalculator(box3, box4);
        Debug.Log("Out2 = " + output2);
        if(box9[0].Item == AND) output3 = ANDGateCalculator(box5, box6);
        else if(box9[0].Item == OR) output3 = ORGateCalculator(box5, box6);
        else if(box9[0].Item == NAND) output3 = NANDGateCalculator(box5, box6);
        else if(box9[0].Item == NOR) output3 = NORGateCalculator(box5, box6);
        else if(box9[0].Item == XOR) output3 = XORGateCalculator(box5, box6);
        else if(box9[0].Item == XNOR) output3 = XNORGateCalculator(box5, box6);
        Debug.Log("Out3 = " + output3);
        if(box10[0].Item == AND)
        {
            if(output1 == 1 && output2 == 1) output4 = 1;
            else output4 = 0;
        }
        else if(box10[0].Item == OR)
        {
            if(output1 == 0 && output2 == 0) output4 = 0;
            else output4 = 1;
        }
        else if(box10[0].Item == NAND)
        {
            if(output1 == 1 && output2 == 1) output4 = 0;
            else output4 = 1;
        }
        else if(box10[0].Item == NOR)
        {
            if(output1 == 0 && output2 == 0) output4 = 1;
            else output4 = 0;
        }
        else if(box10[0].Item == XOR)
        {
            if(output1 == 0 && output2 == 0) output4 = 0;
            else if(output1 == 1 && output2 == 1) output4 = 0;
            else output4 = 1;
        }
        else if(box10[0].Item == XNOR)
        {
            if(output1 == 0 && output2 == 0) output4 = 1;
            else if(output1 == 1 && output2 == 1) output4 = 1;
            else output4 = 0;
        }
        Debug.Log("Out4 = " + output4);
        if(box11[0].Item == AND)
        {
            if(output2 == 1 && output3 == 1) output5 = 1;
            else output5 = 0;
        }
        else if(box11[0].Item == OR)
        {
            if(output2 == 0 && output3 == 0) output5 = 0;
            else output5 = 1;
        }
        else if(box11[0].Item == NAND)
        {
            if(output2 == 1 && output3 == 1) output5 = 0;
            else output5 = 1;
        }
        else if(box11[0].Item == NOR)
        {
            if(output2 == 0 && output3 == 0) output5 = 1;
            else output5 = 0;
        }
        else if(box11[0].Item == XOR)
        {
            if(output2 == 0 && output3 == 0) output5 = 0;
            else if(output2 == 1 && output3 == 1) output5 = 0;
            else output5 = 1;
        }
        else if(box11[0].Item == XNOR)
        {
            if(output2 == 0 && output3 == 0) output5 = 1;
            else if(output2 == 1 && output3 == 1) output5 = 1;
            else output5 = 0;
        }
        Debug.Log("Out5 = " + output5);
        if(box12[0].Item == AND)
        {
            if(output4 == 1 && output5 == 1) output6 = 1;
            else output6 = 0;
        }
        else if(box12[0].Item == OR)
        {
            if(output4 == 0 && output5 == 0) output6 = 0;
            else output6 = 1;
        }
        else if(box12[0].Item == NAND)
        {
            if(output4 == 1 && output5 == 1) output6 = 0;
            else output6 = 1;
        }
        else if(box12[0].Item == NOR)
        {
            if(output4 == 0 && output5 == 0) output6 = 1;
            else output6 = 0;
        }
        else if(box12[0].Item == XOR)
        {
            if(output4 == 0 && output5 == 0) output6 = 0;
            else if(output4 == 1 && output5 == 1) output6 = 0;
            else output6 = 1;
        }
        else if(box12[0].Item == XNOR)
        {
            if(output4 == 0 && output5 == 0) output6 = 1;
            else if(output4 == 1 && output5 == 1) output6 = 1;
            else output6 = 0;
        }
        Debug.Log("Out6 = " + output6);
        Answer = output6;
    }

    public int ANDGateCalculator(BoxSlot[] input1, BoxSlot[] input2)
    {
        if(input1[0].Item == ONE && input2[0].Item == ONE) return 1;
        else return 0;
    }

    public int ORGateCalculator(BoxSlot[] input1, BoxSlot[] input2)
    {
        if(input1[0].Item == ZERO && input2[0].Item == ZERO) return 0;
        else return 1;
    }

    public int NANDGateCalculator(BoxSlot[] input1, BoxSlot[] input2)
    {
        if(input1[0].Item == ONE && input2[0].Item == ONE) return 0;
        else return 1;
    }

    public int NORGateCalculator(BoxSlot[] input1, BoxSlot[] input2)
    {
        if(input1[0].Item == ZERO && input2[0].Item == ZERO) return 1;
        else return 0;
    }

    public int XORGateCalculator(BoxSlot[] input1, BoxSlot[] input2)
    {
        if(input1[0].Item == ZERO && input2[0].Item == ZERO) return 0;
        else if(input1[0].Item == ONE && input2[0].Item == ONE) return 0;
        else return 1;
    }

    public int XNORGateCalculator(BoxSlot[] input1, BoxSlot[] input2)
    {
        if(input1[0].Item == ZERO && input2[0].Item == ZERO) return 1;
        else if(input1[0].Item == ONE && input2[0].Item == ONE) return 1;
        else return 0;
    }
}
