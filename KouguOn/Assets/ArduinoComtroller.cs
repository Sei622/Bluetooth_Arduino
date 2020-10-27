using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class ArduinoComtroller : MonoBehaviour
{
    private SerialPort m_SerialPort; //USBポート

    void Start()
    {
        m_SerialPort = new SerialPort("COM5", 9600);　//ポートを指定する
        m_SerialPort.Open(); //ポートを開く

        if (m_SerialPort.IsOpen) // Arduinoと接続することを確認
        {
            Debug.Log("Serial通信成功");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) // Arduinoと接続することを確認
        {
            Debug.Log("送信");
            m_SerialPort.Write("Hello");
        }
    }
    private void OnApplicationQuit()
    {
        m_SerialPort.Close();//アプリを閉める時ポートを閉める
    }
}
