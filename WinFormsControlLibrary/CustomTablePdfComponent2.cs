using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsControlLibrary
{
    public partial class CustomTablePdfComponent2 : Component
    {
        public CustomTablePdfComponent2()
        {
            InitializeComponent();
        }

        public CustomTablePdfComponent2(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void GenerateDocument<T>(string filePath, string documentTitle, float Headerheights, float RowHeits, List<T> values, List<ColumnConfig> columnConfigs)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(documentTitle) || values == null || values.Count == 0 || columnConfigs == null || columnConfigs.Count == 0)
            {
                throw new ArgumentException("Invalid input data.");
            }
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.OpenOrCreate));
            document.Open();

            // Добавляем заголовок
            document.Add(new Paragraph(documentTitle));

            // add table 
            PdfPTable table = new PdfPTable(columnConfigs.Count);

            // set column widths
            float[] colWidths = new float[columnConfigs.Count];
            for (int i = 0; i < columnConfigs.Count; i++)
            {
                colWidths[i] = columnConfigs[i].Width;
            }
            table.SetWidths(colWidths);
            table.WidthPercentage = 100;


            //add header
            for (int i = 0; i < columnConfigs.Count; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(columnConfigs[i].ShowName, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                cell.FixedHeight = Headerheights;
                table.AddCell(cell);
            }

            // add data
            for (int i = 0; i < values.Count; i++)
            {
                for (int j = 0; j < columnConfigs.Count; j++)
                {

                    var property = typeof(T).GetProperty(columnConfigs[j].PropertyName);
                    if ((property != null))
                    {
                        PdfPCell cell = new PdfPCell();
                        if (j == 0)
                        {
                            cell.AddElement(new Phrase(property.GetValue(values[i]).ToString(), FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
                        }
                        else
                        {
                            cell.AddElement(new Phrase(property.GetValue(values[i]).ToString()));

                        }
                        cell.FixedHeight = RowHeits;
                        table.AddCell(cell);
                    }

                }
            }

            document.Add(table);

            document.Close();














            //    // Добавляем таблицы
            //    foreach (var tableData in tables)
            //    {
            //        PdfPTable table = new PdfPTable(tableData.Columns);
            //        table.SetWidths(Enumerable.Repeat(1f / tableData.Columns, tableData.Columns).ToArray());
            //        table.WidthPercentage = 100;
            //        //float[] widths = new float[] { 20f, 32f, 13f, 24f, 20f, 20f, 30f, 15f, 15f, 20f, 20f, 60f };
            //        //table.SetWidths(widths);

            //        for (int row = 0; row < tableData.Rows; row++)
            //        {
            //            for (int col = 0; col < tableData.Columns; col++)
            //            {
            //                PdfPCell cell = new PdfPCell(new Phrase(tableData.GetData(row, col)));
            //                cell.FixedHeight = 30f;
            //                table.AddCell(cell);
            //            }
            //        }
            //        document.Add(table);

            //document.Close();

            //}
        }
    }
}
