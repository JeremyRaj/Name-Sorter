namespace name_sorter.dataservice
{
    public interface IFileProcessor
    {
        string[] GetFileContents();
        void WriteFileContents(string[] dataToWrite);
    }
}
