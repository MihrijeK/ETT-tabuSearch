using System;
using System.IO;

public class JSONUtils {

	public static <T> T convert(String json, TypeReference<T> typeReference) {
			ObjectMapper mapper = new ObjectMapper();
			mapper.configure(MapperFeature.ACCEPT_CASE_INSENSITIVE_PROPERTIES, true);
			mapper.configure(MapperFeature.ACCEPT_CASE_INSENSITIVE_ENUMS, true);
			try {
				return mapper.readValue(json, typeReference);
			} catch (IOException e) {
				 e.printStackTrace();
			}
		return null;
	}
	
	public static String convert(Object obj) {
		if (obj != null) {
			ObjectMapper mapper = new ObjectMapper();
			try {
				return mapper.writerWithDefaultPrettyPrinter().writeValueAsString(obj);
			} catch (IOException e) {
				 e.printStackTrace();
			}
		}
		return "";
	}

	public static string getFileData(String fileName){

        JSONParser jsonParser = new JSONParser();
		StreamReader reader = File.OpenText(fileName);

        // {
        return jsonParser.parse(reader).toString();
        // } catch (IOException e) {
        //     e.printStackTrace();
        // }
        // return null;
	}
	
	public static void saveFile(String object, String fileName) {
		try (StreamReader file = File.OpenText(fileName)) {
            file.write(object);
            Console.WriteLine("Successfully Copied JSON Object to File...");
            file.flush();
            file.close();
        } catch(Exception e){
            Console.WriteLine(e);
        }
	}
}
