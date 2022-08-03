using System.Threading.Tasks;

namespace HNP.Views
{
    public interface ILoginProvider
    {
        Task<string> LoginAsync();
    }
}