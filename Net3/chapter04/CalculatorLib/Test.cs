using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace chapter04.CalculatorLib
{
    public class Test
    {

        public static void ProcessDataFile(string fileName, string fileContent, string record)
        {
            if (fileName.Equals("rrzone.json"))
            {
                processRRZoneFile(fileContent, record);
            }
            else if (fileName.Equals("msftrr_config.json"))
            { 
                //
            }
        }

        private static void processRRZoneFile(string fileContent, string record) {
            string key = "zoneName";
            bool isExist = false;

            JsonArray jArray = ParseJson(fileContent);
            JsonNode jsonNodeToSave = ParseJson(record);

            foreach ( JsonNode node in jArrayZones)
            {
                if (node[key] == jsonNodeToSave[key]) {
                    // override

                    jArrayZones[i] = jsonNodeToSave;
                    isExist = true;
                }
            }

            if (!isExist) { 
                jArray.Add(jsonNodeToSave);
            }
        }

        private static JsonArray ParseJson(string data)
        {
            return new JsonArray();
        }

    }
}
