using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class DataScript : MonoBehaviour
{
    [Serializable]
    private class Data
    {
        public bool[] RanchData;
        public bool[] UpgradesData;
    }
    public static void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Data.dat");
        Data data = new Data
        {
            RanchData = MainMenu.s_Ranch,
            UpgradesData = MainMenu.s_Upgrades
        };
        bf.Serialize(file, data);
        file.Close();
    }
    public static void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/Data.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Data.dat", FileMode.Open);
            Data data = (Data)bf.Deserialize(file);
            file.Close();
            MainMenu.s_Ranch = data.RanchData;
            MainMenu.s_Upgrades = data.UpgradesData;
        }
    }
}
