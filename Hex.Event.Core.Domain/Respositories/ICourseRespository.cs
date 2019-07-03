using Hex.Event.Core.Domain.Entities;
using System.Threading.Tasks;

namespace Hex.Event.Core.Domain.Respositories
{
    public interface ICourseRespository
    {
        Task SaveSubscribe(string course, Student student );
    }
}
