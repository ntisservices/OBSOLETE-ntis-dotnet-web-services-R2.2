using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Reflection;
using TestClient.ServiceReference1;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            DeliverANPRTrafficDataRequest request = new DeliverANPRTrafficDataRequest();
            D2LogicalModel model = new D2LogicalModel();

            //request.D2LogicalModel = new TestClient.SubscriberServiceReference.D2LogicalModel();
            
            model.modelBaseVersion = "2";
            model.exchange = new Exchange();
            model.exchange.supplierIdentification = new InternationalIdentifier();
            model.exchange.supplierIdentification.country = CountryEnum.gb;
            model.exchange.supplierIdentification.nationalIdentifier = "gb";

            request.D2LogicalModel = model;

            subscriberClient client = new subscriberClient();
            DeliverANPRTrafficDataResponse response = new DeliverANPRTrafficDataResponse();

            // call service and get response;
            try
            {
                response = client.DeliverANPRTrafficData(request);
                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                Console.ReadLine();
            }
            

            Console.WriteLine(response.status);
            Console.ReadLine();
        }
    }
}
