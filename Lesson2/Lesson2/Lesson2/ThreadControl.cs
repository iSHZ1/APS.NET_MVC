using System;
namespace Lesson2;

public class ThreadControl
{
	public AutoResetEvent WaitHandler { get; set; }
	public FieldModel FieldThread { get; set; }

	public ThreadControl(
        FieldModel Field,
        AutoResetEvent waitHandler)
	{
		WaitHandler = waitHandler;
        FieldThread = Field;
	}
}

