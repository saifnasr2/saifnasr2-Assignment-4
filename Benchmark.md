# Benchmark Analysis



| Method | Iterations | Mean | Error | StdDev | Median | Gen0 | Gen1 | Gen2 | Allocated |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| **StringConcatenation** | **100** | **1,405.7 ns** | **21.14 ns** | **21.71 ns** | **1,396.9 ns** | **4.0092** | **-** | **-** | **12576 B** |
| StringBuilderConcatenation | 100 | 285.8 ns | 5.72 ns | 5.62 ns | 282.6 ns | 0.2446 | - | - | 768 B |
| **StringConcatenation** | **1000** | **80,566.4 ns** | **1,609.74 ns** | **3,062.71 ns** | **78,957.3 ns** | **327.0264** | **-** | **-** | **1025976 B** |
| StringBuilderConcatenation | 1000 | 2,429.4 ns | 48.47 ns | 103.30 ns | 2,421.4 ns | 1.4572 | - | - | 4576 B |
| **StringConcatenation** | **10000** | **7,167,922.3 ns** | **92,936.97 ns** | **72,559.07 ns** | **7,136,916.0 ns** | **31867.1875** | **-** | **-** | **100259976 B** |
| StringBuilderConcatenation | 10000 | 22,899.8 ns | 303.98 ns | 269.47 ns | 22,841.0 ns | 16.9373 | - | - | 53200 B |
| **StringConcatenation** | **100000** | **1,392,143,417.0 ns** | **27,797,324.39 ns** | **54,216,550.51 ns** | **1,389,540,500.0 ns** | **3115000.0000** | **2546000.0000** | **2546000.0000** | **10003455432 B** |
| StringBuilderConcatenation | 100000 | 327,173.5 ns | 6,055.77 ns | 8,084.29 ns | 324,373.4 ns | 62.9883 | 62.0117 | 62.0117 | 410013 B |

### Analysis Questions

**Which approach was faster with 100 iterations?**
`StringBuilderConcatenation` was faster taking a mean time of 285.8 ns compared to 1,405.7 ns for standard string concatenation

**Which approach was faster with 100,000 iterations?**
`StringBuilderConcatenation` was vastly faster at 100,000 iterations taking 327,173.5 ns (~0.3 milliseconds) compared to 1,392,143,417.0 ns (~1.39 seconds) for standard strings

**Which approach allocated more memory?**
Standard string concatenation allocated significantly more memory across all sizes. At 100,000 iterations it allocated over 10 GB (10,003,455,432 Bytes) of memory while `StringBuilder` allocated only about 410 KB (410,013 Bytes)

**What happened to string concatenation performance as the loop size increased?**
The performance degraded exponentially. While the workload increased by 1,000x (from 100 to 100,000 iterations) the execution time increased by almost 1,000,000x (from 1,405.7 ns to 1,392,143,417.0 ns) Memory allocations experienced a similar massive blowout causing immense Garbage Collection pressure (visible in the Gen0, Gen1, and Gen2 columns).

**Why does repeated string concatenation create additional allocations?**
In C#, `string` objects are immutable meaning their data cannot be changed once created. Whenever you append text using `+=` the system must allocate a brand-new block of memory large enough to hold both the old text and the new text. It then copies all the characters over and discards the old string. Inside a loop this forces the Garbage Collector to work constantly to clean up the discarded strings.

**Why does StringBuilder usually perform better when text is repeatedly appended?**
`StringBuilder` is a mutable type that maintains an internal character array (a buffer). When you call `.Append()` it simply inserts the new characters into the empty space of its existing buffer without creating a new object. It only needs to allocate new memory when its current buffer is completely full, which happens infrequently.

**Is StringBuilder always better than normal string operations? Explain.**
No. For simple operations like combining a few variables (e.g., `string full = first + " " + last;`) standard concatenation or string interpolation is preferred. `StringBuilder` carries the overhead of instantiating an object and setting up a buffer. It is only the better choice when appending text inside a loop or when performing a large unknown number of concatenations.