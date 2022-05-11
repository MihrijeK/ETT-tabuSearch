using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Json.Net;
using System.Collections.Generic;
using AutoMapper;
using System.Text.Json;

public class JSONUtils {

	// public static <T> T convert(String json, IList<T> typeReference) {
	// 	// 	ObjectMapper mapper = new ObjectMapper();
	// 	// 	mapper.configure(MapperFeature.ACCEPT_CASE_INSENSITIVE_PROPERTIES, true);
	// 	// 	mapper.configure(MapperFeature.ACCEPT_CASE_INSENSITIVE_ENUMS, true);
	// 	// 	try {
	// 	// 		return mapper.readValue(json, typeReference);
	// 	// 	} catch (IOException e) {
	// 	// 		 e.printStackTrace();
	// 	// 	}
	// 	// return null;
	// 	return System.Text.Json.JsonSerializer.Deserialize<IList<T>>(json);
	// }
	
	public static String convert(Object obj) {
	
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
