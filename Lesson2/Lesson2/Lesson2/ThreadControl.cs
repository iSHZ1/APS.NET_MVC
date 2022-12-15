using System;
namespace Lesson2;

public class ThreadControl
{
	public AutoResetEvent WaitHandler { get; set; }
	public char[,] Field { get; set; }

	public ThreadControl(
        char[,] field,
        AutoResetEvent waitHandler)
	{
		WaitHandler = waitHandler;
        this.Field = field;
	}
}

