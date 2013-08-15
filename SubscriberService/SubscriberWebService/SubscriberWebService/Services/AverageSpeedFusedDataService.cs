﻿// Copyright (C) 2011 Thales Transportation Systems UK 
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy,modify, merge, publish, distribute, sublicense, and/or sell 
// copies of the Software, and to permit persons to whom the Software is 
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software. 
//    
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL 
// THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using System.Web.Services.Protocols;

namespace SubscriberWebService.Services
{
    public class AverageSpeedFusedDataService : AbstractDatexService, IAverageSpeedFusedDataService
    {

        #region IAverageSpeedFusedData Members

        public DeliverAverageSpeedFusedDataResponse GetDeliverAverageSpeedFusedDataResponse(DeliverAverageSpeedFusedDataRequest deliverAverageSpeedFusedDataRequest)
        {
            log.Info("New DeliverAverageSpeedFusedDataRequest received.");

            D2LogicalModel d2LogicalModel = deliverAverageSpeedFusedDataRequest.d2LogicalModel;
            FusedDataPublication fusedDataPublication = null;

            // Validate D2LogicalModel
            if (!ExampleDataCheckOk(d2LogicalModel))
            {
                throw new SoapException("Incoming request does not appear to be valid!", SoapException.ClientFaultCode);
            }

            // FusedDataPublication contains the journey time, direction, code, region, etc.
            try
            {
                fusedDataPublication = (FusedDataPublication)d2LogicalModel.payloadPublication;

                if (fusedDataPublication != null && fusedDataPublication.fusedData[0] != null)
                {
                    log.Info(string.Format("CreatedUTC is {0}", fusedDataPublication.fusedData[0].createdUtc));
                    // You could use the FusedDataPublication and extract the corresponding fields
                    ProcessedTrafficData[] trafficData = fusedDataPublication.fusedData[0].linkData;
                    if (trafficData.Count() > 0)
                    {
                        log.Info(string.Format("speedKph {0}",trafficData[0].speedKph));
                    }


                }

            }
            catch (Exception e)
            {
                log.Error("Error while obtaining FusedDataPublication.");
                log.Error(e.Message);
                throw new SoapException("Error while obtaining FusedDataPublication.", SoapException.ServerFaultCode, e);
            }

            DeliverAverageSpeedFusedDataResponse response = new DeliverAverageSpeedFusedDataResponse();
            response.status = "DeliverAverageSpeedFusedDataRequest: Successful Delivery";

            return response;
        }

        #endregion
    }
}
