using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using WpfApp8.Models;

namespace WpfApp8.Services
{
    internal class XmlDataService : IDataService
    {
        public List<Dish> GetAllDishes()
        {
            List<Dish> dishesList = new List<Dish>();
            string xmlFileName = Path.Combine(Environment.CurrentDirectory, @"Data\Data.xml");
            XDocument XDoc=XDocument.Load(xmlFileName);
            var dishes = XDoc.Descendants("Dish");
            foreach (var d in dishes)
            {
                Dish dish = new Dish();
                dish.Name = d.Element("Name").Value;
                dish.Category = d.Element("Category").Value;
                dish.Comment= d.Element("Comment").Value;
                dish.Score = double.Parse(d.Element("Score").Value);
                dishesList.Add(dish);
            }
            return dishesList;
        }
    }
}
