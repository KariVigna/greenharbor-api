namespace GreenHarborApi.Models
{
  public class PagedParameters
  {
    const int maxPageSize = 10;
    public int PageNumber { get; set; } = 1;
    private int _pageSize = 10;
    public int PageSize
    {
      get
      {
        return _pageSize;
      }
      set
      {
        _pageSize = (value > maxPageSize) ? maxPageSize : value;
      }
    }
  }
}