namespace OOPsl.DocumentFunctions.Formats
{
    public class MarkdownDocument : Document
    {
        public MarkdownDocument(string fileName)
        {
            FileName = fileName;
            VersionHistory.Add(fileName);
        }

        public override void Create()
        {
            File.WriteAllText(FileName, "");  // Реализация создания Markdown документа 
        }

        public override void Open()
        {
            if (File.Exists(FileName))
            {
                Content = File.ReadAllText(FileName);
            }
            // Реализация открытия Markdown документа 

        }

        public override void Edit()
        {
            Console.WriteLine("Введите новый текст Markdown:");
            string newText = Console.ReadLine();
            Content = $"# Заголовок\n\n{newText}";
            // Реализация редактирования Markdown документа 
        }

        public override void Delete()
        {
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
            // Реализация удаления Markdown документа 
        }

        public override void Save()
        {
            File.WriteAllText(FileName, Content);
            // Реализация сохранения Markdown документа (при вызове из DocumentManager) 
        }

        public override void Load()
        {
            // Реализация загрузки Markdown документа 
        }
    }
}
