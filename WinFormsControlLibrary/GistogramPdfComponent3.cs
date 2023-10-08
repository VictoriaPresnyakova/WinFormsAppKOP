using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms.DataVisualization.Charting;

using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;


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
            if (string.IsNullOrEmpty(fileName) || string.IsNullOrEmpty(documentTitle) || string.IsNullOrEmpty(chartTitle) || data == null || data.Count == 0)
            {
                throw new ArgumentException("Invalid input data.");
            }

            // Создаем новый документ PDF
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont titleFont = new XFont("Arial", 16, XFontStyle.Bold);

            // Добавляем заголовок документа
            gfx.DrawString(documentTitle, titleFont, XBrushes.Black, new XRect(0, 20, page.Width, 0), XStringFormats.TopCenter);

            // Создаем график и сохраняем его как изображение
            string chartFileName = "chart.png";
            GenerateChartImage(chartFileName, chartTitle, legendPosition, data);

            // Добавляем изображение графика в PDF
            XImage chartImage = XImage.FromFile(chartFileName);
            gfx.DrawImage(chartImage, (page.Width - chartImage.PixelWidth) / 2, 60, chartImage.PixelWidth, chartImage.PixelHeight);

            // Закрываем документ
            document.Save(fileName);
            document.Close();

            // Удаляем временное изображение
            File.Delete(chartFileName);
        }

        private void GenerateChartImage(string fileName, string chartTitle, LegendPosition legendPosition, List<HistogramData> data)
        {
            var chart = new Chart();
            chart.Width = 600;
            chart.Height = 400;

            // Добавляем заголовок
            var title = new Title();
            title.Text = chartTitle;
            title.Alignment = ContentAlignment.TopCenter;
            chart.Titles.Add(title);

            // Добавляем легенду
            chart.Legends.Add(new Legend(legendPosition.ToString()));

            // Добавляем серии данных
            foreach (var seriesData in data)
            {
                var series = new Series(seriesData.SeriesName);
                series.Points.DataBindY(seriesData.Data);
                chart.Series.Add(series);
            }

            // Сохраняем график как изображение PNG
            chart.SaveImage(fileName, ChartImageFormat.Png);
        }
        }
    }