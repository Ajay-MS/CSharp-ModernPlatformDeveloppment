using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared
{
    public class ValidateJson
    {

        public static string DataFileContent = @"[{""ZoneName"":""10.in-addr.arpa"",""ZoneType"":""Forwarder"",""SmartDestinationSelectorLink"":""Phynet"",""PartnerICMteam"":""Cloudnet\\\\DNSServingPlane"",""IncidentLevel"":""2"",""UseRecursion"":false,""ForwarderTimeout"":1}]";

        public static void Main1(string[] args)
        {
            var zonesArray = JArray.Parse(DataFileContent);

            foreach (var zone in zonesArray)
            {
                Console.WriteLine(zone["ZoneName"]);
            }
        }
    }
}
