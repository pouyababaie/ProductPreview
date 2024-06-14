using Microsoft.AspNetCore.Components;
using ProductPreview.Services.Drawer;

namespace ProductPreview.Components.Layout;
public partial class MainLayout : LayoutComponentBase
{
    [Inject] IApplicationDrawer ApplicationDrawerService { get; set; } = default!;


    private bool _IsDraweropen = false;
    private bool IsDrawerOpen
    {
        get => _IsDraweropen;
        set
        {
            ApplicationDrawerService.IsDrawerOpen = value;
            ApplicationDrawerService.ChangeDrawerOpenState(value);
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }

}
