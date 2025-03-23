// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

//In the following example, we compare the MD5 and SHA256 cryptographic hash functions:20
Console.WriteLine("Hello, World!");

var summary = BenchmarkRunner.Run<Md5VsSha256>();

public class Md5VsSha256
{
    private const int N = 50;
    private readonly byte[] data;

    private readonly SHA256 sha256 = SHA256.Create();
    private readonly MD5 md5 = MD5.Create();

    public Md5VsSha256()
    {
        data = new byte[N];
        new Random(42).NextBytes(data);
    }

    [Benchmark]
    public byte[] Sha256() => sha256.ComputeHash(data);

    [Benchmark]
    public byte[] Md5() => md5.ComputeHash(data);
}