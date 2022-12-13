using System;

namespace Lesson2;

public class FieldModel
{
    public char[,] field;

    public int Height { get; set; }
    public int Lenght { get; set; }

    public FieldModel(int height, int lenght)
	{
        Height = height;
        Lenght = lenght;
        field = new char[Height, Lenght];

        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Lenght; j++)
            {
                field[i, j] = '.';
            }
        }
    }
}

