using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms.DataVisualization.Charting;
using iTextSharp.text;
using iTextSharp.text.pdf;

using Microsoft.VisualBasic.ApplicationServices;


namespace WinFormsControlLibrary
{
    public partial class GistogramPdfComponent3 : Component
    {
        public GistogramPdfComponent3()
        {
            InitializeComponent();
        }

        public GistogramPdfComponent3(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void GenerateHistogramDocument(string fileName, string documentTitle, string chartTitle, LegendPosition legendPosition, List<HistogramData> data)
        {
            if (string.IsNullOrWhiteSpace(fileName) ||
            string.IsNullOrWhiteSpace(documentTitle) ||
            string.IsNullOrWhiteSpace(chartTitle) ||
            data == null || data.Count == 0)
            {
                throw new ArgumentException("Invalid input data");
            }

            // Создаем новый документ PDF
            using (var document = new Document())
            {
                // Указываем путь к файлу PDF
                PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.OpenOrCreate));

                document.Open();

                // Добавляем заголовок документа
                document.Add(new Paragraph(documentTitle));

                // Создаем график
                Chart chart = new Chart();
                chart.Width = 500;
                chart.Height = 300;

                // Настраиваем график
                chart.Titles.Add(new Title(chartTitle));
                chart.Legends.Add(new Legend(legendPosition.ToString()));

                // Создаем область для графика
                ChartArea chartArea = new ChartArea();
                chart.ChartAreas.Add(chartArea);

                // Добавляем данные в график
                foreach (var dataPoint in data)
                {
                    Series series = new Series();
                    series.ChartType = SeriesChartType.Column;

                    if (dataPoint.Data != null && dataPoint.Data.Length > 0)
                    {
                        for (int i = 0; i < dataPoint.Data.Length; i++)
                        {
                            series.Points.AddXY(i + 1, dataPoint.Data[i]);
                        }
                    }

                    chart.Series.Add(series);
                }

                // Рендерим график в изображение
                using (var chartImageStream = new MemoryStream())
                {
                    chart.SaveImage(chartImageStream, ChartImageFormat.Png);
                    chartImageStream.Position = 0;

                    // Добавляем изображение в PDF
                    var chartImage = iTextSharp.text.Image.GetInstance(chartImageStream);
                    document.Add(chartImage);
                }

                document.Close();
            }

        }
    }
}