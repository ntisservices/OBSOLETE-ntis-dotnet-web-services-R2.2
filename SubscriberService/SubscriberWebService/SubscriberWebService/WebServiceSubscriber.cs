using System;
using log4net;
using SubscriberWebService.Services;

namespace SubscriberWebService
{

    public class WebServiceSubscriber : IWebServiceSubscriber
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(WebServiceSubscriber));

        public DeliverAverageSpeedFvdResponseContainer DeliverAverageSpeedFvd(DeliverAverageSpeedFvdRequestContainer container)
        {
            AverageSpeedFvdService averageSpeedFvdService = new AverageSpeedFvdService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver average speed FVD request received");
            DeliverAverageSpeedFvdResponse response = averageSpeedFvdService.GetDeliverAverageSpeedFvdResponse(container.DeliverAverageSpeedFvdRequest);
            return new DeliverAverageSpeedFvdResponseContainer(response);
        }

        public DeliverMIDASTrafficDataResponseContainer DeliverMIDASTrafficData(DeliverMIDASTrafficDataRequestContainer container)
        {
            MidasTrafficDataService midasTrafficDataService = new MidasTrafficDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver MIDAS traffic data request received");
            DeliverMIDASTrafficDataResponse response = midasTrafficDataService.GetDeliverMidasTrafficDataResponse(container.DeliverMIDASTrafficDataRequest);
            return new DeliverMIDASTrafficDataResponseContainer(response);
        }

        public DeliverANPRTrafficDataResponseContainer DeliverANPRTrafficData(DeliverANPRTrafficDataRequestContainer container)
        {
            AnprTrafficDataService anprTrafficDataService = new AnprTrafficDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver ANPR traffic data request received");
            DeliverANPRTrafficDataResponse response = anprTrafficDataService.GetDeliverAnprTrafficDataResponse(container.DeliverANPRTrafficDataRequest);

            return new DeliverANPRTrafficDataResponseContainer(response);
        }

        public DeliverAverageSpeedFusedDataResponseContainer DeliverAverageSpeedFusedData(DeliverAverageSpeedFusedDataRequestContainer container)
        {
            AverageSpeedFusedDataService averageSpeedFusedDataService = new AverageSpeedFusedDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver average speed fused data request received");
            DeliverAverageSpeedFusedDataResponse response = averageSpeedFusedDataService.GetDeliverAverageSpeedFusedDataResponse(container.DeliverAverageSpeedFusedDataRequest);

            return new DeliverAverageSpeedFusedDataResponseContainer(response);
        }

        public DeliverAverageJourneyTimeResponseContainer DeliverAverageJourneyTime(DeliverAverageJourneyTimeRequestContainer container)
        {
            AverageJourneyTimeService averageJourneyTimeService = new AverageJourneyTimeService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver average journey time request received");
            DeliverAverageJourneyTimeResponse response = averageJourneyTimeService.GetDeliverAverageJourneyTimeResponse(container.DeliverAverageJourneyTimeRequest);

            return new DeliverAverageJourneyTimeResponseContainer(response);
        }


        public DeliverTMUTrafficDataResponseContainer DeliverTMUTrafficData(DeliverTMUTrafficDataRequestContainer container)
        {
            TMUTrafficDataService tmuTrafficDataService = new TMUTrafficDataService();
            log4net.Config.XmlConfigurator.Configure();
            log.Info("Deliver TMU Traffic Data request received");
            DeliverTMUTrafficDataResponse response =
                tmuTrafficDataService.GetDeliverTMUTrafficDataResponse(container.DeliverTMUTrafficDataRequest);

            return new DeliverTMUTrafficDataResponseContainer(response);
        }
    }
}