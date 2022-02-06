using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    void Start()
    {
        Save s = new Save();

        s.score = 25;
        s.inventory = new List<string>();

        s.inventory.Add("TESTANDO");

        Save load = LoadGame();

        print(load.inventory[0]);
    }

    public void SaveGame(Save s)
    {
        BinaryFormatter bf = new BinaryFormatter();

        string path = Application.persistentDataPath;

        FileStream file = File.Create(path + "/savegame.save");

        bf.Serialize(file, s);
        file.Close();

        print("Jogo Salvo");
    }

    public Save LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();

        string path = Application.persistentDataPath;

        FileStream file;

        if(File.Exists(path + "/savegame.save"))
        {
            file = File.Open(path + "/savegame.save", FileMode.Open);
            Save loaded = (Save)bf.Deserialize(file);
            file.Close();

            print("Jogo Carregado");

            return loaded;
        }

        return null;
    }
}
