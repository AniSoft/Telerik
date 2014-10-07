using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

public interface IDocument
{
	string Name { get; }
	string Content { get; }
	void LoadProperty(string key, string value);
	void SaveAllProperties(IList<KeyValuePair<string, object>> output);
	string ToString();
}

public interface IEditable
{
	void ChangeContent(string newContent);
}

public interface IEncryptable
{
	bool IsEncrypted { get; }
	void Encrypt();
	void Decrypt();
}



// classes
public abstract class Document : IDocument
{
    protected string name;
    protected string content;


    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public string Content
    {
        get { return content; }
        protected set { content = value; }
    }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        if (this.Content != null)
        {
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(this.GetType().Name);
        sb.Append("[");
        IList<KeyValuePair<string, object>> attribs = new List<KeyValuePair<string, object>>();
        SaveAllProperties(attribs);
        attribs = attribs.OrderBy(item => item.Key).ToList();
        foreach (var item in attribs)
        {
            sb.Append(item.Key);
            sb.Append("=");
            sb.Append(item.Value);
            sb.Append(";");
        }
        sb.Remove(sb.Length - 1, 1);
        sb.Append("]");
        return sb.ToString();
    }
}

public abstract class BinaryDocument : Document
{
    public long? Size { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.Size = Convert.ToInt64(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if (this.Size != null)
        {
            output.Add(new KeyValuePair<string, object>("size", this.Size));
        }
        base.SaveAllProperties(output);
    }
}

public class TextDocument : Document, IEditable
{
    public string Charset { get; set; }
    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
        {
            this.Charset = value;
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if (this.Charset != null)
        {
            output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        }
        base.SaveAllProperties(output);
    }

    public void ChangeContent(string newContent)
    {
        base.Content = newContent;
    }
}

public abstract class EncryptableDocument : BinaryDocument, IEncryptable
{
    protected bool isEncrypted = false;

    public bool IsEncrypted
    {
        get { return isEncrypted; }
        set { isEncrypted = value; }
    }

    public void Encrypt()
    {
        IsEncrypted = true;
    }

    public void Decrypt()
    {
        IsEncrypted = false;
    }
    public override string ToString()
    {
        if (IsEncrypted)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append("[encrypted]");
            return sb.ToString();
        }
        else
        {
            return base.ToString();
        }
    }
}

public class PDFDocument : EncryptableDocument, IEditable
{
    public int? NumberOfPages  { get; set; }

    public void ChangeContent(string newContent)
    {
        base.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            //TODO check if value is int
            this.NumberOfPages = Convert.ToInt32(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if (this.NumberOfPages != null)
        {
            output.Add(new KeyValuePair<string, object>("pages", this.NumberOfPages));
        }
        base.SaveAllProperties(output);
    }
}

public abstract class OfficeDocument : EncryptableDocument
{
    public string Version { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "version")
        {
            this.Version = value;
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if (this.Version != null)
        {
            output.Add(new KeyValuePair<string, object>("version", this.Version));
        }
        base.SaveAllProperties(output);
    }
}

public class WordDocument : OfficeDocument, IEditable
{
    public int? NumberOfCharacters  { get; set; }

    public void ChangeContent(string newContent)
    {
        base.Content = newContent;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.NumberOfCharacters = Convert.ToInt32(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if (this.NumberOfCharacters != null)
        {
            output.Add(new KeyValuePair<string, object>("chars", this.NumberOfCharacters));
        }
        base.SaveAllProperties(output);
    }
}

public class ExcelDocument : OfficeDocument
{
    public int? NumberOfRows { get; set; }
    public int? NumberOfColumns { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.NumberOfRows = Convert.ToInt32(value);
        } if (key == "cols")
        {
            this.NumberOfColumns = Convert.ToInt32(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if (this.NumberOfRows != null)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.NumberOfRows));
        }
        if (this.NumberOfColumns != null)
        {
            output.Add(new KeyValuePair<string, object>("cols", this.NumberOfColumns));
        }
        base.SaveAllProperties(output);
    }
}

public class MultimediaDocument : BinaryDocument
{
    public long? Length { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.Length = Convert.ToInt64(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if (this.Length != null)
        {
            output.Add(new KeyValuePair<string, object>("length", this.Length));
        }
        base.SaveAllProperties(output);
    }
}

public class VideoDocument : MultimediaDocument
{
    public int? FrameRate { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
        {
            this.FrameRate = Convert.ToInt32(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if (this.FrameRate != null)
        {
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
        }
        base.SaveAllProperties(output);
    }
}

public class AudioDocument : MultimediaDocument
{
    public int? SampleRate  { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.SampleRate = Convert.ToInt32(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        if (this.SampleRate != null)
        {
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
        }
        base.SaveAllProperties(output);
    }
}

public class DocumentSystem
{
    private static IList<IDocument> documents = new List<IDocument>();

    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }

    private static void addDocument(IDocument doc, string[] attributes)
    {
        foreach (var attrib in attributes)
        {
            //TODO ako dokumenta nqma ime
            string[] keyAndValue = attrib.Split('=');
            doc.LoadProperty(keyAndValue[0], keyAndValue[1]);
        }
        if (doc.Name != null)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: {0}", doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }
  
    private static void AddTextDocument(string[] attributes)
    {
        IDocument doc = new TextDocument();
        addDocument(doc, attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        IDocument doc = new PDFDocument();
        addDocument(doc, attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        IDocument doc = new WordDocument();
        addDocument(doc, attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        IDocument doc = new ExcelDocument();
        addDocument(doc, attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        IDocument doc = new AudioDocument();
        addDocument(doc, attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        IDocument doc = new VideoDocument();
        addDocument(doc, attributes);
    }

    private static void ListDocuments()
    {
        foreach (var doc in documents)
        {
            Console.WriteLine(doc.ToString());
        }
        if (documents.Count == 0)
        {
            Console.WriteLine("No documents found");
        }
    }

    private static void EncryptDocument(string name)
    {
        bool isAnySuchDoc = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                isAnySuchDoc = true;
                EncryptableDocument encryptableDoc = doc as EncryptableDocument;
                if (encryptableDoc != null)
                {
                    encryptableDoc.Encrypt();
                    Console.WriteLine("Document encrypted: {0}", encryptableDoc.Name);
                }
                else
                {

                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
            }
        }
        if (!isAnySuchDoc)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool isAnySuchDoc = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                isAnySuchDoc = true;
                EncryptableDocument encryptableDoc = doc as EncryptableDocument;
                if (encryptableDoc != null)
                {
                    encryptableDoc.Decrypt();
                    Console.WriteLine("Document decrypted: {0}", encryptableDoc.Name);
                }
                else
                {

                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
            }
        }
        if (!isAnySuchDoc)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool isAnyEncriptableDoc = false;
        foreach (var doc in documents)
        {
            EncryptableDocument encryptableDoc = doc as EncryptableDocument;
            if (encryptableDoc != null)
            {
                encryptableDoc.Encrypt();
                isAnyEncriptableDoc = true;
            }
        }
        if (isAnyEncriptableDoc)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool isAnyEditableDoc = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                isAnyEditableDoc = true;
                IEditable editableDoc = doc as IEditable;
                if (editableDoc != null)
                {
                    editableDoc.ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", doc.Name);
                }
            }
            
        }
        if (!isAnyEditableDoc)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }
}

