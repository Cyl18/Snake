﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this T[,] array)
        {
            foreach (var item in array)
            {
                yield return item;
            }
        }
    }
}