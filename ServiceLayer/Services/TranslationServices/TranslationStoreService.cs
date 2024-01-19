using DataLayer.Models;
using DataLayer.Models.Interfaces;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.TranslationServices
{
    public class TranslationStoreService : IStoreService
    {


        public IStore ResearchResource()
        {
            Translator t1 = new Translator();
            t1.Id = 1;
            t1.Name = "ITALIAN";
            Translator t2 = new Translator();
            t2.Id = 2;
            t2.Name = "ENGLISH";
            Translator t3 = new Translator();
            t3.Id = 3;
            t3.Name = "JAPANESE";
            Translator t4 = new Translator();
            t4.Id = 4;
            t4.Name = "GERMAN";
            Translator t5 = new Translator();
            t5.Id = 5;
            t5.Name = "RUSSIAN";
            List<IProduct> list = new List<IProduct>();
            list.Add(t1);
            list.Add(t2);
            list.Add(t3);
            list.Add(t4);
            list.Add(t5);


            TranslationStore translationStore = new()
            { Name = "TRANSLATION STORE", ProductList = list };

            return translationStore;
        }


    }
}

