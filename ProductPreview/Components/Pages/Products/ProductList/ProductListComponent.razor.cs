using Microsoft.AspNetCore.Components;
using MudBlazor;
using ProductPreview.Components.Pages.Products.PaymentMethodDialog;
using ProductPreview.Components.Pages.Products.ProductDetailDialog;

namespace ProductPreview.Components.Pages.Products.ProductList;
public partial class ProductListComponent : Microsoft.AspNetCore.Components.ComponentBase
{
    [Inject] IDialogService DialogService { get; set; } = default!;
    private string SearchValue { get; set; } = string.Empty;
    private List<string> Categories = new List<string>();
    private string SelectedCategory { get; set; } = "Coffee";
    private List<Product> SelectedProducts { get; set; } = new List<Product>();
    private bool IsDrawerOpen { get; set; } = false;
    private List<Product> ProductList { get; set; } = new List<Product>();
    private List<Product> TempProductList { get; set; } = new List<Product>();
    private bool IsLoading { get; set; } = false;
    private double TotalPrice { get; set; } = 0.0;
    protected override void OnInitialized()
    {
        base.OnInitialized();

        IsLoading = true;
        GenerateListOfCategories();

        GenerateListOfProducts();

        TempProductList = ProductList;

        IsLoading = false;
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

    private void GenerateListOfProducts()
    {
        ProductList.Clear();
        ProductList = new List<Product>() {
           new Product("Margherita Pizza", "Classic pizza with tomatoes, mozzarella cheese, and fresh basil.", count :0, price:8.99),
            new Product("Spaghetti Carbonara", "Traditional Italian pasta with eggs, cheese, pancetta, and pepper.", count :0, price : 12.50),
            new Product("Caesar Salad", "Crisp romaine lettuce with Caesar dressing, croutons, and parmesan cheese.", count :0, price : 7.25),
            new Product("Grilled Salmon", "Fresh salmon fillet grilled to perfection, served with a side of vegetables.", count : 0, price : 18.99),
            new Product("Cheeseburger", "Juicy beef patty with cheddar cheese, lettuce, tomato, and onion on a toasted bun.", count : 0, price : 9.50),
            new Product("Chicken Alfredo", "Creamy Alfredo sauce with grilled chicken breast over fettuccine pasta.", count : 0, price : 14.75),
            new Product("Vegetable Stir Fry", "Mixed vegetables sautéed in a savory sauce, served over steamed rice.", count : 0, price : 11.00),
            new Product("Tiramisu", "Classic Italian dessert with layers of coffee-soaked ladyfingers and mascarpone cheese.", count : 0, price : 6.50),
            new Product("Chocolate Lava Cake", "Warm chocolate cake with a gooey molten center, served with vanilla ice cream.", count : 0, price : 7.99),
            new Product("Iced Lemon Tea", "Refreshing iced tea with a hint of lemon flavor.", count :0,price: 3.00)
        };
    }

    private async Task OpenProductDetailDialog(Product selectedProduct)
    {
        DialogOptions dialogOptions = new();
        dialogOptions.MaxWidth = MaxWidth.Medium;
        dialogOptions.DisableBackdropClick = true;

        DialogParameters dialogValue = new DialogParameters<ProductDetailDialogComponent>
        {
            { "ProductModel", selectedProduct }
        };

        IDialogReference dialog = DialogService.Show<ProductDetailDialogComponent>("", dialogValue, dialogOptions);

        var result = await dialog.Result;
        var product = result.Data;

        if (!result.Cancelled && product != null)
        {
            SelectedProducts.Add((Product)product);


            IsDrawerOpen = true;

        }
    }
    private async Task ShowPaymentMethodDialog()
    {
        DialogOptions dialogOptions = new();
        dialogOptions.MaxWidth = MaxWidth.ExtraSmall;
        dialogOptions.DisableBackdropClick = true;

        var dialog = DialogService.Show<PaymentMethodDialogComponent>("", dialogOptions);

        var result = await dialog.Result;

        if (!result.Canceled)
        {

        }

    }

    private async Task SearchInProducts()
    {
        IsLoading = true;
        await Task.Delay(500);

        if (string.IsNullOrEmpty(SearchValue)) { TempProductList = ProductList; }
        TempProductList = TempProductList.Where(x => x.Title.Contains(SearchValue) || x.Description.Contains(SearchValue)).ToList();

        IsLoading = false;
        StateHasChanged();
    }


    private double OrderTotalPrice()
    {
        double price = 0;

        foreach (Product product in SelectedProducts)
        {
            price += (product.Price * product.Count);
        }



        return price;
    }

}
