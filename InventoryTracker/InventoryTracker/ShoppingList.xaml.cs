using InventoryTracker.Models;
using System;
using System.Collections.Generic;
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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Paragraph = iTextSharp.text.Paragraph;
using iTextSharp.text.pdf.parser;
using Microsoft.Win32;

namespace InventoryTracker
{
    /// <summary>
    /// ShoppingList.xaml 的交互逻辑
    /// </summary>
    public partial class ShoppingList : Window
    {
        private string saveLocation;
        //  private Inventory inventory;
        public ShoppingList(Inventory inventory)
        {
            InitializeComponent();
            //this.inventory = inventory;
            dgShoppingList.ItemsSource = inventory.ShoppingList();
            
        }

        private void BtnSaveShoppingList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 50);

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Pdf Files|*.pdf";
                if (saveFileDialog.ShowDialog() == true)
                {
                    MessageBox.Show(saveFileDialog.FileName);
                    saveLocation = saveFileDialog.FileName;

                    PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(saveLocation, FileMode.Create));
                    doc.Open();
                    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("1.png");
                    PdfPTable table = new PdfPTable(new float[] { 160, 100, 100, 100, 80, 150 });
                    Font font = new Font(Font.FontFamily.COURIER, 25, Font.BOLD, BaseColor.PINK);
                    PdfPCell cell = new PdfPCell(new Phrase("Shopping List", font));
                    cell.Colspan = dgShoppingList.Columns.Count;
                    cell.HorizontalAlignment = 1;//0=left,1=centre,2=right
                    cell.VerticalAlignment = 1;
                    cell.PaddingBottom = 20;
                    cell.PaddingTop = 20;
                    table.AddCell(cell);

                    for (int i = 0; i < dgShoppingList.Columns.Count; i++)
                    {
                        table.AddCell(new Phrase(dgShoppingList.Columns[i].Header.ToString()));
                    }
                    table.HeaderRows = 1;


                    for (int i = 0; i < dgShoppingList.Items.Count; i++)
                    {
                        for (int j = 0; j < dgShoppingList.Columns.Count; j++)
                        {
                            if (dgShoppingList.Items[i] != null)
                                table.AddCell((dgShoppingList.Columns[j].GetCellContent(dgShoppingList.Items[i]) as TextBlock).Text.ToString());
                        }
                    }
                    doc.Add(image);
                    doc.Add(table);
                    doc.Close();
                    MessageBox.Show("Status: Records saved to " + saveLocation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot save", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }
           

    }
}

