using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace test1.Model
{
    class Base
    {
        public string[] models = {"Модель 1", "Модель 2", "Модель 3", "Модель 4"};
        public string[] types = {"Тип 1", "Тип 2", "Тип 3", "Тип 4"};
        public string[] deffects = {"Деффект 1", "Деффект 2", "Деффект 3", "Деффект 4"};
        public string[] priorities = {"Приоритет 1", "Приоритет 2", "Приоритет 3", "Приоритет 4"};
        public string[] statuses = {"Статус 1", "Статус 2", "Статус 3", "Статус 4"};
        public string filePath = "C:\\Users\\Admin\\source\\repos\\test1\\test1\\Data\\data.json";

        public void WriteObjectToFile(object orders)
        {
            var jsonObject = JsonSerializer.Serialize(orders as List<Order>);

            File.WriteAllText(filePath, jsonObject);
        }

        public List<Order> ReadObjectFromFile()
        {
            try
            {
                var jsonObject = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<Order>>(jsonObject);
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public List<Order> GenerateOrders()
        {
            List<Order> _orders = new List<Order>();
            for (int i = 0; i < 20; i++)
            {
                Order newOrder = new Order
                {
                    Id = i,
                    Model = models[i % 4],
                    Type = types[i % 4],
                    Deffect = deffects[i % 4],
                    Status = statuses[i % 4],
                    Comment = "надо что то приличное писать",
                    ClientName = "Дурашка"
                };
                _orders.Add(newOrder);
            }
            return _orders;
        }
    }
}
