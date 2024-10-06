namespace BeautyStore.Domain.Interfaces
{
    public interface IProductImagesRepository
    {
        Task CreateProductImagesAsync(Guid productId, string[] images);
    }
}
