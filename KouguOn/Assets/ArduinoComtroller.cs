using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class ArduinoComtroller : MonoBehaviour
{
    private Text m_DistanceText; //距離の表示するテキスト
    private SerialPort m_SerialPort; //USBポート

    void Start()
    {
        m_DistanceText = FindObjectOfType<Text>();　//シンでのテキストを探す
        m_SerialPort = new SerialPort("COM5", 9600);　//ポートを指定する
        m_SerialPort.Open();　//ポートを開く
    }

    void Update()
    {
        if (m_SerialPort.IsOpen) // Arduinoと接続することを確認
        {
            string data = m_SerialPort.ReadLine();　// Arduinoからのデータを取得する
            float dis = 0;
            if (float.TryParse(data, out dis)) //Arduinoからのデータは数かどうか確認する
            {
                m_DistanceText.text = dis + "cm";　//画面に表示する
            }
        }
    }
    private void OnApplicationQuit()
    {
        m_SerialPort.Close();//アプリを閉める時ポートを閉める
    }
}
