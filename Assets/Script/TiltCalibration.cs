using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class TiltCalibration : MonoBehaviour
{
    public InitAngle InitAngle;
    public SerialPort sp = new SerialPort("COM18", 115200);
    public Text FrontMotorAngle, BackMotorAngle;

    double acce1=0; //前後的坐墊位移值
    double acce2=0; //左右的坐墊位移值
    double tilt = 0; //傾斜角度
    string info; //傳送給Arduino的字串


    private void Start()
    {
        sp.Open();

               
    }
    private void Update()
    {
        Debug.Log("123");
        FrontMotorAngle.text = InitAngle.initAngle3.ToString();
        BackMotorAngle.text = InitAngle.initAngle4.ToString();

    }
    private void FixedUpdate()
    {

        SendInfo();
 
    }


    // SendInfo: 傳訊息給Arduino
    private void SendInfo()
    {
        ///Debug.Log("456");
        //傳訊息給Arduino
        info = "s," + acce1.ToString("#0.00") + "," + acce2.ToString("#0.00") + "," + tilt.ToString("#0.00") + ","+ InitAngle.initAngle3.ToString() + "," + InitAngle.initAngle4.ToString() + ",";
        sp.WriteLine(info);               
    }
    

    public void ChangeAngle3(float angleToPlus)
    {        
        InitAngle.initAngle3 += angleToPlus;
    }

    public void ChangeAngle4(float angleToPlus)
    {
        InitAngle.initAngle4 += angleToPlus;
    }

}


