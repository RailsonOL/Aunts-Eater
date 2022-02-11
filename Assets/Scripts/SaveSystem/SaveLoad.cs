using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    void Start()
    {
        //Save s = new Save();

        //s.playerSelected = "P1";
        //s.powerups = new List<string>();

        //s.powerups.Add("TESTANDO");

        //DeleteSave();

        //SaveGame(s);

        //Save load = LoadGame();

        //print(load.inventory[0]);
    }

    public static void SaveGame(Save s)
    {
        BinaryFormatter bf = new BinaryFormatter();

        string path = Application.persistentDataPath;

        FileStream file = File.Create(path + "/savegame.save");

        bf.Serialize(file, s);
        file.Close();

        print("Jogo Salvo");
    }

    public static Save LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();

        string path = Application.persistentDataPath;

        FileStream file;

        if(File.Exists(path + "/savegame.save"))
        {
            file = File.Open(path + "/savegame.save", FileMode.Open);
            Save loadedData = (Save)bf.Deserialize(file);
            file.Close();

            print("Jogo Carregado");

            return loadedData;
        }

        return null;
    }

    public static bool CheckSaveExists()
    {
        string path = Application.persistentDataPath;

        if (File.Exists(path + "/savegame.save")) return true;

        return false;
    }

    public static bool DeleteSave()
    {
        string path = Application.persistentDataPath;

        if (File.Exists(path + "/savegame.save"))
        {
            File.Delete(path + "/savegame.save");
            return true;
        }

        return false;
    }
}
