namespace OOPsl.DocumentFunctions.Formats
{
    public class PlainTextDocument : Document
    {
        public PlainTextDocument(string fileName)
        {
            FileName = fileName + ".txt";
            VersionHistory.Add(fileName);
        }

        public override void Create()
        {
            File.WriteAllText(FileName, "Новый текстовый документ.");
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
            Console.WriteLine("Введите новый текст:");
            Content = Console.ReadLine();
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
            // Реализация сохранения документа
        }

        public override void Load()
        {
            // Реализация загрузки документа
        }
    }
}
