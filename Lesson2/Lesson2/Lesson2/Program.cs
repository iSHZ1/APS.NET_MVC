namespace Lesson2;

public class Program
{
    public static void Main()
    {

        Console.Write("Укажите размер поля по оси X: ");
        int y = Convert.ToInt32(Console.ReadLine());
        Console.Write("Укажите размер поля по оси Y: ");
        int x = Convert.ToInt32(Console.ReadLine());

        FieldModel Field = new FieldModel(x, y);

        AutoResetEvent[] waitHandles = new AutoResetEvent[2];

        for (int i = 0; i < 2; i++)
        {
            waitHandles[i] = new AutoResetEvent(false);
            if (i == 0)
                ThreadPool.QueueUserWorkItem(new WaitCallback(SecondFarmer), new ThreadControl(Field, waitHandles[i]));
            if (i == 1)
                ThreadPool.QueueUserWorkItem(new WaitCallback(FirstFarmer), new ThreadControl(Field, waitHandles[i]));
        }
        AutoResetEvent.WaitAll(waitHandles);

        PrintField(Field);
    }

    public static void FirstFarmer(object o)
    {
        if (o != null && o is ThreadControl)
        {
            ThreadControl obj = (ThreadControl)o;

            for (int i = 0; i < obj.FieldThread.Height; i++)
            {
                for (int j = 0; j < obj.FieldThread.Lenght; j++)
                {
                    if (obj.FieldThread.field[i, j] == '.')
                        obj.FieldThread.field[i, j] = 'X';
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
            ThreadControl obj = (ThreadControl)o;

            for (int i = (obj.FieldThread.Lenght - 1); i >= 0; i--)
            {
                for (int j = (obj.FieldThread.Height - 1); j >= 0; j--)
                {
                    if (obj.FieldThread.field[j, i] == '.')
                        obj.FieldThread.field[j, i] = '0';
                    else
                        break;
                    Thread.Sleep(10);
                }
            }
            obj.WaitHandler.Set();
        }
    }

    public static void PrintField(FieldModel Field)
    {
        Console.Clear();

        for (int i = 0; i < Field.Height; i++)
        {
            for (int j = 0; j < Field.Lenght; j++)
            {
                Console.Write($"{Field.field[i,j]} ");
            }
            Console.WriteLine();
        }
    }
}

