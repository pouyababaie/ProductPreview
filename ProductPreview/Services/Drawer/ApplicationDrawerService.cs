namespace ProductPreview.Services.Drawer
{
    public class ApplicationDrawerService : IApplicationDrawer
    {
        public bool IsDrawerOpen { get; set; } = false;

        public void ChangeDrawerOpenState(bool state)
        {
            IsDrawerOpen = state;
        }
    }
}
