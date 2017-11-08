﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyClassLib
{
    public class TimeSeries
    {

        private static TimeSeriesModel timeSeriesModel;

        private static void SetTimeSeriesModel (String currencyCode, DateTime startDate, DateTime endDate)
        {
            String timeSeriesJson = TimeSeriesDataAccess.GetJSON(currencyCode, startDate, endDate);
            timeSeriesModel = JsonConvert.DeserializeObject<TimeSeriesModel>(timeSeriesJson);
        }

        public static List<List<Object>> GetTimeSeries (String currencyCode, DateTime startDate, DateTime endDate)
        {
            // If the model has not been set or it's set to a different currency
            /*
            if (timeSeriesModel == null || timeSeriesModel.Dataset.DatabaseCode.Substring(3) != currencyCode)
            {
                SetTimeSeriesModel(currencyCode, startDate, endDate);
            }
            */

            String timeSeriesJson = TimeSeriesDataAccess.GetJSON(currencyCode, startDate, endDate);
            TimeSeriesModel timeSeriesModel = JsonConvert.DeserializeObject<TimeSeriesModel>(timeSeriesJson);

            return timeSeriesModel.Dataset.Data;
        }
    }
}
