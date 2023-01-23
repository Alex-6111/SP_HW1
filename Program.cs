
using System;
using System.Runtime.InteropServices;


namespace SP_HW1
{
    internal class Program
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        const int WM_SETTEXT = 0x000C;
        const int WM_CLOSE = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern bool Beep(uint frequency, uint duration);

        [DllImport("user32.dll")]
        public static extern bool MessageBeep(uint uType);

        static void Main(string[] args)
        {
            Problem3();
        }

        public static void Problem2()
        {
            Console.Write("Enter the window title: ");
            string windowTitle = Console.ReadLine();
            
            IntPtr hWnd = FindWindow(null, windowTitle);
            if (hWnd == IntPtr.Zero)
            {
                Console.WriteLine("Window not found.");
                return;
            }

            Console.WriteLine("What would you like to do with the window?");
            Console.WriteLine("1. Change the title");
            Console.WriteLine("2. Close the window");
            Console.WriteLine("3. Your option");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter the new title: ");
                    string newTitle = Console.ReadLine();

                    SendMessage(hWnd, WM_SETTEXT, IntPtr.Zero, Marshal.StringToHGlobalUni(newTitle));
                    Console.WriteLine("Title changed to " + newTitle);
                    break;
                case 2:
                    SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    Console.WriteLine("Window closed.");
                    break;
                case 3:
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        public static void Problem3()
        {
            uint frequency = 1000;
            uint duration = 1000;
             
            int interval = 1; 

            while (true)
            {
                Beep(frequency, duration);
                Console.WriteLine("Beep!");
                System.Threading.Thread.Sleep(interval * 1000);
            }
        }

    }
}