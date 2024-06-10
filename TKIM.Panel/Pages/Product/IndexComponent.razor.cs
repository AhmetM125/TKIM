using TKIM.Panel.Base;

namespace TKIM.Panel.Pages.Product;

public partial class IndexComponent : RazorComponentBase
{
    private PageType PageType { get; set; } = PageType.Main;


    private void ChangePage(PageType pageType)
    {
        PageType = pageType;
    }

}

public enum PageType
{
    Main = 0,
    Insert = 1,
    Update = 2,
    List = 3

}
