﻿using System;


namespace StratumTest
{
    using Stratum;
	using Newtonsoft.Json.Linq;

	class StratumWrapper : Stratum
	{
		public StratumWrapper(string ipAddress, int port) : base(ipAddress, port) {	}

		public override void NotificationHandler(string NotificationMethod, JArray NotificationData)
		{
			Console.WriteLine("\nNotification: Method={0}, data={1}", NotificationMethod, NotificationData.ToString());
		}
	}

    class StratumTest
    {
        static void Main(string[] args)
        {
			StratumWrapper s = new StratumWrapper("176.9.65.41", 5034);

            while (true)
            {
                var res = s.Invoke<int>("blockchain.numblocks.subscribe");
                
                // var res = s.Invoke<Newtonsoft.Json.Linq.JObject>("blockchain.headers.subscribe");
                // var res = s.Invoke<string>("blockchain.transaction.get", "101379cb55ac431c435db40b4325f858568b0de3d8bd652a23a19e5d62521a72");
                // var res = s.Invoke<Newtonsoft.Json.Linq.JObject>("blockchain.address.get_balance", "4PQtUNZ2aBYpZpVMPV2Qgz1PitCqgoT388");
                // var res = s.Invoke<Newtonsoft.Json.Linq.JArray>("blockchain.address.get_history", "4PQtUNZ2aBYpZpVMPV2Qgz1PitCqgoT388");
                // var res = s.Invoke<Newtonsoft.Json.Linq.JArray>("blockchain.address.listunspent", "4PQtUNZ2aBYpZpVMPV2Qgz1PitCqgoT388");

                Console.Write(res.Result.ToString());
                Console.ReadLine();
            }
        }
    }
}
