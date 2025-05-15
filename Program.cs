using System;

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
}                                                                                   //и наверное сделаю мейн что б посмотреть работает ли это все