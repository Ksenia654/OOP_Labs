namespace OOPsl.DocumentFunctions.Formats
{
    public class RichTextDocument : Document
    {
        public RichTextDocument(string fileName)
        {
            FileName = fileName + ".rtf";
            VersionHistory.Add(fileName);
        }

        public override void Create()
        {
            File.WriteAllText(FileName, "{\\rtf1\\ansi\\deff0}");
            // Реализация создания документа
        }

        public override void Open()
        {
            if (File.Exists(FileName))
            {
                Content = File.ReadAllText(FileName);
            }
            // Реализация открытия документа
        }

        public override void Edit()
        {
            Console.WriteLine("Введите текст для RTF:");
            Content = $"{{\\rtf1\\ansi\\deff0 {Console.ReadLine()} }}";
            // Реализация редактирования документа
        }

        public override void Delete()
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
            // Реализация удаления документа
        }

        public override void Save()
        {
            File.WriteAllText(FileName, Content);
        }
            // Реализация сохранения документа
       

        public override void Load()
        {
            // Реализация загрузки документа
        }
    }
}
