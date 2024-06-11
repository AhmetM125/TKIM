using TKIM.Panel.Base;

namespace TKIM.Panel.Pages.Category;

public partial class IndexComponent :RazorComponentBase
{
    void ChangeCategory(PageType pageType)
        => PageType = pageType;

    string IsButtonActive(PageType pageType)
    {
        return PageType == pageType ? "btn-primary" : "btn-outline-primary";
    }

}


    
