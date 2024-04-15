namespace ex12_lambdas
{
    // 대리자의 정수값 두개 받아서 정수값을 리턴해주는 함수들은 내가 대신 실행시켜줄게
    delegate int Calculate(int a, int b);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("익명 메서드");

            Calculate calc = delegate (int a, int b) {
                return a + b;
            };

            Console.WriteLine($"계산결과 = {calc(10, 4)}");

            // 람다식을 쓰면 훨씬 짧게 코딩가능
            // calc와 동일한 기능
            Calculate calc2 = (a, b) => a + b; // (int a, int b) => { return a + b; };

            Console.WriteLine($"계산결과 = {calc2(11, 4)}");

            // 문장형식의 람다식
            Calculate calc3 = (a, b) =>
            {
                Console.WriteLine("이런식으로 뺄셈이 됩니다.");
                var sum = a - b;
                return sum;
            };
            Console.WriteLine($"계산결과 = {calc3(11, 4)}");
        }
    }
}
