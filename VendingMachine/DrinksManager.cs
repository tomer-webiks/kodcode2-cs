using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace VendingMachine
{
    internal class DrinksManager
    {
        private XmlDocument _document;
        public DrinksManager(XmlDocument doc) {
            _document = doc;
        }
        public List<List<string>> GetDrinksData()
        {
            List<List<string>> AllDrinks = new List<List<string>>();
            XmlNodeList drinksNodes = _document.SelectNodes("/drinks/drink");
            if (drinksNodes != null) { 
                foreach (XmlNode drink in drinksNodes)
                {
                    List<string> drinkList= new List<string>();
                    if(drink.ChildNodes != null)
                    {
                        foreach(XmlNode drinkData in drink.ChildNodes)
                        {
                            drinkList.Add(drinkData.InnerText);       
                        }
                        AllDrinks.Add(drinkList);
                    }
                }
            }
            return AllDrinks;
        }

        private XmlNode GetRoot()
        {
            return _document.GetElementsByTagName("drinks")[0];
        }

        public void AddDrink(List<string> drinks)
        {
            XmlElement drinkElemnt = _document.CreateElement("drink");
            List<string> tagsName = new List<string>() { "name","soger", "coffee", "cacao", "milk", "price" };
            for (int i = 0; i < tagsName.Count; i++) { 
                XmlElement child = _document.CreateElement(tagsName[i]);
                child.InnerText = drinks[i];
                drinkElemnt.AppendChild(child);
            }
            GetRoot().AppendChild(drinkElemnt);
        }

        public void Save()
        {
            MainProject.Save(_document);
        }

        public void UpdateDrink(List<string> drinks) {
            XmlNodeList drinksList = _document.GetElementsByTagName("name");

            if (drinksList == null) return;
            foreach (XmlNode drink in drinksList)
            {
                if (drink.InnerText == drinks[0])
                {
                    int i = 0;
                    foreach(XmlNode child in drink.ParentNode)
                    {
                        child.InnerText = drinks[i];
                        i++;
                    }
                }
            }
        }

        public List<string> GetDrinkByName(string name)
        {
            List<string> list = null;
            XmlNodeList drinksList = _document.GetElementsByTagName("name");

            // חיפוש משקה לפי מאפיין, חיפוש מוחלט
            //XmlNode drinkNameNode = _document.SelectSingleNode($"/drinks/drink/name[text()='{name}']");
            //XmlNode drinkNode = _document.SelectSingleNode($"/drinks/drink[name='{name}']");

            // חיפוש על מאפיינים - Attributes
            //XmlNodeList drinkNodes = _document.SelectNodes($"/drinks/drink[starts-with(name, '{name}')]");

            // חיפוש על נודים פנימיים - החזרת נוד אחד
            //XmlNode drinkNameNode = _document.SelectSingleNode($"/drinks/drink/name[starts-with(text(), '{name}')]");

            // חיפוש על נודים פנימיים - החזרת נוד אחד
            //XmlNode drinkNameNode = _document.SelectSingleNode($"/drinks/drink/name[starts-with(text(), '{name}')]");

            if (drinksList == null) return null;
            foreach (XmlNode drink in drinksList)
            {
                if (drink.InnerText == name)
                {
                    list = GetAllData(drink.ParentNode);
                    break;
                }
            }
            return list;

            return null;
        }

        private List<string> GetAllData(XmlNode drink)
        {
            List<string> list = new List<string>();
            foreach (XmlNode child in drink.ChildNodes)
            {
                list.Add(child.InnerText);
            }
            return list;
        }
    }
}
