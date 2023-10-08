using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsControlLibrary
{
    public partial class TablePdfComponent1 : Component
    {
        public TablePdfComponent1()
        {
            InitializeComponent();
        }

        public TablePdfComponent1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void GeneratePdf(string filePath, string documentTitle, TableData[] tables)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(documentTitle) || tables == null || tables.Length == 0)
            {
                throw new ArgumentException("Invalid input data.");
            }

            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.OpenOrCreate));
            document.Open();

            foreach (var tableData in tables)
            {
                PdfPTable table = new PdfPTable(tableData.Columns);
                table.TotalWidth = 500f; //ширина таблицы
                table.LockedWidth = true;

                foreach (var rowData in tableData.Data)
                {
                    foreach (var cellData in rowData)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(cellData));
                        cell.Border = PdfPCell.TOP_BORDER | PdfPCell.BOTTOM_BORDER | PdfPCell.LEFT_BORDER | PdfPCell.RIGHT_BORDER;
                        table.AddCell(cell);
                    }
                }

                document.Add(new Paragraph(documentTitle));
                document.Add(table);
            }

            document.Close();
        }
    }

}