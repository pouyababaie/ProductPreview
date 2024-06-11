namespace ProductPreview.Services.Drawer
{
    public interface IApplicationDrawer
    {
        bool IsDrawerOpen { get; set; }
        void ChangeDrawerOpenState(bool state);
    }
}
