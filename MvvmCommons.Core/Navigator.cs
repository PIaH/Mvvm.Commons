using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Interop;

namespace MvvmCommons.Core
{
    public static class Navigator
    {
        private static Stack<Window> Windows = new Stack<Window>();

        public static void Show<T>(ModelBase model = null, bool modal = false) where T : Window
        {
            var window = Activator.CreateInstance<T>();
            window.DataContext = model;
            window.Closed += delegate
            {
                if (Windows.Count > 0 && Windows.Peek() == window)
                {
                    Windows.Pop();
                }
            };

            if (Windows.Count > 0)
            {
                var parent = Windows.Peek();
                window.Owner = parent;
            }
            Windows.Push(window);
            if (modal)
            {
                window.ShowDialog();
            }
            else
            {
                window.Show();
            }
        }

        public static void Back()
        {
            if (Windows.Count > 0)
            {
                var current = Windows.Pop();
                current.Close();
            }
        }

    }
}
