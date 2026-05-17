namespace BigestWork.Logic;

public interface IFunc
{
    public void Configure(Setting setting);

    public bool SaveInFile(string path);

    public bool LoadFromFile(string path);
}