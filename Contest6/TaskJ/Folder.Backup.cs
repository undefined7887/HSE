using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

partial class Folder
{
    internal class Backup
    {
        private Folder _folder;

        public Backup(Folder folder)
        {
            _folder = new Folder
            {
                files = new List<File>(folder.files)
            };
        }


        public static void Restore(Folder folder, Backup backup)
        {
            folder.files = new List<File>(backup._folder.files);
        }
    }

    public void AddFile(string name, int size)
    {
        files.Add(new File(name, size));
    }

    public void RemoveFile(File file)
    {
        files.Remove(file);
    }

    public File this[int i]
    {
        get
        {
            if (i < 0 || i >= files.Count)
                throw new IndexOutOfRangeException("Not enough files or index less zero");

            return files[i];
        }
    }

    public File this[string filename]
    {
        get
        {
            var file = files.Find(x => x.Name.Equals(filename));
            if (file == null)
                throw new ArgumentException("File not found");

            return file;
        }
    }

    public override string ToString()
    {
        var content = $"Files in folder:{Environment.NewLine}";
        content = files.Aggregate(content, (current, file) => current + file + Environment.NewLine);

        return content.TrimEnd();
    }
}