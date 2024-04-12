namespace Project.ViewModels;

public class ResponseModel
{
    public int      status  { get; set; }
    public string   message { get; set; }
    public dynamic? data    { get; set; }
}