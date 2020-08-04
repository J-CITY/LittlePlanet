using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem {

	public static void Save(PlayerData p) {
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/player.bn";
		FileStream fs = new FileStream(path, FileMode.Create);
		formatter.Serialize(fs, p);
		fs.Close();
	}

	public static PlayerData Load()
	{
		string path = Application.persistentDataPath + "/player.bn";
		if (File.Exists(path)) {
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream fs = new FileStream(path, FileMode.Open);
			PlayerData data = formatter.Deserialize(fs) as PlayerData;
			fs.Close();

			return data;
		} else {
			return null;
		}
	}
}
