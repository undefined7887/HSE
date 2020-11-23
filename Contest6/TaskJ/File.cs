using System;
using System.Collections.Generic;
using System.Text;

class File
{
    private string _name;
    private int _size;

    public File(string name, int size)
    {
        Name = name;
        Size = size;
    }

    public File(File file): this(file._name,file._size)
    {
      
    }
    public string Name
    {
        get => _name;
        set {
            if (value.Length <= 0 || value.Length >= 15)
            {
                throw new ArgumentException("Incorrect file name");
            }
            _name = value;
        }
    }

    public int Size
    {
        get => _size;
        set {
            if (value <= 0)
            {
                throw new ArgumentException("Incorrect file size");
            }
            _size = value;
        }
    }

    public override string ToString()
    {
        return $"{_name,-15} {_size,5}";
    }
}
