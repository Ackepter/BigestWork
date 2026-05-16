namespace BigestWork.Logic;

public interface IFunc
{
    public void Configure(Setting setting);

    public void SaveInFile();

    public void LoadFromFile();
}