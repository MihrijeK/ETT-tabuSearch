using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Json.Net;
using System.Collections.Generic;
using AutoMapper;
using System.Text.Json;
using Newtonsoft.Json;
using ETT.model;

public class JSONUtils {

	
	public static Instance Convert(string json, Instance instance)
	{
		// Serialize Data.  
		string data = JsonConvert.SerializeObject(json);
		// Deserialize Data.  
		Instance deserializedData  = JsonConvert.DeserializeObject<Instance>(data);

		return deserializedData;

	}
	public static string convert(Object obj) {
	
		var opt = new JsonSerializerOptions(){ WriteIndented=true };
        string strJson = System.Text.Json.JsonSerializer.Serialize(obj, opt);
    	return strJson;
	}

	public static string getFileData(String fileName){

		JObject data = JObject.Parse(File.ReadAllText(fileName));

		return data.ToString();

	}
	
	public static void saveFile(String obj, String fileName) {
	
		using(StreamWriter writetext = new StreamWriter(fileName))
		{
			writetext.WriteLine(obj);
		}
	}
}
