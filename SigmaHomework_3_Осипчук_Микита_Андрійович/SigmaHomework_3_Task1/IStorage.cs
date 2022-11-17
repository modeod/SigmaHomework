using SigmaHomework_3_Task1.ProductsModels;

namespace SigmaHomework_3_Task1
{
    public interface IStorage
    {
        ProductModel this[int index] { get; set; }
// Ми це вже обговорювали)))
        List<ProductModel> Products { get; }

        Storage ChangePriceByOnlyPercentages(int percentage);
        List<MeatModel> FindMeatInStorage();
    }
}
