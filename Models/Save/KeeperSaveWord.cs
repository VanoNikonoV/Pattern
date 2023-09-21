using Microsoft.Office.Interop.Word;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;

namespace Pattern.Models.Save
{
    /// <summary>
    /// Класс для сохраненияя данных о существах в формате .docx
    /// </summary>
    public class KeeperSaveWord : KeeperSave
    {
        /// <summary>
        /// Коструктор для сохраненияя данных о существах в формате .docx
        /// </summary>
        /// <param name="NameOfFile">Имя файла</param>
        public KeeperSaveWord(string NameOfFile): base(NameOfFile) { }
      

        public override void SaveAsChordatasAsync(ObservableCollection<Chordata> animal, 
            ObservableCollection<DataGridColumn> dataGridColumns)
        {
            Word.Application winword = new Word.Application();

            winword.Visible = false;

            object missing = System.Reflection.Missing.Value;

            //Создание нового документа
            Word.Document document =
                winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            //Добавление текста со стилем Заголовок 1
            Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            object styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Даны из приложения";
            para1.Range.InsertParagraphAfter();
            

            //Создание таблицы, колличество строк больше на 1, так ка добавляется шапка таблицы
            Word.Table firstTable = document.Tables.Add(para1.Range, NumRows: animal.Count +1, 
                NumColumns: dataGridColumns.Count, ref missing, ref missing);

            firstTable.Borders.Enable = 1;

            int y = default;

            foreach (Row row in firstTable.Rows)
            {
                foreach (Cell cell in row.Cells)
                {
                    int x = cell.ColumnIndex;  --x;

                    //Заголовок таблицы
                    if (cell.RowIndex == 1)
                    {
                        cell.Range.Text = dataGridColumns[x].Header.ToString();

                        cell.Range.Font.Bold = 1;
                        //Задаем шрифт и размер текста
                        cell.Range.Font.Name = "verdana";
                        cell.Range.Font.Size = 12;
                        cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                        //Выравнивание текста в заголовках столбцов по центру
                        cell.VerticalAlignment =
                        WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment =
                        WdParagraphAlignment.wdAlignParagraphCenter;
                        
                    }
                    //Значения ячеек
                    else
                    {
                        switch (cell.ColumnIndex)
                        {
                            case 1: cell.Range.Text = animal[y].Id.ToString(); break;
                            case 2: cell.Range.Text = animal[y].NameClass.ToString(); break;
                            case 3: cell.Range.Text = animal[y].LivingEnvironment.ToString(); break;
                            case 4: cell.Range.Text = animal[y].Size.ToString(); break;
                            case 5:
                                cell.Range.Text = animal[y].Detachment.ToString();
                                ++y;
                                break;
                        }
                    
                }
                }
            }
            winword.Visible = true;

            //Сохранение документа
            object filename = this.NameOfFile as object;
            document.SaveAs(ref filename);
            //Закрытие текущего документа
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            //Закрытие приложения Word
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;

        }
    }
}
