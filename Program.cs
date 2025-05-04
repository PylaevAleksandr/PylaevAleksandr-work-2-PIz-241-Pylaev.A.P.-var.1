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
    // С небольшой помощью гитхаба нашел пример кода, но нужно его адаптировать под себя
    public class WordDocument : ElectronicDocument
    {
        public int WordVersion { get; set; } // Уникальное свойство

        public WordDocument()
        {
        }

        public WordDocument(string name, string author, string keywords, string topic, string filePath, int version)
            : base(name, author, keywords, topic, filePath)
        {
            WordVersion = version;
        }

        public override string DisplayInfo()
        {
            return base.DisplayInfo() + $"\nВерсия Word: {WordVersion}";
        }
    }

    public class PdfDocument : ElectronicDocument
    {
        public bool IsEncrypted { get; set; }

        public PdfDocument()
        {
        }

        public PdfDocument(string name, string author, string keywords, string topic, string filePath, bool isEncrypted)
            : base(name, author, keywords, topic, filePath)
        {
            IsEncrypted = isEncrypted;
        }

        public override string DisplayInfo()
        {
            return base.DisplayInfo() + $"\nЗашифрованный: {IsEncrypted}";
        }
    }
    public class ExcelDocument : ElectronicDocument
    {
        public int SheetCount { get; set; }

        public ExcelDocument()
        {
        }

        public ExcelDocument(string name, string author, string keywords, string topic, string filePath, int sheetCount)
            : base(name, author, keywords, topic, filePath)
        {
            SheetCount = sheetCount;
        }

        public override string DisplayInfo()
        {
            return base.DisplayInfo() + $"\nКоличество листов: {SheetCount}";
        }
    }
    public class TxtDocument : ElectronicDocument
    {
        public int CharacterCount { get; set; }

        public TxtDocument()
        {
        }

        public TxtDocument(string name, string author, string keywords, string topic, string filePath, int charCount)
            : base(name, author, keywords, topic, filePath)
        {
            CharacterCount = charCount;
        }

        public override string DisplayInfo()
        {
            return base.DisplayInfo() + $"\nКоличество символов: {CharacterCount}";
        }
    }
    public class HtmlDocument : ElectronicDocument
    {
        public bool HasCSS { get; set; }

        public HtmlDocument()
        {
        }

        public HtmlDocument(string name, string author, string keywords, string topic, string filePath, bool hasCss)
            : base(name, author, keywords, topic, filePath)
        {
            HasCSS = hasCss;
        }

        public override string DisplayInfo()
        {
            return base.DisplayInfo() + $"\nИмеет CSS: {HasCSS}";
        }
    }
}
