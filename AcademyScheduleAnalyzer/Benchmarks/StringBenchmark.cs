using System.Text;
using BenchmarkDotNet.Attributes;


namespace AcademyScheduleAnalyzer.Benchmarks;
[MemoryDiagnoser]
public class StringBenchmark
{
    [Params(100, 1000, 10000, 100000)] 
    public int Iterations;
    
    [Benchmark]
    public void StringConcatenation()
    {
        string result = "";

        for(int i =0 ; i < Iterations ; i++)
        {
            result += 'a';

        }
        
    }

    [Benchmark]
    public void StringBuilderConcatenation()
    {
        StringBuilder sb = new StringBuilder();
        for(int i =0 ; i < Iterations ; i++)
        {
            sb.Append('a');
            
        }
        string finalResult = sb.ToString();
    }
}