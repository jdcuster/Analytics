﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Skybrud.Social.Google.Analytics.Responses;

namespace Analytics.Models
{
    public class ChartData
    {

        /*
        var chartData = {
                    labels: ["Desktop", "Mobile", "Tablet"],
                    datasets: [
                        {
                            fillColor: "rgba(245,112, 32,0.5)",
                            strokeColor: "rgba(245, 112, 32, 1)",
                            data: [87736, 2880, 2057]
                        },
                        {
                            fillColor: "rgba(245,112, 32,0.5)",
                            strokeColor: "rgba(245, 112, 32, 1)",
                            data: [236897, 5711, 5623]
                        }
                    ]
                };
        */

        public string [] labels { get; set; }

        public ChartDataSet[] datasets { get; set; }
        
        public static ChartData Mode1(AnalyticsDataResponse data) {

            // Get the amount of dimensions and metrics
            int dimensions = data.ColumnHeaders.Count(x => x.ColumnType == "DIMENSION");
            int metrics = data.ColumnHeaders.Count(x => x.ColumnType == "METRIC");

            // Initialize the data object
            ChartData cd = new ChartData {
                labels = data.Rows.Select(row => row.Cells[0]).ToArray(),
                datasets = new ChartDataSet[metrics]
            };

            // Add a dataset for each metric
            for (int metric = 0; metric < metrics; metric++) {

                ChartDataSet ds = cd.datasets[metric] = new ChartDataSet();
                ds.fillColor = "rgba(245, 112, 32, 0.5)";
                ds.strokeColor = "rgba(245, 112, 32, 1)";
                ds.data = new object[data.Rows.Length];

                for (int row = 0; row < data.Rows.Length; row++) {
                    ds.data[row] = data.Rows[row].Cells[dimensions + metric];
                }

            }

            return cd;

        }

        public static ChartData Mode2(AnalyticsDataResponse data) {

            // Get the amount of dimensions and metrics
            int dimensions = data.ColumnHeaders.Count(x => x.ColumnType == "DIMENSION");
            int metrics = data.ColumnHeaders.Count(x => x.ColumnType == "METRIC");

            // Initialize the data object
            ChartData cd = new ChartData {
                labels = data.Rows.Select(row => row.Cells[0]).ToArray(),
                datasets = new ChartDataSet[metrics]
            };

            // Add a dataset for each metric
            for (int metric = 0; metric < metrics; metric++) {

                ChartDataSet ds = cd.datasets[metric] = new ChartDataSet();
                ds.fillColor = "rgba(245, 112, 32, 0.5)";
                ds.strokeColor = "rgba(245, 112, 32, 1)";
                ds.data = new object[data.Rows.Length];

                for (int row = 0; row < data.Rows.Length; row++) {
                    ds.data[row] = data.Rows[metric].Cells[dimensions + row];
                }

            }

            return cd;

        }
    
    }

    public class ChartDataSet
    {
        public string fillColor { get; set; }

        public string strokeColor { get; set; }

        public object[] data { get; set; }
    }
}