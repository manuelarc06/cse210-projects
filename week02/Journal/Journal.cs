public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        if (!file.EndsWith(".txt"))
        {
            file += ".txt";
        }
        List<string> lines = new List<string>();
        foreach (Entry entry in _entries)
        {
            string line = entry._date + "~" + entry._promptText + "~" + entry._entryText;
            lines.Add(line);
        }

        System.IO.File.WriteAllLines(file, lines);
    }

    public void LoadFromFile(string file)
    {
        _entries.Clear();
        string[] lines = System.IO.File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split('~');

            Entry entry = new Entry();
            entry._date = parts[0];
            entry._promptText = parts[1];
            entry._entryText = parts[2];
            _entries.Add(entry);
        }
    }
}