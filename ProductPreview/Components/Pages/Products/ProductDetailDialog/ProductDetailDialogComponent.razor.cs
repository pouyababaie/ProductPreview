using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace ProductPreview.Components.Pages.Products.ProductDetailDialog;
public partial class ProductDetailDialogComponent : ComponentBase
{
    [CascadingParameter] MudDialogInstance MudDialog { get; set; } = default!;

    void Close() => MudDialog.Close<Product>(null);

    [Parameter]
    public Product ProductModel { get; set; } = default!;

    private int Counter = 1;

    private string Description { get; set; } = string.Empty;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

    }

    private void Increament()
    {
        ProductModel.Count++;
    }
    private void Decreament()
    {
        ProductModel.Count--;
    }


    private void AddProductToBucket()
    {
        MudDialog.Close<Product>(ProductModel);
    }
}
