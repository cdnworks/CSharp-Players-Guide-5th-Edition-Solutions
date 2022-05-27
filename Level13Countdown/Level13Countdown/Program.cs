// See https://aka.ms/new-console-template for more information

//use a recursive method call to count down from 10 to 1.



CountDown(10);


void CountDown(int num)
{
    if(num == 1)    //basecase
    {
        Console.WriteLine(num);
        return;
    }

    Console.WriteLine(num);
    CountDown(num - 1);

}
