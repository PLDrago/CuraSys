using System;
using System.Drawing;
using System.Windows.Forms;

namespace CuraSys.GUI.Panels
{
    public class SignInPanel : UserControl
    {
        private TextBox peselTextBox = new();
        private TextBox passwordTextBox = new();
        private Button loginButton = new();

        public event Action? OnPatientLoginSuccess;

        public SignInPanel()
        {
            Dock = DockStyle.Fill;
            BackColor = Color.White;

            Label titleLabel = new()
            {
                Text = "Patient Sign In",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(30, 30),
                AutoSize = true
            };

            peselTextBox.Location = new Point(30, 80);
            peselTextBox.Width = 200;
            peselTextBox.PlaceholderText = "PESEL";

            passwordTextBox.Location = new Point(30, 120);
            passwordTextBox.Width = 200;
            passwordTextBox.PlaceholderText = "Password";
            passwordTextBox.UseSystemPasswordChar = true;

            loginButton.Text = "Log In";
            loginButton.Location = new Point(30, 160);
            loginButton.Click += LoginButton_Click;

            Controls.Add(titleLabel);
            Controls.Add(peselTextBox);
            Controls.Add(passwordTextBox);
            Controls.Add(loginButton);
        }

        private void LoginButton_Click(object? sender, EventArgs e)
        {
            string pesel = peselTextBox.Text;
            string password = passwordTextBox.Text;
            
            if (pesel == "12345678901" && password == "test")
            {
                OnPatientLoginSuccess?.Invoke();
            }
            else
            {
                MessageBox.Show("Nieprawidłowy PESEL lub hasło.", "Błąd logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}