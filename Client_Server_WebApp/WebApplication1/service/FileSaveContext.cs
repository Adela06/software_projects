using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.model;

namespace WebApplication1.service
{

    //context class pt folosirea strategiei
    public class FileSaveContext
    {
        private IFileSaveStrategy _fileSaveStrategy;

        public void SetFileSaveStrategy(IFileSaveStrategy fileSaveStrategy)
        {
            _fileSaveStrategy = fileSaveStrategy;
        }

        public void SaveFile(List<Plant> plants, string filePath)
        {
            _fileSaveStrategy.Save(plants, filePath);
        }
    }
}