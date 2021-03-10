using System.Threading.Tasks;

namespace Server.Helpers {
    public interface ICalculatorRepository {
        Task<int> CalculateAsync(string scheme);
    }
    public class CalculatorRepository : ICalculatorRepository {
        public Task<int> CalculateAsync(string scheme) => Task.Run(() => -1);
    }
}