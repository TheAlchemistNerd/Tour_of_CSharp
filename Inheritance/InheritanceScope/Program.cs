﻿using System;

namespace InheritanceScope
{
    public class A
    {
        private int value = 10;

        public class B:A
        {
            public int GetValue()
            {
                return this.value;
            }
        }
    }

    public class C:A
    {
        /*
        public int GetValue()
        {
            return this.value
        }
        */
    }

    public class Example
    {
        public static void Main(string[] args)
        {
            var b = new A.B();
            Console.WriteLine(b.GetValue());
        }
    }
}