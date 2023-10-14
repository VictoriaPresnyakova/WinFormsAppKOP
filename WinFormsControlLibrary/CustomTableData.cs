using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsControlLibrary
{
    public class CustomTableData
    {
        public int Rows { get; }
        public int Columns { get; }
        public List<List<string>> Data { get; }

        public CustomTableData(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Data = new List<List<string>>();

            for (int i = 0; i < Rows; i++)
            {
                Data.Add(new List<string>());
            }
        }

        public string GetData(int row, int col)
        {
            if (row < 0 || row >= Rows || col < 0 || col >= Columns)
            {
                throw new ArgumentOutOfRangeException("Invalid row or column index.");
            }

            return Data[row][col];
        }
    }
}
