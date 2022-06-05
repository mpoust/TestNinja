
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocks
{
    public class MockFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
