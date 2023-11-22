// collection expressions:
int[] x1 = [1, 2, 3, 4];
int[] x2 = [];
WriteByteArray([(byte)1, (byte)2, (byte)3]);
List<int> x4 = new() { 1, 2, 3, 4 };
Span<DateTime> dates = [GetDate(0), GetDate(1)];
WriteByteSpan([(byte)1, (byte)2, (byte)3]);

int[] numbers1 = [1, 2, 3];
int[] numbers2 = [4, 5, 6];
int[] moreNumbers = [.. numbers1, .. numbers2, 7, 8, 9];
// moreNumbers contains [1, 2, 3, 4, 5, 6, 7, 8, ,9];


List<int> numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9];


void WriteByteSpan(Span<byte> span)
{
}

void WriteByteArray(byte[] bytes)
{
}


DateTime GetDate(int v)
{
    return DateTime.Now;
}


