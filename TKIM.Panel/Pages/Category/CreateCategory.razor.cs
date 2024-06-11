using TKIM.Panel.Base;

namespace TKIM.Panel.Pages.Category;

public partial class CreateCategory : RazorComponentBase
{
    async Task Submit()
    {
        await Task.Delay(1000);
        LayoutValue.ShowMessage("Category created successfully", MessageType.Success);
    }
}
