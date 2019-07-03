using Hex.Event.Core.Domain.Entities.Dtos;
using System.Threading.Tasks;

namespace Hex.Event.Core.Domain.Services
{
    public interface ICourseService
    {
        Task Resgister(SubscribeInputDto subscribe);
    }
}
