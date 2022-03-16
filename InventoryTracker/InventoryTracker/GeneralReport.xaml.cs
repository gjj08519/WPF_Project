using InventoryTracker.Models;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;
using Window = System.Windows.Window;

namespace InventoryTracker
{

    /// <summary>
    /// GeneralReport.xaml 的交互逻辑
    /// </summary>
    public partial class GeneralReport : Window
    {
        ////Excel part some code from https://www.cnblogs.com/YYkun/p/7700702.html
        private string saveLocation;
        private DataTable dt = new DataTable();
        
        public GeneralReport(Inventory inventory)
        {
            InitializeComponent();
            dgItemsReport.ItemsSource = inventory.GetItems();
        }

        private void BtnSavePeport_Click(object sender, RoutedEventArgs e)
        {
            GetdataTableHeaderRow();
            ExcelReport();
        }
        private void GetdataTableHeaderRow()
        {
            
            //Build the header
            for (int i = 0; i < dgItemsReport.Columns.Count; i++)
            {
               if (dgItemsReport.Columns[i].Visibility == Visibility.Visible)//Only export visible columns  
               {
                    dt.Columns.Add(dgItemsReport.Columns[i].Header.ToString());
               }
            }

            //Build the row
            for (int i = 0; i < dgItemsReport.Items.Count; i++)
            {
                DataRow row = dt.NewRow();

                for (int j = 0; j < dgItemsReport.Columns.Count; j++)
                {
                    if (dgItemsReport.Columns[j].Visibility == Visibility.Visible)
                   {
                       if ((dgItemsReport.Columns[j].GetCellContent(dgItemsReport.Items[i]) as TextBlock) != null)//Populate visible column data 
                        {
                            row[j] = (dgItemsReport.Columns[j].GetCellContent(dgItemsReport.Items[i]) as TextBlock).Text.ToString();
                        }
                        else row[j] = "";
                   }
                }
                dt.Rows.Add(row);
            }
        }
        private void ExcelReport()
        {
            try
            {
                 //Create Excel
                  Application ExcelApp = new Application();
                  Workbook ExcelBook = ExcelApp.Workbooks.Add(System.Type.Missing);
  
                  //Create a worksheet (a sub-sheet in Excel) 1 means export data in the sub-sheet sheet1
                  Worksheet ExcelSheet = ExcelBook.Worksheets[1];
                
                //set details for excel
                SetExcelSheet(ExcelSheet);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Office 2007 File|*.xlsx|Office 2000-2003 File|*.xls|All Files|*.*"; ;
                if (saveFileDialog.ShowDialog() == true)
                {
                    MessageBox.Show(saveFileDialog.FileName);
                    saveLocation = saveFileDialog.FileName;
                    ExcelBook.SaveAs(saveLocation);
                    MessageBox.Show("Status: Records saved to " + saveLocation);

                    //Release processes that may not have been released
                    ExcelBook.Close();
                    ExcelApp.Quit();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot save: " + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void SetExcelSheet(Worksheet ExcelSheet)
        {

            //worksheet name
            ExcelSheet.Name = "General Report";

            //Set Sheet Title
            string start = "A1";
            string end = GetEnd(dt.Columns.Count) + "1";

            Range _Range = ExcelSheet.get_Range(start, end);
            _Range.Merge(0);
            _Range = ExcelSheet.get_Range(start, end);
            _Range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
            _Range.Font.Size = 25;
            _Range.Font.Name = "bold";
            ExcelSheet.Cells[1, 1] = "General Report";
            _Range.EntireColumn.AutoFit(); //Automatically adjust column width

            //Write header
            for (int m = 0; m < dt.Columns.Count; m++)
            {
                ExcelSheet.Cells[2, m + 1] = dt.Columns[m].ColumnName.ToString();

                start = "A2";
                end = GetEnd(dt.Columns.Count) + "2";

                _Range = (Microsoft.Office.Interop.Excel.Range)ExcelSheet.get_Range(start, end);
                _Range.Font.Size = 15 ;
                _Range.Font.Name = "bold";
                _Range.EntireColumn.AutoFit();
                _Range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                _Range.Borders.get_Item(XlBordersIndex.xlDiagonalDown);
                _Range.Borders.Weight = XlBorderWeight.xlThick;
            }
            // Write data
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ExcelSheet.Cells[i + 3, j + 1] = dt.Rows[i][j].ToString();
                }
            }
            //Set table attributes 
            for (int n = 0; n < dt.Rows.Count + 1; n++)
            {
                start = "A" + (n + 3).ToString();
                end = GetEnd(dt.Columns.Count) + (n + 3).ToString();

                //Get multiple cell ranges in Excel
                _Range = ExcelSheet.get_Range(start, end);

                _Range.Font.Size = 12;
                _Range.Font.Name = "Times New Roman";

                _Range.EntireColumn.AutoFit();
                _Range.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                _Range.Borders.get_Item(XlBordersIndex.xlDiagonalDown);
                _Range.Borders.Weight = XlBorderWeight.xlThick;
            }
        }
        private string GetEnd(int count)
        {
            string str = String.Empty;

            switch (count)
            {
                case 1:
                    str = "A";
                    break;
                case 2:
                    str = "B";
                    break;
                case 3:
                    str = "C";
                    break;
                case 4:
                    str = "D";
                    break;
                case 5:
                    str = "E";
                    break;
                case 6:
                    str = "F";
                    break;
                case 7:
                    str = "G";
                    break;
                case 8:
                    str = "H";
                    break;
                case 9:
                    str = "I";
                    break;
                case 10:
                    str = "J";
                    break;
                case 11:
                    str = "K";
                    break;
                case 12:
                    str = "L";
                    break;
                case 13:
                    str = "M";
                    break;
                case 14:
                    str = "N";
                    break;
                case 15:
                    str = "O";
                    break;
                case 16:
                    str = "P";
                    break;

                default:
                    str = "Q";
                    break;
            }
            return str;
        }

       
    }
}
