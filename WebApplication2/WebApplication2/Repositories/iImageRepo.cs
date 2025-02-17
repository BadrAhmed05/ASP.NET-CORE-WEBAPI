using WebApplication2.Models.Domain;

namespace WebApplication2.Repositories
{
    public interface iImageRepo
    {
        Task<Image>Upload(Image image);
    }
}
