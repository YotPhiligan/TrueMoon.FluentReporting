namespace TrueMoon.FluentReporting.Tests;

public class TestData2
{
    public string TitleData { get; set; }
    public List<(string key, string value1, string value2)> List { get; set; }
    public string TextData { get; set; }
    
    public byte[] ImageData { get; set; }
    
    public List<List<(string key, string value)>> List2 { get; set; }
}