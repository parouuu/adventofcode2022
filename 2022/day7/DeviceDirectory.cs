public class DeviceFile
{
    public string Name { get; set; }
    public int Size { get; set; }
}

public class DeviceDirectory
{
    public string Name { get; set; }

    public List<DeviceDirectory> DirList = new List<DeviceDirectory>();
    public List<DeviceFile> FileList = new List<DeviceFile>();
    public DeviceDirectory Parent { get; set; }


    public void AddDirectory(DeviceDirectory element)
    {
        DirList.Add(element);
    }

    public void AddFile(DeviceFile element)
    {
        FileList.Add(element);
    }

    public int GetSize()
    {
        var fileSize = FileList.Where(x => x.GetType() == typeof(DeviceFile)).Sum(x => x.Size);
        var dirSize = DirList.Where(x => x.GetType() == typeof(DeviceDirectory)).Sum(x => x.GetSize());
        return fileSize + dirSize;
    }
}
