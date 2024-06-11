using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProductPreview.Components.Pages.Products.ProductDetailDialog;

namespace ProductPreview.Components.Pages.Products.ProductList;
public partial class ProductListComponent : ComponentBase
{
    [Inject] IDialogService DialogService { get; set; } = default!;
    private string SearchValue { get; set; } = string.Empty;
    private List<string> Categories = new List<string>();
    private string SelectedCategory { get; set; } = "Coffee";

    protected override void OnInitialized()
    {
        base.OnInitialized();

        GenerateListOfCategories();
    }

    private void GenerateListOfCategories()
    {
        Categories.Clear();
        Categories.Add("All Menu");
        Categories.Add("Desert");
        Categories.Add("Drink");
        Categories.Add("Cake");
        Categories.Add("Light Meal");
        Categories.Add("Coffee");
        Categories.Add("Burger");
        Categories.Add("Breakfast");
    }




    private void OpenProductDetailDialog()
    {
        DialogOptions dialogOptions = new();
        dialogOptions.MaxWidth = MaxWidth.Large;
        dialogOptions.DisableBackdropClick = true;
        DialogService.Show<ProductDetailDialogComponent>("", dialogOptions);
    }
}
