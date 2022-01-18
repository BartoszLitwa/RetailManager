using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace RMDesktopUI.Helpers
{
    // https://stackoverflow.com/questions/30631522/caliburn-micro-support-for-passwordbox/31079674#31079674?newreg=9de9f1c09e2a47e7b0d0d172046c8541
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty BoundPasswordProperty =
            DependencyProperty.RegisterAttached("BoundPassword",
                typeof(string),
                typeof(PasswordBoxHelper),
                new FrameworkPropertyMetadata(string.Empty, OnBoundPasswordChanged));

        public static string GetBoundPassword(DependencyObject d)
        {
            if (d is PasswordBox box)
            {
                // this funny little dance here ensures that we've hooked the
                // PasswordChanged event once, and only once.
                box.PasswordChanged -= PasswordChanged;
                box.PasswordChanged += PasswordChanged;
            }

            return (string)d.GetValue(BoundPasswordProperty);
        }

        public static void SetBoundPassword(DependencyObject d, string value)
        {
            if (string.Equals(value, GetBoundPassword(d)))
            {
                return; // and this is how we prevent infinite recursion
            }

            d.SetValue(BoundPasswordProperty, value);
        }

        private static void OnBoundPasswordChanged( DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is PasswordBox box))
            {
                return;
            }

            box.Password = GetBoundPassword(d);
        }

        private static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox password = sender as PasswordBox;

            SetBoundPassword(password, password.Password);

            // set cursor past the last character in the password box
            password.GetType()
                .GetMethod("Select", BindingFlags.Instance | BindingFlags.NonPublic)
                .Invoke(password, new object[] { password.Password.Length, 0 });
        }

    }
}
