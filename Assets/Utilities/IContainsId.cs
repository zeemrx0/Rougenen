namespace LNE.Utilities
{
  public interface IContainsId
  {
    public string Id { get; set; }

    public void GenerateId();
  }
}
