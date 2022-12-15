namespace Lesson2;

public class Program
{
    private static char[,] field;

    public static void Main()
    {

        Console.Write("Укажите размер поля по оси X: ");
        int y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Укажите размер поля по оси Y: ");
        int x = Convert.ToInt32(Console.ReadLine());

        field = CharBuilder(y, x);

        AutoResetEvent[] waitHandles = new AutoResetEvent[2];

        for (int i = 0; i < 2; i++)
        {
            waitHandles[i] = new AutoResetEvent(false);
            if (i == 1)
                ThreadPool.QueueUserWorkItem(new WaitCallback(SecondFarmer), new ThreadControl(field, waitHandles[i]));
            if (i == 0)
                ThreadPool.QueueUserWorkItem(new WaitCallback(FirstFarmer), new ThreadControl(field, waitHandles[i]));
        }
        AutoResetEvent.WaitAll(waitHandles);

        PrintField(field);
    }

    private static char[,] CharBuilder(int y, int x)
    {
        field = new char[x, y];

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                field[i, j] = '.';
            }
        }

        return field;
    }

    public static void FirstFarmer(object o)
    {
        if (o != null && o is ThreadControl)
        {
            ThreadControl obj = o as ThreadControl;

            for (int i = 0; i < obj.Field.GetLength(0); i++)
            {
                for (int j = 0; j < obj.Field.GetLength(1); j++)
                {
                    if (obj.Field[i, j] == '.')
                        obj.Field[i, j] = 'X';
                    else
                        break;
                    Thread.Sleep(10);
                }
            }
            obj.WaitHandler.Set();
        }
    }

    public static void SecondFarmer(object o)
    {
        if (o != null && o is ThreadControl)
        {
            ThreadControl obj = o as ThreadControl;

            for (int i = (obj.Field.GetLength(1) - 1); i >= 0; i--)
            {
                for (int j = (obj.Field.GetLength(0) - 1); j >= 0; j--)
                {
                    if (obj.Field[j, i] == '.')
                        obj.Field[j, i] = '0';
                    else
                        break;
                    Thread.Sleep(10);
                }
            }
            obj.WaitHandler.Set();
        }
    }

    public static void PrintField(char[,] field)
    {
        Console.Clear();

        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                Console.Write($"{field[i,j]} ");
            }
            Console.WriteLine();
        }
    }
}

