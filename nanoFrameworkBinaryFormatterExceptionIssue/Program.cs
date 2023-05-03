using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace nanoFrameworkBinaryFormatterExceptionIssue
{
    public class Program
    {
        [Serializable]
        public class TestData
        {
            public float A;
            public float B;

            public override string ToString()
            {
                return $"{A} {B}";
            }
        }

        public static void Main()
        {
            var data = new TestData();
            data.A = 10;
            data.B = 20;

            // Serialize
            Debug.WriteLine($"Data: {data}");
            var block = BinaryFormatter.Serialize(data);
            Debug.WriteLine($"Binary: {block.Length} bytes, {BitConverter.ToString(block)}");

            // Corrupt the serialization header
            block[0] = 0xFF;

            try
            {
                // De-serialize
                data = (TestData)BinaryFormatter.Deserialize(block);
                Debug.WriteLine($"De-serialized: {data}");
            }
            catch (SerializationException ex)
            {
                // Shouldn't this be thrown?
                Debug.WriteLine($"SerializationException: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Simple Exception is instead thrown
                Debug.WriteLine($"Exception: {ex.Message}");
            }

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
