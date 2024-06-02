using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.model;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WebApplication1.service
{
    public class DocFileSaveStrategy : IFileSaveStrategy
    {
        public void Save(List<Plant> plants, string filePath)
        {
            using (DocX document = DocX.Create(filePath))
            {
                Table table = document.AddTable(plants.Count + 1, 6);
                table.Design = TableDesign.ColorfulList;
                table.Rows[0].Cells[0].Paragraphs.First().Append("ID");
                table.Rows[0].Cells[1].Paragraphs.First().Append("Name");
                table.Rows[0].Cells[2].Paragraphs.First().Append("Type");
                table.Rows[0].Cells[3].Paragraphs.First().Append("Species");
                table.Rows[0].Cells[4].Paragraphs.First().Append("Carnivorous");
                table.Rows[0].Cells[5].Paragraphs.First().Append("Location");
                for (int i = 0; i < plants.Count; i++)
                {
                    table.Rows[i + 1].Cells[0].Paragraphs.First().Append(plants[i].Id);
                    table.Rows[i + 1].Cells[1].Paragraphs.First().Append(plants[i].PlantName);
                    table.Rows[i + 1].Cells[2].Paragraphs.First().Append(plants[i].PlantType);
                    table.Rows[i + 1].Cells[3].Paragraphs.First().Append(plants[i].Species);
                    table.Rows[i + 1].Cells[4].Paragraphs.First().Append(plants[i].Carnivorous);
                    table.Rows[i + 1].Cells[5].Paragraphs.First().Append(plants[i].Location);
                }
                document.InsertTable(table);
                document.Save();
            }
        }
    }
}