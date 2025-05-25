using System;
using System.Collections.Generic;

public class ElectronicDocument
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Keywords { get; set; }
    public string Topic { get; set; }
    public string FilePath { get; set; }
    public ElectronicDocument() 
    { 
    }
    public ElectronicDocument(string name, string author, string keywords, string topic, string filePath)
    {
        Name = name;
        Author = author;
        Keywords = keywords;
        Topic = topic;
        FilePath = filePath;
    }
    public virtual string GetInfo()                     // С этого момента пришлось хорошенько все переработать.
    {
        return $"Имя: {Name}\nАвтор: {Author}\nКлючевые слова: {Keywords}\nТематика: {Topic}\nПуть к файлу: {FilePath}";
    }
}
public class WordDocument : ElectronicDocument          // Этот фрагмент еще в прошлом коммите я нашел на гитхабе и переработал под свои реалии.
{
    public int WordVersion { get; set; }

    public WordDocument()
    {
    }
    public WordDocument(string name, string author, string keywords, string topic, string filePath, int version)
        : base(name, author, keywords, topic, filePath)
    {
        WordVersion = version;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $"\nВерсия Word: {WordVersion}";
    }
}                                                       // Вот до этого момента, остальные по аналогии додумал сам.
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
    public override string GetInfo()
    {
        return base.GetInfo() + $"\nЗашифрованный: {IsEncrypted}";
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
    public override string GetInfo()
    {
        return base.GetInfo() + $"\nКоличество листов: {SheetCount}";
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
    public override string GetInfo()
    {
        return base.GetInfo() + $"\nКоличество символов: {CharacterCount}";
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
    public override string GetInfo()
    {
        return base.GetInfo() + $"\nИмеет CSS: {HasCSS}";
    }
}                                                     // Ад начинается))))
public class DocumentManager
{
    private static DocumentManager _instance = new DocumentManager();
    private List<ElectronicDocument> _documents = new List<ElectronicDocument>(); // добавляем список доков
    public DocumentManager()                                                        //как же без конструктора
    {
    }

    public static DocumentManager Instance                                           // код для дотсупа к экземпляру
    {
        get
        {
            return _instance; 
        }
    }

    public void AddDocument(ElectronicDocument document)                            // средство добавления документа
    {
        _documents.Add(document);
        Console.WriteLine($"Документ '{document.Name}' добавлен.");
    }

    public void DisplayDocuments()                                                  // отображаем документ
    {
        foreach (var doc in _documents)
        {
            Console.WriteLine(doc.GetInfo());
            Console.WriteLine(new string('-', 50));
        }
    }
}                                                                                   //Я разбирался с этим дерьмом 2 недели....
class Program
{
    static void Main(string[] args)
    {
        var manager = DocumentManager.Instance;

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Добавить Word документ");
            Console.WriteLine("2. Добавить PDF документ");
            Console.WriteLine("3. Добавить Excel документ");
            Console.WriteLine("4. Добавить TXT документ");
            Console.WriteLine("5. Добавить HTML документ");
            Console.WriteLine("6. Показать все документы");
            Console.WriteLine("7. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите имя документа: ");
                    string wordName = Console.ReadLine();
                    Console.Write("Введите автора: ");
                    string wordAuthor = Console.ReadLine();
                    Console.Write("Введите ключевые слова: ");
                    string wordKeywords = Console.ReadLine();
                    Console.Write("Введите тематику: ");
                    string wordTopic = Console.ReadLine();
                    Console.Write("Введите путь к файлу: ");
                    string wordFilePath = Console.ReadLine();
                    Console.Write("Введите версию Word: ");
                    int wordVersion = int.Parse(Console.ReadLine());

                    var wordDoc = new WordDocument(wordName, wordAuthor, wordKeywords, wordTopic, wordFilePath, wordVersion);
                    manager.AddDocument(wordDoc);
                    break;

                case "2":
                    Console.Write("Введите имя документа: ");
                    string pdfName = Console.ReadLine();
                    Console.Write("Введите автора: ");
                    string pdfAuthor = Console.ReadLine();
                    Console.Write("Введите ключевые слова: ");
                    string pdfKeywords = Console.ReadLine();
                    Console.Write("Введите тематику: ");
                    string pdfTopic = Console.ReadLine();
                    Console.Write("Введите путь к файлу: ");
                    string pdfFilePath = Console.ReadLine();
                    Console.Write("Зашифрованный (true/false): ");
                    bool isEncrypted = bool.Parse(Console.ReadLine());

                    var pdfDoc = new PdfDocument(pdfName, pdfAuthor, pdfKeywords, pdfTopic, pdfFilePath, isEncrypted);
                    manager.AddDocument(pdfDoc);
                    break;

                case "3":
                    Console.Write("Введите имя документа: ");
                    string excelName = Console.ReadLine();
                    Console.Write("Введите автора: ");
                    string excelAuthor = Console.ReadLine();
                    Console.Write("Введите ключевые слова: ");
                    string excelKeywords = Console.ReadLine();
                    Console.Write("Введите тематику: ");
                    string excelTopic = Console.ReadLine();
                    Console.Write("Введите путь к файлу: ");
                    string excelFilePath = Console.ReadLine();
                    Console.Write("Введите количество листов: ");
                    int sheetCount = int.Parse(Console.ReadLine());

                    var excelDoc = new ExcelDocument(excelName, excelAuthor, excelKeywords, excelTopic, excelFilePath, sheetCount);
                    manager.AddDocument(excelDoc);
                    break;

                case "4":
                    Console.Write("Введите имя документа: ");
                    string txtName = Console.ReadLine();
                    Console.Write("Введите автора: ");
                    string txtAuthor = Console.ReadLine();
                    Console.Write("Введите ключевые слова: ");
                    string txtKeywords = Console.ReadLine();
                    Console.Write("Введите тематику: ");
                    string txtTopic = Console.ReadLine();
                    Console.Write("Введите путь к файлу: ");
                    string txtFilePath = Console.ReadLine();
                    Console.Write("Введите количество символов: ");
                    int charCount = int.Parse(Console.ReadLine());

                    var txtDoc = new TxtDocument(txtName, txtAuthor, txtKeywords, txtTopic, txtFilePath, charCount);
                    manager.AddDocument(txtDoc);
                    break;

                case "5":
                    Console.Write("Введите имя документа: ");
                    string htmlName = Console.ReadLine();
                    Console.Write("Введите автора: ");
                    string htmlAuthor = Console.ReadLine();
                    Console.Write("Введите ключевые слова: ");
                    string htmlKeywords = Console.ReadLine();
                    Console.Write("Введите тематику: ");
                    string htmlTopic = Console.ReadLine();
                    Console.Write("Введите путь к файлу: ");
                    string htmlFilePath = Console.ReadLine();
                    Console.Write("Имеет CSS (true/false): ");
                    bool hasCSS = bool.Parse(Console.ReadLine());

                    var htmlDoc = new HtmlDocument(htmlName, htmlAuthor, htmlKeywords, htmlTopic, htmlFilePath, hasCSS);
                    manager.AddDocument(htmlDoc);
                    break;

                case "6":
                    manager.DisplayDocuments();
                    break;

                case "7":
                    return;

                default:
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                    break;
            }
        }
    }
}