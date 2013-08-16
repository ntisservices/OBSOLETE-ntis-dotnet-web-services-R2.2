using System;
using log4net;
using SubscriberWebService.Services;

namespace SubscriberWebService
{

    public class WebServiceSubscriber : IWebServiceSubscriber
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(WebServiceSubscriber));

        public DeliverAverageSpeedFvdResponse1 DeliverAverageSpeedFvd(DeliverAverageSpeedFvdRequest1 request)
        {
            AverageSpeedFvdService averageSpeedFvdService = new AverageSpeedFvdService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver average speed FVD request received");
            DeliverAverageSpeedFvdResponse response = averageSpeedFvdService.GetDeliverAverageSpeedFvdResponse(request.DeliverAverageSpeedFvdRequest);
            return new DeliverAverageSpeedFvdResponse1(response);
        }

        public DeliverMIDASTrafficDataResponse1 DeliverMIDASTrafficData(DeliverMIDASTrafficDataRequest1 request)
        {
            MidasTrafficDataService midasTrafficDataService = new MidasTrafficDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver MIDAS traffic data request received");
            DeliverMIDASTrafficDataResponse response = midasTrafficDataService.GetDeliverMidasTrafficDataResponse(request.DeliverMIDASTrafficDataRequest);
            return new DeliverMIDASTrafficDataResponse1(response);
        }

        public DeliverANPRTrafficDataResponse1 DeliverANPRTrafficData(DeliverANPRTrafficDataRequest1 request)
        {
            AnprTrafficDataService anprTrafficDataService = new AnprTrafficDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver ANPR traffic data request received");
            DeliverANPRTrafficDataResponse response = anprTrafficDataService.GetDeliverAnprTrafficDataResponse(request.DeliverANPRTrafficDataRequest);

            return new DeliverANPRTrafficDataResponse1(response);
        }

        public DeliverAverageSpeedFusedDataResponse1 DeliverAverageSpeedFusedData(DeliverAverageSpeedFusedDataRequest1 request)
        {
            AverageSpeedFusedDataService averageSpeedFusedDataService = new AverageSpeedFusedDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver average speed fused data request received");
            DeliverAverageSpeedFusedDataResponse response = averageSpeedFusedDataService.GetDeliverAverageSpeedFusedDataResponse(request.DeliverAverageSpeedFusedDataRequest);

            return new DeliverAverageSpeedFusedDataResponse1(response);
        }

        public DeliverAverageJourneyTimeResponse1 DeliverAverageJourneyTime(DeliverAverageJourneyTimeRequest1 request)
        {
            AverageJourneyTimeService averageJourneyTimeService = new AverageJourneyTimeService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver average journey time request received");
            DeliverAverageJourneyTimeResponse response = averageJourneyTimeService.GetDeliverAverageJourneyTimeResponse(request.DeliverAverageJourneyTimeRequest);

            return new DeliverAverageJourneyTimeResponse1(response);
        }


        public DeliverTMUTrafficDataResponse1 DeliverTMUTrafficData(DeliverTMUTrafficDataRequest1 request)
        {
            TMUTrafficDataService tmuTrafficDataService = new TMUTrafficDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver TMU Traffic Data request received");
            DeliverTMUTrafficDataResponse response =
                tmuTrafficDataService.GetDeliverTMUTrafficDataResponse(request.DeliverTMUTrafficDataRequest);

            return new DeliverTMUTrafficDataResponse1(response);
        }
    }
}