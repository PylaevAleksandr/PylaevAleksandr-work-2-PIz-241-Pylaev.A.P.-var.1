using DocumentManagement;
using System;

namespace DocumentManagement                          // Так, ну начнем
{                                                     // Из ваших слов я понял что лучше комментировать побольше,так и интереснее читать будет))
                                                  
    public class ElectronicDocument                   // Начнем, создаем док и прописываем необходимые поля
    {
                                                  
        public string Name { get; set; }             
                                 
        public string Author { get; set; }            

        public string Keywords { get; set; }          

        public string Topic { get; set; }             

        public string FilePath { get; set; }          

        public ElectronicDocument()                    // Конструктор с пустой реализацией что б засунуть свойства отдельно
        {
        }               

        public ElectronicDocument(string name, string author, string keywords, string topic, string filePath) // Конструктор с параметрами
        {
            Name = name;
            Author = author;
            Keywords = keywords;
            Topic = topic;
            FilePath = filePath;
        }

        public virtual void DisplayInfo()             // Отображаем и вводим инфу в документе
        {
            Console.WriteLine($"Имя: {Name}");
            Console.WriteLine($"Автор: {Author}");
            Console.WriteLine($"Ключевые слова: {Keywords}");
            Console.WriteLine($"Тематика: {Topic}");
            Console.WriteLine($"Путь к файлу: {FilePath}");
        }
    }
}
