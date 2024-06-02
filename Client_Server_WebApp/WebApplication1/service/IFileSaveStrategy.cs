using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.model;

namespace WebApplication1.service
{
    //strategy dp
    //interfata pe care o vor implementa toate strategiile de salvare in fisier
    public interface IFileSaveStrategy
    {
        void Save(List<Plant> plants, string filePath);
    }
}