using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void SaveData(World world)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Environment.CurrentDirectory + "\\Game";

        FileStream stream = new FileStream(path, FileMode.Create);

        WorldData worldData = new WorldData(
            world.CurrentDay, world.TotalDays, world.Avatar, world.Patients, world.DeadPatients);

        formatter.Serialize(stream, worldData);
        stream.Close();
    }
    public static WorldData LoadData()
    {
        string path = Environment.CurrentDirectory + "\\Game";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            WorldData data = formatter.Deserialize(stream) as WorldData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.WriteLine("Error: Save file not found in " + path);
            return null;
        }
    }

}
