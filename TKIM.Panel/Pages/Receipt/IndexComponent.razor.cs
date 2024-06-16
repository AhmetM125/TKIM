using TKIM.Panel.Base;

namespace TKIM.Panel.Pages.Receipt;

public partial class IndexComponent :RazorComponentBase
{
    private void ChangePage(PageType pageType)
    {
        PageType = pageType;
    }

    private string IsButtonActive(PageType pageType)
    {
        return PageType != pageType ? "btn-outline-primary" : "btn-primary";
    }
}
